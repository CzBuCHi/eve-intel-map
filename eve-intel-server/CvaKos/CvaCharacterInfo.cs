using Newtonsoft.Json;

namespace eve_intel_server.CvaKos
{
    public class CvaCharacterInfo
    {
        [JsonProperty("type")]
        public virtual string Type { get; set; }

        [JsonProperty("id")]
        public virtual long Id { get; set; }

        [JsonProperty("label")]
        public virtual string Label { get; set; }

        [JsonProperty("icon")]
        public virtual string Icon { get; set; }

        [JsonProperty("kos")]
        public virtual bool Kos { get; set; }

        [JsonProperty("eveid")]
        public virtual long EveId { get; set; }

        [JsonProperty("corp")]
        public virtual CvaCorporationInfo Corp { get; set; }
    }
}
