using System.Security.Claims;
using ItAcademy.Database;
using ItAcademy.Database.Entities;
using ItAcademy.MVC.Models;
using ItAcademy.Services.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace ItAcademy.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model, CancellationToken token=default)
        {
            if (await _userService.CheckIsEmailRegisteredAsync(model.Email, token) && 
                await _userService.CheckPassword(model.Email, model.Password, token))
            {
            var userRole = await _userService.GetUserRoleByEmailAsync(model.Email, token);

            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim(ClaimTypes.Name, model.Email),
                    new Claim(ClaimTypes.Role, userRole),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");
            }
            
            ModelState.AddModelError("","Incorrect Email or Password");
            return View(model);
        }

        [HttpPost]
        public async Task<bool> CheckEmail(string email, CancellationToken token = default)
        {
            return !(await _userService.CheckIsEmailRegisteredAsync(email, token));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel model, CancellationToken token = default)
        {
            if (await _userService.CheckIsEmailRegisteredAsync(model.Email, token))
            {
                ModelState.AddModelError(nameof(model.Email), "Email has been registered already");
                return View();
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _userService.RegisterUserAsync(model.Email, model.Password, token);
            var userRole = await _userService.GetUserRoleByEmailAsync(model.Email, token);

            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim(ClaimTypes.Name, model.Email),
                    new Claim(ClaimTypes.Role, userRole),
                };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Home");
        }
    }
}
