using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.UI.Models;

namespace Web.UI.Controllers
{

    public class AccountController(IAuthService auth) : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Logout()
        {
            await auth.LogoutAsync();
            return RedirectToAction("index", "home");
        }

        public IActionResult Login(string? returnUrl) => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto model, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                var reply = await auth.LoginAsync(model);
                if (reply.IsSuccess) return Redirect(returnUrl ?? "/");

                if (reply.Errors != null)
                {
                    foreach (var e in reply.Errors!)
                    {
                        ModelState.AddModelError(string.Empty, e);
                    }
                }
            }
            return View(model);
        }

        public IActionResult Register() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var reply = await auth.RegisterAsync(model);
                if (reply.IsSuccess) return RedirectToAction("login");

                if (reply.Errors != null)
                {
                    foreach (var e in reply.Errors!)
                    {
                        ModelState.AddModelError(string.Empty, e);
                    }
                }
            }
            return View(model);
        }

        public IActionResult RegisterCompany() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterCompany(RegisterCompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var reply = await auth.RegisterAsync(model.UserInfo, model.CompanyInfo);
                if (reply.IsSuccess) return RedirectToAction("login");

                if (reply.Errors != null)
                {
                    foreach (var e in reply.Errors!)
                    {
                        ModelState.AddModelError(string.Empty, e);
                    }
                }
            }
            return View(model);
        }
    }
}
