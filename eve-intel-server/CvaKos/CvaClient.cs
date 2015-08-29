using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using eve_intel_server.Domain;
using EveAI.Live;
using EveAI.Live.Character;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NHibernate;

namespace eve_intel_server.CvaKos
{
    public static class CvaClient
    {
        public static CvaCharacterInfo[] GetCvaCharacterInfos(string[] characterNames) {
            CvaCharacterInfo[] result = new CvaCharacterInfo[characterNames.Length];
            // TODO: not implemenrted
            return result;
        }






        // TODO: move these dicts int DB - CvaKosInfo { Id IDENTITY PK, EntityId, EntityType (IdType as int), IsKos}
        private static readonly Dictionary<long, bool> _KosCharacters = new Dictionary<long, bool>();
        private static readonly Dictionary<long, bool> _KosCorporations = new Dictionary<long, bool>();
        private static readonly Dictionary<long, bool> _KosAlliances = new Dictionary<long, bool>();

        private static int FillDataTable(EveApi api, long solarsystemId, DataTable table, List<string> names, ISession session) {
            Dictionary<string, long> dict = api.GetCharacterIDLookup(names);

            int kosCounter = 0;
            foreach (KeyValuePair<string, long> pair in dict) {
                if (pair.Value == 0) {
                    continue;
                }

                api.Authentication.CharacterID = pair.Value;
                CharacterInfo characterInfo = api.GetCharacterInfo();
                if (characterInfo.CharacterID == 0) {
                    continue;
                }

                bool pilotKos = IsKos(characterInfo.CharacterID, characterInfo.Name, IdType.Character);
                bool corporationKos;
                bool allianceKos;
                if (IsNpcCorp(characterInfo.CorporationID)) {
                    corporationKos = false;
                    allianceKos = false;
                } else {
                    corporationKos = IsKos(characterInfo.CorporationID, characterInfo.CorporationName, IdType.Corporation);
                    allianceKos = (characterInfo.AllianceID != -1) && IsKos(characterInfo.AllianceID, characterInfo.AllianceName, IdType.Alliance);
                }

                EvePlayerInfo pl = new EvePlayerInfo {
                    Id = characterInfo.CharacterID,
                    PlayerName = characterInfo.Name,
                    SolarsystemTime = DateTime.Now,
                    IsKos = pilotKos || corporationKos || allianceKos
                };
                pl.SetSolarsystemId(solarsystemId, session);
                if (pl.IsKos) {
                    ++kosCounter;
                }
                session.SaveOrUpdate(pl);

                Thread.Sleep(50);
            }

            return kosCounter;
        }

        private static bool IsKos(long id, string name, IdType type) {
            bool kos = false;

            CvaCharacterInfo characterInfo = null;
            CvaCorporationInfo corpInfo = null;
            CvaAllianceInfo allianceInfo = null;

            switch (type) {
                case IdType.Character: {
                    if (!_KosCharacters.TryGetValue(id, out kos)) {
                        characterInfo = GetCharacterInfo(id, name);
                        kos = characterInfo?.Kos == true;
                    }
                    break;
                }
                case IdType.Corporation: {
                    if (!_KosCorporations.TryGetValue(id, out kos)) {
                        corpInfo = GetCorpInfo(id, name);
                        kos = corpInfo?.Kos == true;
                    }
                    break;
                }
                case IdType.Alliance: {
                    if (!_KosAlliances.TryGetValue(id, out kos)) {
                        allianceInfo = GetAllianceInfo(id, name);
                        kos = allianceInfo?.Kos == true;
                    }
                    break;
                }
            }

            if (characterInfo != null && !_KosCharacters.ContainsKey(characterInfo.EveId)) {
                _KosCharacters.Add(characterInfo.EveId, characterInfo.Kos);
                corpInfo = characterInfo.Corp;
            }

            if (corpInfo != null && !_KosCorporations.ContainsKey(corpInfo.EveId)) {
                _KosCorporations.Add(corpInfo.EveId, corpInfo.Kos);
                allianceInfo = corpInfo.Alliance;
            }

            if (allianceInfo != null && !_KosAlliances.ContainsKey(allianceInfo.EveId)) {
                _KosAlliances.Add(allianceInfo.EveId, allianceInfo.Kos);
            }

            return kos;
        }

        private static bool IsNpcCorp(long id) {
            return id >= 1000002 && id <= 1000182;
        }

        private enum IdType
        {
            Character,
            Corporation,
            Alliance
        }

        #region http://kos.cva-eve.org/api/ request

        private const string cUrlFormat = "http://kos.cva-eve.org/api/?c=json&type={0}&q={1}";

        private static TResult GetInfo<TResult>(long eveId, string name) where TResult : CvaBaseInfo, new() {
            string type;
            if (typeof (TResult) == typeof (CvaCharacterInfo)) {
                type = "unit";
            } else if (typeof (TResult) == typeof (CvaCorporationInfo)) {
                type = "corp";
            } else if (typeof (TResult) == typeof (CvaAllianceInfo)) {
                type = "alliance";
            } else {
                throw new Exception("Invalid result type " + typeof (TResult).FullName);
            }

            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(string.Format(cUrlFormat, type, Uri.EscapeUriString(name)));
            JObject jObject;
            using (WebResponse response = request.GetResponse()) {
                using (Stream stream = response.GetResponseStream()) {
                    using (StreamReader reader = new StreamReader(stream)) {
                        using (JsonTextReader jReader = new JsonTextReader(reader)) {
                            jObject = JObject.Load(jReader);
                        }
                    }
                }
            }

            JToken jMessage = jObject["message"];
            if (jMessage.Value<string>() != "OK") {
                throw new Exception("error message from kos.cva-eve.org: " + jMessage.Value<string>());
            }

            JToken jTotal = jObject["total"];
            if (jTotal.Value<int>() == 0) {
                return new TResult {
                    Id = -1,
                    EveId = eveId,
                    Type = type,
                    Kos = false
                };
            }

            JArray jResults = (JArray) jObject["results"];
            TResult[] results = jResults.ToObject<TResult[]>();
            return results.FirstOrDefault(o => o.EveId == eveId);
        }

        private static CvaCharacterInfo GetCharacterInfo(long eveId, string name) {
            return GetInfo<CvaCharacterInfo>(eveId, name);
        }

        private static CvaCorporationInfo GetCorpInfo(long eveId, string name) {
            return GetInfo<CvaCorporationInfo>(eveId, name);
        }

        private static CvaAllianceInfo GetAllianceInfo(long eveId, string name) {
            return GetInfo<CvaAllianceInfo>(eveId, name);
        }

        #endregion
    }
}
