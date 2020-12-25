using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore_MvcBook.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Введите название товара")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Введите корректную цену")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Укажите категорию товара")]
        public string Category { get; set; }
    }
}
