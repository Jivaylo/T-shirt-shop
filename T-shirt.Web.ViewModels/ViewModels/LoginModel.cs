using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace T_shirt_shop.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        public string ReturnUrl { get; set; } = "/";
    }
}
