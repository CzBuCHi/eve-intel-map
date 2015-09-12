using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using JetBrains.Annotations;

namespace eve_intel_map.Data
{
    public class IntelData : DbContext
    {
        public IntelData()
            : base("name=eve-intel") {
        }

        [NotNull]
        public virtual DbSet<IntelDataRow> IntelDataTable { get; set; }

        [NotNull]
        public virtual DbSet<IntelGridRow> IntelGridTable { get; set; }

        [Table(("intelData"))]
        public class IntelDataRow
        {
            [Key]
            [Column("characterID", Order = 0)]
            public virtual long CharacterID { get; set; }

            [Column("characterName", Order = 1)]
            [NotNull]
            public virtual string CharacterName { get; set; }

            [Column("corporationName", Order = 2)]
            [NotNull]
            public virtual string CorporationName { get; set; }

            [Column("allianceName", Order = 3)]
            [CanBeNull]
            public virtual string AllianceName { get; set; }

            [Column("characterKos", Order = 4)]
            public virtual bool CharacterKos { get; set; }

            [Column("corporationKos", Order = 5)]
            public virtual bool CorporationKos { get; set; }

            [Column("allianceKos", Order = 6)]
            public virtual bool? AllianceKos { get; set; }

            [Column("solarsystemID", Order = 7)]
            public virtual long? SolarsystemID { get; set; }

            [Column("solarsystemTime", Order = 8)]
            public virtual DateTime? SolarsystemTime { get; set; }

            [Column("shipTypeID", Order = 9)]
            public virtual int? ShipTypeID { get; set; }

            [Column("shipTypeTime", Order = 10)]
            public virtual DateTime? ShipTypeTime { get; set; }

            [Column("notes", Order = 11)]
            [CanBeNull]
            public virtual string Notes { get; set; }
        }

        [Table("intelGrid")]
        public class IntelGridRow
        {
            [Key]
            [Column("characterID", Order = 0)]
            public virtual long CharacterID { get; set; }

            [Column("characterName", Order = 1)]
            [NotNull]
            public virtual string CharacterName { get; set; }

            [Column("corporationName", Order = 2)]
            [NotNull]
            public virtual string CorporationName { get; set; }

            [Column("allianceName", Order = 3)]
            [CanBeNull]
            public virtual string AllianceName { get; set; }

            [Column("characterKos", Order = 4)]
            public virtual bool CharacterKos { get; set; }

            [Column("corporationKos", Order = 5)]
            public virtual bool CorporationKos { get; set; }

            [Column("allianceKos", Order = 6)]
            public virtual bool? AllianceKos { get; set; }

            [Column("solarsystemID", Order = 7)]
            public virtual long? SolarsystemID { get; set; }

            [Column("solarsystemTime", Order = 8)]
            public virtual DateTime? SolarsystemTime { get; set; }

            [Column("shipTypeID", Order = 9)]
            public virtual int? ShipTypeID { get; set; }

            [Column("shipTypeTime", Order = 10)]
            public virtual DateTime? ShipTypeTime { get; set; }

            [Column("shipInfo", Order = 11)]
            [CanBeNull]
            public virtual string ShipInfo { get; set; }

            [Column("notes", Order = 12)]
            [CanBeNull]
            public virtual string Notes { get; set; }
        }
    }
}