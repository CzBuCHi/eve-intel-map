using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace eve_intel_map.model
{
    [Table("eve_races")]
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Race
    {
        [Column("race_id", Order = 0)]
        [Key]
        public int Id { get; set; }

        [Column("race_name", Order = 1)]
        public string Name { get; set; }
    }
}
