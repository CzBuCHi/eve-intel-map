using System.Runtime.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace eve_intel_server.Model
{
    [DataContract]
    public class EveIntelAllianceInfo
    {
        [JsonProperty("type")]
        [DataMember]
        public virtual string Type { get; set; }

        [JsonProperty("id")]
        [DataMember]
        public virtual long Id { get; set; }

        [JsonProperty("label")]
        [DataMember]
        public virtual string Label { get; set; }

        [JsonProperty("icon")]
        [DataMember]
        public virtual string Icon { get; set; }

        [JsonProperty("kos")]
        [DataMember]
        public virtual bool Kos { get; set; }

        [JsonProperty("eveid")]
        [DataMember]
        public virtual long EveId { get; set; }

        [JsonProperty("ticker")]
        [CanBeNull]
        [DataMember]
        public virtual string Ticker { get; set; }
    }
}
