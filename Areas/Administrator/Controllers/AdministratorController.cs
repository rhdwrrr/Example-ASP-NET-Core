using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrigamiEdu.Models;

namespace OrigamiEdu.Areas.Administrator.Controllers{

    [Area("Administrator")]
    [Authorize]
    public class AdministratorController : Controller
    {
        private readonly Context _context;

        public AdministratorController(Context contex)
        {
            _context = contex;
        }
        public IActionResult index()
        {
            return View();
        }
        
        
    }
}