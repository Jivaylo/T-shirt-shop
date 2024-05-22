using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_shirtshop.Data.Models
{
    public class TShirt
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("TeamId")]
        public int TeamId { get; set; }

        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; } = null!;
    }
}
