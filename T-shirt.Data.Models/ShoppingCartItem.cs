using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_shirt.Data.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;
    }
}
