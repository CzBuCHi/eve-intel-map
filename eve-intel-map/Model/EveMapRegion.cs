using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eve_intel_map.Model
{
    [Table("EveMapRegions")]
    public class EveMapRegion
    {
        [Column("Id", Order = 0)]
        [Key]
        public int Id { get; set; }

        [Column("Name", Order = 1)]
        public string Name { get; set; }
    }
}
