using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_shirtshop.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Address { get; set; } = null!;
    }
}
