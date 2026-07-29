using Core.Abstracts.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Web.UI.Controllers
{
    public class JobsController(IJobPostingService jobPostingService) : Controller
    {
        public async Task<IActionResult> Index(string? company = null)
        {
            return View(await jobPostingService.GetAllAsync(company));
        }
    }
}
