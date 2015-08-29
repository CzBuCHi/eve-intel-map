using Newtonsoft.Json;

namespace eve_intel_server.Domain
{
    public class CvaCorporationInfo : CvaBaseInfo
    {
        [JsonProperty("ticker")]
        public virtual string Ticker { get; set; }

        [JsonProperty("npc")]
        public virtual bool Npc { get; set; }

        [JsonProperty("alliance")]
        public virtual CvaAllianceInfo Alliance { get; set; }
    }
}