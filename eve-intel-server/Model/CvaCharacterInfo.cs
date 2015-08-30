using Newtonsoft.Json;

namespace eve_intel_server.Model
{
    public class CvaCharacterInfo : CvaBaseInfo
    {
        [JsonProperty("corp")]
        public virtual CvaCorporationInfo Corp { get; set; }
    }
}