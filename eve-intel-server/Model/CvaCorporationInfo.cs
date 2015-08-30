using Newtonsoft.Json;

namespace eve_intel_server.Model
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