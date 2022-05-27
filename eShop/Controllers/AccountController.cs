using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using eShop.Models;
using eShop.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eShop.Controllers
{
    public class AccountController : Controller
    {
        // GET
        private readonly ShopContext _db;

        public AccountController(ShopContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {

                User user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    RoleId = 2
                };


                await _db.Users.AddAsync(user);
                await _db.SaveChangesAsync();
                return RedirectToAction("Login");
            }

            return View(model);
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _db.Users.Include(p => p.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email &&
                                              u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Product");
                }

                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }

            return View(model);
        }


        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            ClaimsIdentity id = new ClaimsIdentity(
                claims,
                "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}