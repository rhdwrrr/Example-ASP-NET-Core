using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrigamiEdu.Models;
using OrigamiEdu.Services;

namespace OrigamiEdu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context context;
        private readonly dateManagement dateManagement;
        public Int64 goobler = 9;

        public HomeController(ILogger<HomeController> logger, Context context, dateManagement dateManagement)
        {
            _logger = logger;
            this.context = context;
            this.dateManagement = dateManagement;
        }

        

        public IActionResult Index()
        {
            Console.WriteLine(DateTime.Now.ToString());
            TempData["Employee"] = context.Provinsis.ToList();
            ViewBag.UTCTime = dateManagement.getUTCTime(DateTime.Now).ToString("dd MMMM yyyy hh:mm 'GMT'z");
            ViewBag.UTCTime = DateTime.UtcNow;
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
