using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace T_shirt.Data.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }

        [BindNever]
        public ICollection<CartLine> Lines { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Please enter the first address line")]
        public string Line1 { get; set; } = null!;
        public string Line2 { get; set; } = null!;
        public string Line3 { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a state name")]
        public string State { get; set; } = null!;
        public string Zip { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; } = null!;
        public bool GiftWrap { get; set; }

        [BindNever]
        public bool Shipped { get; set; }
    }
}
