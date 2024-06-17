using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T_shirt.Data.Models;
using T_shirt.Data.Models.Models;
using T_shirt.Data.Models.ViewModels;

namespace T_shirt_shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IStoreRepository _storeRepository;

        public ProductController(IStoreRepository storeRepository) 
        {
            _storeRepository = storeRepository;
        }

        [Authorize(Roles = "Admin"), HttpPost]
        public async Task<IActionResult> Delete(long productId)
        {
            Product? product = await _storeRepository.Products.FirstOrDefaultAsync(x => x.ProductID == productId);
            if (product == null)
                return NotFound();

            _storeRepository.DeleteProduct(product);

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin"), HttpGet]
        public async Task<IActionResult> Edit(long productId)
        {
            Product? product = await _storeRepository.Products.FirstOrDefaultAsync(x => x.ProductID == productId);
            if (product == null)
                return NotFound();

            return View(new EditProductViewModel
            {
                ProductId = productId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            });
        }

        [Authorize(Roles = "Admin"), HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel editProductViewModel)
        {
            Product? product = await _storeRepository.Products.FirstOrDefaultAsync(x => x.ProductID == editProductViewModel.ProductId);
            if (product == null)
                return NotFound();

            product.Name = editProductViewModel.Name;
            product.Description = editProductViewModel.Description;
            product.Price = editProductViewModel.Price;
            _storeRepository.SaveProduct(product);

            return RedirectToAction("Index", "Home");
        }
    }
}
