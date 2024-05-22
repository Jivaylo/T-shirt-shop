using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_shirtshop.Data.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }

        [ForeignKey("TShirtId")]
        public int TShirtId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; } = null!;

        [ForeignKey("TShirtId")]
        public virtual TShirt TShirt { get; set; } = null!;
    }
}
