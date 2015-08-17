using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace eve_intel_map.model
{
    [Table("eve_ship_types")]
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ShipType
    {
        [Column("ship_id", Order = 0)]
        [Key]
        public int Id { get; set; }

        [Column("ship_type_name", Order = 1)]
        public string Name { get; set; }
    }
}
