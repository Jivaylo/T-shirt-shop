using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace T_shirt.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(200)]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "In Stock")]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
