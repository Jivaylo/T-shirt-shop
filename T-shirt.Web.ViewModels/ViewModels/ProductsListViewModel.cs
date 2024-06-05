using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_shirt.Data.Models;

namespace T_shirt_shop.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; } = null!;
        public PagingInfo PagingInfo { get; set; } = null!;
        public string CurrentCategory { get; set; } = null!;
    }
}
