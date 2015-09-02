using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace eve_intel_server.Service
{
    [DataContract]
    public class EveIntelCorporationInfo
    {
        [DataMember]
        public string Label { get; set; }

        [DataMember]
        public bool Kos { get; set; }

        [DataMember]
        public long EveId { get; set; }

        [DataMember]
        public bool Npc { get; set; }

        [CanBeNull]
        [DataMember]
        public EveIntelAllianceInfo Alliance { get; set; }
    }
}
