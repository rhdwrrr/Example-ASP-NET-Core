using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrigamiEdu.Models;
using System.Linq;

namespace OrigamiEdu.Areas.Administrator.Controllers
{
    // [Authorize(Roles = "Developer Master")]
    [Area("Administrator")]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly Context context;

        public UsersController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, Context context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.context = context;
        }

        public async Task<IActionResult> index()
        {
            var _users = await userManager.Users.ToListAsync();
            return View(_users);
        }
    }
}