using Microsoft.AspNetCore.Mvc;
using SportsStore_MvcBook.Models;
using SportsStore_MvcBook.Models.Pagination;
using System.Linq;

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

        public IActionResult List(int page = 1) => View(new ProductListViewModel
        {
            Products = repository.Products.OrderBy(p => p.ProductId)
                                          .Skip((page - 1) * PageSize)
                                          .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = repository.Products.Count()
            }
        });
    }
}
