using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsStore_MvcBook.Models.Identity;
using SportsStore_MvcBook.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore_MvcBook.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Login(string returnUrl) => View(new LoginModel { ReturnUrl = returnUrl });

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByNameAsync(model.Name);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
                    {
                        return Redirect(model?.ReturnUrl ?? "Admin/Index");
                    }
                }
            }

            ModelState.AddModelError("", "Неверные имя пользователя и/или пароль");
            return View(model);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

    }
}
