using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using T_shirt.Data.Models.Models;
using T_shirt_shop.Models.ViewModels;

namespace T_shirt_shop.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize { get; set; } = 4;

        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string category, int productPage = 1)
        {
            return View(new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(e =>
                            e.Category == category).Count()
                },
                CurrentCategory = category
            });
        }
    }
}