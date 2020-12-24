using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore_MvcBook.Models
{
    public class FakeProductRepository// : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product { Name = "Football", Description = "Какой-то футбол", Price = 25 },
            new Product { Name = "Surf Board", Description = "Какая-то доска", Price = 179 },
            new Product { Name = "Running Shoes", Description = "Беговая обувь", Price = 95 }
        }.AsQueryable();
    }
}
