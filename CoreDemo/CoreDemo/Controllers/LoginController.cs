using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _singInManager;

        public LoginController(SignInManager<AppUser> singInManager)
        {
            _singInManager = singInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSingInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _singInManager.PasswordSignInAsync(p.username, p.password, false, true);//false değeri çerezlere hatırlamamak için.--true değeri 5 defa yanlı şgirişte kilitlenecek
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _singInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }


        public IActionResult AccessDenies()
        {
            return View();
        }














        //[HttpPost]
        //public async Task<IActionResult> Index(Writer w)
        //{
        //    Context c = new Context();
        //    var dataValue = c.Writers.FirstOrDefault(x => x.WriterEmail == w.WriterEmail && x.WriterPassword == w.WriterPassword);

        //    if (dataValue != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name,w.WriterEmail)
        //        };
        //        var userIdentity = new ClaimsIdentity(claims, "a");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
        //        await HttpContext.SignInAsync(principal);

        //        return RedirectToAction("Index", "Dashboard");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}