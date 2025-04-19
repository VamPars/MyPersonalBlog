using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyPersonalBlog.Core.Interfaces;
using MyPersonalBlog.DataLayer.DTOS;

namespace MyPersonalBlog.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUser _UserSevices;
        public AccountController(IUser UserSevices)
        {
            _UserSevices = UserSevices;
        }
        [HttpGet]
        [Route("/Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("/Register")]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            if (registerViewModel.Password != registerViewModel.RePassword)
            {
                ModelState.AddModelError("Password", "رمز عبور با تکرار آن مطابقت ندارد");
                return View(registerViewModel);
            }
            _UserSevices.RegisterUser(registerViewModel);
            return Redirect("/Account/Login");
        }
   
        [HttpGet]
        [Route("/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("/Login")]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            //Login Proccess
            if (true)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginViewModel.UserName)
                };
                var claimsIdentity = new ClaimsIdentity(
                    claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var pricinpals = (CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                //HttpContext.SignInAsync(claimsIdentity, pricinpals);
            }
            return View();
        }

        [Route("/LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return View();
        }

    }
}
