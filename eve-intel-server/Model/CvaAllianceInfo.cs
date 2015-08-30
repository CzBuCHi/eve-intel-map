using Newtonsoft.Json;

namespace eve_intel_server.Model
{
    public class CvaAllianceInfo : CvaBaseInfo
    {
        [JsonProperty("ticker")]
        public virtual string Ticker { get; set; }
    }
}