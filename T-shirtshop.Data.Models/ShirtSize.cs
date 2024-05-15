using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_shirtshop.Data.Models
{
    public class ShirtSize
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SortPriority { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        public int Price { get; set; }
    }
}
