using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eve_intel_map.Model
{
    [Table("EveMapSolarsystemJumps")] 
    public class EveMapSolarsystemJump
    {
        [Column("FromSolarsystem", Order = 0)]
        [Key]
        public int FromSolarsystem { get; set; }

        [Column("ToSolarsystem", Order = 1)]
        [Key]
        public int ToSolarsystem { get; set; }
    }
}
