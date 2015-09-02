using System.Runtime.Serialization;

namespace eve_intel_server.Service
{
    [DataContract]
    public class EveIntelCharacterInfo
    {
        [DataMember]
        public string Label { get; set; }

        [DataMember]
        public bool Kos { get; set; }

        [DataMember]
        public long EveId { get; set; }

        [DataMember]
        public EveIntelCorporationInfo Corp { get; set; }
    }
}
