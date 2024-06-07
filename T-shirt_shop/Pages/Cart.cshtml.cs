using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T_shirt.Data.Models;
using T_shirt.Data.Models.Models;


namespace T_shirt_shop.Pages
{
    public class CartModel : PageModel
    {
        private IStoreRepository repository;
        private IOrderRepository orderRepository;
        public CartModel(IStoreRepository repo, IOrderRepository orderRepository)
        {
            repository = repo;
            this.orderRepository = orderRepository;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            Cart = new Cart();
            Order? order = orderRepository.Orders.FirstOrDefault();
            if(order == null)
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            Cart.AddItem(product, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
            cl.Product.ProductID == productId).Product);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
