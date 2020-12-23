using Microsoft.AspNetCore.Mvc;
using SportsStore_MvcBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore_MvcBook.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Checkout() => View(new Order());
    }
}
