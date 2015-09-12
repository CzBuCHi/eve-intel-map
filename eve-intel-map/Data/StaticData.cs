﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using JetBrains.Annotations;

namespace eve_intel_map.Data
{
    public class StaticData : DbContext
    {
        public StaticData()
            : base("name=eve-intel") {
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
    }
}

