using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace T_shirt.Data.Models
{

    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; } = null!;

        public ICollection<Order> Orders { get; set; } = null!;
    }
}
