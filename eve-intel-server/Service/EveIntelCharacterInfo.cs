using System;
using System.Runtime.Serialization;

namespace eve_intel_server.Service
{
    [DataContract]
    public class EveIntelCharacterInfo
    {
        [DataMember]
        public long CharacterID { get; set; }

        [DataMember]
        public string CharacterName { get; set; }

        [DataMember]
        public string CorporationName { get; set; }

        [DataMember]
        public string AllianceName { get; set; }

        [DataMember]
        public bool CharacterKos { get; set; }

        [DataMember]
        public bool CorporationKos { get; set; }

        [DataMember]
        public bool? AllianceKos { get; set; }

        [DataMember]
        public long? SolarsystemID { get; set; }

        [DataMember]
        public DateTime? SolarsystemTime { get; set; }

        [DataMember]
        public int? ShipTypeID { get; set; }

        [DataMember]
        public DateTime? ShipTypeTime { get; set; }

        [DataMember]
        public string Notes { get; set; }

        internal bool Kos => CharacterKos || CorporationKos || (AllianceKos ?? false);
    }
}