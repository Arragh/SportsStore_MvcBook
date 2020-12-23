using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore_MvcBook.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Товары
            Product product1 = new Product()
            {
                ProductId = 1,
                Name = "Kayak",
                Description = "Одноместная лодка",
                Category = "Watersports",
                Price = 275
            };

            Product product2 = new Product()
            {
                ProductId = 2,
                Name = "LifeJacket",
                Description = "Спасательный жилет",
                Category = "Watersports",
                Price = 48.95M
            };

            Product product3 = new Product()
            {
                ProductId = 3,
                Name = "Soccer Ball",
                Description = "Мяч для игры в футбол",
                Category = "Soccer",
                Price = 19.50M
            };

            Product product4 = new Product()
            {
                ProductId = 4,
                Name = "Corner Flags",
                Description = "Какие-то флажки, БЛЕАТЬ!",
                Category = "Soccer",
                Price = 34.95M
            };

            Product product5 = new Product()
            {
                ProductId = 5,
                Name = "Stadium",
                Description = "Стадион на 35.000 мест",
                Category = "Soccer",
                Price = 79500
            };

            Product product6 = new Product()
            {
                ProductId = 6,
                Name = "Thinking Cap",
                Description = "Шляпа для стимуляции работы мозга",
                Category = "Chess",
                Price = 16
            };

            Product product7 = new Product()
            {
                ProductId = 7,
                Name = "Unsteady Chair",
                Description = "Неудобный стул для вашего опонента",
                Category = "Chess",
                Price = 29.95M
            };

            Product product8 = new Product()
            {
                ProductId = 8,
                Name = "Human Chess Board",
                Description = "Семейная игра",
                Category = "Chess",
                Price = 75
            };

            Product product9 = new Product()
            {
                ProductId = 9,
                Name = "Blya-Blya King",
                Description = "Мажорская шахматная фигурка",
                Category = "Chess",
                Price = 1200
            };
            #endregion

            modelBuilder.Entity<Product>().HasData(new Product[] { product1, product2, product3, product4, product5, product6, product7, product8, product9 });
            base.OnModelCreating(modelBuilder);
        }
    }
}
