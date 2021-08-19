using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrigamiEdu.Models;

namespace OrigamiEdu.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    public class ForumController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly Context context;

        public ForumController(UserManager<AppUser> userManager, Context context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public IActionResult index()
        {
            return View();
        }
    }
}