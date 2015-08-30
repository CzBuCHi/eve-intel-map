using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eve_intel_map.Model
{
    [Table("EveMapSolarsystems")]
    public class EveMapSolarsystem
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("RegionId")]
        public int RegionId { get; set; }

        [Column("Name")]
        public string Name { get; set; }
    }
}
