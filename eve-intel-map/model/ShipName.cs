using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace eve_intel_map.model
{
    [Table("eve_ship_names")]
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ShipName
    {
        [Column("ship_name", Order = 0)]
        [Key]
        public string Name { get; set; }

        [Column("ship_type_id", Order = 1)]
        public int TypeId { get; set; }

        [Column("tech_level", Order = 2)]
        public int TechLevel { get; set; }

        [Column("race_id", Order = 3)]
        public int RaceId { get; set; }
    }
}
