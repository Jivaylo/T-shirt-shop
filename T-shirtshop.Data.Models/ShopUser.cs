using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_shirtshop.Data.Models
{
    public class ShopUser : IdentityUser
    {
        [Required, MaxLength(50)]
        public string FullName { get; set; } = null!;
        public bool Enabled { get; set; } = true;
        public DateTimeOffset? LastLoginDate { get; set; }

    }
}
