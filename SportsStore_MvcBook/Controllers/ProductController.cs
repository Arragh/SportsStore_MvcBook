using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore_MvcBook.Models;

namespace SportsStore_MvcBook.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public int PageSize = 4;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult List(int page = 1) => View(repository.Products.OrderBy(p => p.ProductId)
                                                                           .Skip((page - 1) * PageSize)
                                                                           .Take(PageSize));
    }
}
