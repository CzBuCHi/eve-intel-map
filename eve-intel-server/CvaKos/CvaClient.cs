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
        public static CvaCharacterInfo GetCharacterInfo(long eveId, [NotNull] string name) {
            JObject jObject = GetJObject(name, "unit");

            JToken jTotal = jObject["total"];
            if (jTotal.Value<int>() == 0) {
                return new CvaCharacterInfo {
                    Id = -1,
                    EveId = eveId,
                    Type = "unit",
                    Kos = false
                };
            }

            JArray jResults = (JArray) jObject["results"];
            CvaCharacterInfo[] results = jResults.ToObject<CvaCharacterInfo[]>();
            return results.FirstOrDefault(o => o.EveId == eveId);
        }

        [CanBeNull]
        public static CvaCorporationInfo GetCorpInfo(long eveId, [NotNull] string name) {
            JObject jObject = GetJObject(name, "corp");

            JToken jTotal = jObject["total"];
            if (jTotal.Value<int>() == 0) {
                return new CvaCorporationInfo {
                    Id = -1,
                    EveId = eveId,
                    Type = "corp",
                    Kos = false
                };
            }

            JArray jResults = (JArray) jObject["results"];
            CvaCorporationInfo[] results = jResults.ToObject<CvaCorporationInfo[]>();
            return results.FirstOrDefault(o => o.EveId == eveId);
        }

        [CanBeNull]
        public static CvaAllianceInfo GetAllianceInfo(long eveId, [NotNull] string name) {
            JObject jObject = GetJObject(name, "alliance");

            JToken jTotal = jObject["total"];
            if (jTotal.Value<int>() == 0) {
                return new CvaAllianceInfo {
                    Id = -1,
                    EveId = eveId,
                    Type = "alliance",
                    Kos = false
                };
            }

            JArray jResults = (JArray) jObject["results"];
            CvaAllianceInfo[] results = jResults.ToObject<CvaAllianceInfo[]>();
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
