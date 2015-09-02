using JetBrains.Annotations;
using Newtonsoft.Json;

namespace eve_intel_server.CvaKos
{
    public class CvaCorporationInfo
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

        [JsonProperty("ticker")]
        [CanBeNull]
        public virtual string Ticker { get; set; }

        [JsonProperty("npc")]
        public virtual bool Npc { get; set; }

        [JsonProperty("alliance")]
        [CanBeNull]
        public virtual CvaAllianceInfo Alliance { get; set; }
    }
}
