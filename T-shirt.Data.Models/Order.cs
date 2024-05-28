using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_shirt.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ShoppingCartId { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; } = null!;
        public ApplicationUser ApplicationUser { get; set; } = null!;

        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string GiftMessage { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; set; } = null!;
    }
}
