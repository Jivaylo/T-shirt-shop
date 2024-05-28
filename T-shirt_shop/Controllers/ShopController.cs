using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using T_shirt.Data.Models;
using T_shirt_shop.Data;

namespace T_shirt_shop.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShopController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

       public IActionResult AddToCart(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            // Check if the product is already in the shopping cart
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(sci => sci.ProductId == id);

            if (shoppingCartItem == null)
            {
                // If the product is not in the shopping cart, add a new shopping cart item
                shoppingCartItem = new ShoppingCartItem
                {
                    ProductId = id,
                    Quantity = 1,
                    TotalPrice = product.Price
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                // If the product is already in the shopping cart, increase the quantity
                shoppingCartItem.Quantity++;
                shoppingCartItem.TotalPrice = shoppingCartItem.Quantity * product.Price;
            }

            // Save the changes to the database
            _context.SaveChanges();

            // Redirect to the shopping cart page
            return RedirectToAction("Index", "ShoppingCart");
        }
      
    }
}
