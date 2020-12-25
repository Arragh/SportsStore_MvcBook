using Microsoft.AspNetCore.Mvc;
using SportsStore_MvcBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore_MvcBook.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index() => View(repository.Products);

        [HttpGet]
        public ViewResult Edit(int productId) => View(repository.Products.FirstOrDefault(p => p.ProductId == productId));

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"Изменения для {product.Name} сохранены";
                return RedirectToAction("Index");
            }
            return View(product);
        }

    }
}
