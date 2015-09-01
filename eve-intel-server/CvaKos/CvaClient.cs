using System;
using System.IO;
using System.Linq;
using System.Net;
using eve_intel_server.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace eve_intel_server.CvaKos
{
    public static class CvaClient
    {
        private const string cUrlFormat = "http://kos.cva-eve.org/api/?c=json&type={0}&q={1}";

        [CanBeNull]
        public static EveIntelCharacterInfo GetCharacterInfo(long eveId, [NotNull] string name) {
            JObject jObject = GetJObject(name, "unit");

            JToken jTotal = jObject["total"];
            if (jTotal.Value<int>() == 0) {
                return new EveIntelCharacterInfo {
                    Id = -1,
                    EveId = eveId,
                    Type = "unit",
                    Kos = false
                };
            }

            JArray jResults = (JArray) jObject["results"];
            EveIntelCharacterInfo[] results = jResults.ToObject<EveIntelCharacterInfo[]>();
            return results.FirstOrDefault(o => o.EveId == eveId);
        }

        [CanBeNull]
        public static EveIntelCorporationInfo GetCorpInfo(long eveId, [NotNull] string name) {
            JObject jObject = GetJObject(name, "corp");

            JToken jTotal = jObject["total"];
            if (jTotal.Value<int>() == 0) {
                return new EveIntelCorporationInfo {
                    Id = -1,
                    EveId = eveId,
                    Type = "corp",
                    Kos = false
                };
            }

            JArray jResults = (JArray) jObject["results"];
            EveIntelCorporationInfo[] results = jResults.ToObject<EveIntelCorporationInfo[]>();
            return results.FirstOrDefault(o => o.EveId == eveId);
        }

        [CanBeNull]
        public static EveIntelAllianceInfo GetAllianceInfo(long eveId, [NotNull] string name) {
            JObject jObject = GetJObject(name, "alliance");

            JToken jTotal = jObject["total"];
            if (jTotal.Value<int>() == 0) {
                return new EveIntelAllianceInfo {
                    Id = -1,
                    EveId = eveId,
                    Type = "alliance",
                    Kos = false
                };
            }

            JArray jResults = (JArray) jObject["results"];
            EveIntelAllianceInfo[] results = jResults.ToObject<EveIntelAllianceInfo[]>();
            return results.FirstOrDefault(o => o.EveId == eveId);
        }

        [NotNull]
        private static JObject GetJObject([NotNull] string name, [NotNull] string type) {
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
            return jObject;
        }
    }
}
