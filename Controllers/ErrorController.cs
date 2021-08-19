using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OrigamiEdu.Controllers
{
    public class ErrorController : Controller
    {
        [AllowAnonymous]
        public IActionResult index(string errorString)
        {
            ViewBag.ErrInfo = errorString;
            return View();
        }
        
        [AllowAnonymous]
        public IActionResult notFound(string errorString)
        {
            ViewBag.ErrInfo = errorString;
            return View();
        }
    }
}