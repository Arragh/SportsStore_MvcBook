using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static SportsStore_MvcBook.Models.Cart;

namespace SportsStore_MvcBook.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [BindNever]
        public bool Shipped { get; set; }

        [Required(ErrorMessage = "Введите имя пользователя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите первую строку адреса")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Укажите ваш город")]
        public string City { get; set; }

        [Required(ErrorMessage = "Укажите область")]
        public string Area { get; set; }
        public string Zip { get; set; }

        [Required(ErrorMessage = "Введите название страны")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
