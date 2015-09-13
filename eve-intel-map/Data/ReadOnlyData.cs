using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using JetBrains.Annotations;

namespace eve_intel_map.Data
{
    public class ReadOnlyData : DbContext
    {
        public ReadOnlyData()
            : base("name=eve-intel-read-only") {
        }

        [NotNull]
        public virtual DbSet<EveShipsRow> EveShipsTable { get; set; }

        [NotNull]
        public virtual DbSet<MapRegionRow> MapRegionTable { get; set; }

        [NotNull]
        public virtual DbSet<MapConstellationRow> MapConstellationTable { get; set; }

        [NotNull]
        public virtual DbSet<MapSolarSystemRow> MapSolarSystemTable { get; set; }

        [NotNull]
        public virtual DbSet<MapSolarSystemJumpRow> MapSolarSystemJumpTable { get; set; }

        [NotNull]
        public virtual DbSet<IntelGridRow> IntelGridTable { get; set; }

        [Table(("eveShips"))]
        public class EveShipsRow
        {
            [Key]
            [Column("typeID", Order = 0)]
            public virtual int TypeID { get; set; }

            [Column("typeName", Order = 1)]
            [NotNull]
            public virtual string TypeName { get; set; }

            [Column("raceName", Order = 2)]
            [NotNull]
            public virtual string RaceName { get; set; }

            [Column("metaGroupName", Order = 3)]
            [NotNull]
            public virtual string MetaGroupName { get; set; }

            [Column("groupName", Order = 4)]
            [NotNull]
            public virtual string GroupName { get; set; }
        }

        [Table(("mapRegions"))]
        public class MapRegionRow
        {
            [Key]
            [Column("regionID", Order = 0)]
            public virtual long RegionID { get; set; }

            [Column("regionName", Order = 1)]
            [NotNull]
            public virtual string RegionName { get; set; }
        }

        [Table(("mapConstellations"))]
        public class MapConstellationRow
        {
            [Key]
            [Column("regionID", Order = 0)]
            public virtual long RegionID { get; set; }

            [Column("constellationID", Order = 1)]
            public virtual long ConstellationID { get; set; }

            [Column("constellationName", Order = 2)]
            [NotNull]
            public virtual string ConstellationName { get; set; }
        }

        [Table(("mapSolarSystems"))]
        public class MapSolarSystemRow
        {
            [Key]
            [Column("solarSystemID", Order = 0)]
            public virtual long SolarSystemID { get; set; }

            [Column("constellationID", Order = 1)]
            public virtual long ConstellationID { get; set; }

            [Column("regionID", Order = 2)]
            public virtual long RegionID { get; set; }

            [Column("solarSystemName", Order = 3)]
            [NotNull]
            public virtual string SolarSystemName { get; set; }
        }

        [Table(("mapSolarSystemJumps"))]
        public class MapSolarSystemJumpRow
        {
            [Key]
            [Column("toSolarSystemID", Order = 0)]
            public virtual long ToSolarSystemID { get; set; }

            [Column("fromSolarSystemID", Order = 1)]
            public virtual long FromSolarSystemID { get; set; }
        }

        [Table("intelGrid")]
        public class IntelGridRow
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

            [Column("solarSystemName", Order = 7)]
            public virtual string SolarSystemName { get; set; }

            [Column("constellationName", Order = 8)]
            public virtual string ConstellationName { get; set; }

            [Column("regionName", Order = 9)]
            public virtual string RegionName { get; set; }

            [Column("solarsystemTime", Order = 10)]
            public virtual DateTime? SolarsystemTime { get; set; }

            [Column("shipTypeID", Order = 11)]
            public virtual int? ShipTypeID { get; set; }

            [Column("shipTypeTime", Order = 12)]
            public virtual DateTime? ShipTypeTime { get; set; }

            [Column("shipInfo", Order = 13)]
            [CanBeNull]
            public virtual string ShipInfo { get; set; }

            [Column("notes", Order = 14)]
            [CanBeNull]
            public virtual string Notes { get; set; }
        }
    }
}


