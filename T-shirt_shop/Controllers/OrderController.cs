using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using T_shirt.Data.Models;
using T_shirt_shop.Data;

namespace T_shirt_shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }

        public IActionResult Details(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }
    }
}

