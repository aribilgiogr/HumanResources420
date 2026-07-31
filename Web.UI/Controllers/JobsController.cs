using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using Core.Concretes.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.UI.Controllers
{
    public class JobsController(IJobPostingService jobPostingService, UserManager<AppUser> userManager) : Controller
    {
        public async Task<IActionResult> Index(string? company = null)
        {
            return View(await jobPostingService.GetAllAsync(company));
        }

        public async Task<IActionResult> Detail(string id)
        {
            var job = await jobPostingService.GetByIdAsync(id);
            if (job == null) return NotFound();
            return View(job);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var user = await userManager.GetUserAsync(User);
            if (user != null && user.UserRole == UserType.Employer) return View();
            return Forbid();
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobPostingCreateDto model)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null || user.UserRole == UserType.Candidate) return Forbid();

            if (ModelState.IsValid)
            {
                var result = await jobPostingService.AddAsync(model);

                if (result.IsSuccess)
                {
                    return RedirectToAction("index");
                }
                foreach (var e in result.Errors!)
                {
                    ModelState.AddModelError(string.Empty, e);
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Edit()
        {
            var user = await userManager.GetUserAsync(User);
            if (user != null && user.UserRole == UserType.Employer) return View();
            return Forbid();
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(JobPostingUpdateDto model)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null || user.UserRole == UserType.Candidate) return Forbid();

            if (ModelState.IsValid)
            {
                var result = await jobPostingService.SetAsync(model);

                if (result.IsSuccess)
                {
                    return RedirectToAction("detail", new { id = model.Id });
                }
                foreach (var e in result.Errors!)
                {
                    ModelState.AddModelError(string.Empty, e);
                }
            }
            return View(model);
        }
    }
}
