using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrigamiEdu.Helper;
using OrigamiEdu.Models;

namespace OrigamiEdu.Controllers
{
    public class AkunController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        [TempData]
        public string message { get; set; }

        // private readonly UserManager<IdentityUser> _userManager;
        // private readonly SignInManager<IdentityUser> _signInManager;

        public AkunController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            // _userManager = userManager;
            // _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Daftar()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Daftar([Bind("email", "username", "password", "confirmPass", "sex")] signUpModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    // var customdate = getDateTime.getUTCTime(DateTime.Now);
                    var user = new AppUser{
                        UserName = model.username,
                        Email = model.email,
                        joinDate = DateTime.Now,
                        gender = model.sex == "Male" ? "M" : "F"
                    };
                    var result = await userManager.CreateAsync(user, model.password);
                    if(result.Succeeded)
                    {
                        /* ========== SETUP TYPE: ==========
                        [0] - completed
                        [1] - birthday - sekolah 
                        ==================================== */
                        // var roleResult = await userManager.AddToRoleAsync(user, "User");
                        // if(roleResult.Succeeded){
                            if(signInManager.IsSignedIn(User) && User.IsInRole("Developer Master"))
                            {
                                return RedirectToAction("index", "Users", new{Area = "Administrator"});
                            }
                            // await signInManager.SignInAsync(user, isPersistent:false);
                            TempData["message"] = "Akun telah berhasil didaftarkan";
                            return RedirectToAction("index", "home");
                        // }
                    }
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                catch (Exception e)
                {
                    message = e.Message;
                    return View(model);
                }
                
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Keluar()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Masuk(string returnUrl = null)
        {
            // var model = new UserInfo{ ReturnUrl = returnUrl};
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Masuk(signInModel modelUser, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(modelUser.username,modelUser.password,modelUser.rememberMe, false);

                if(result.Succeeded)
                {
                    if(!(string.IsNullOrEmpty(returnUrl)) && Url.IsLocalUrl(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }else{
                        return RedirectToAction("index", "home");
                    }
                }

                ModelState.AddModelError(string.Empty, "Nama Pengguna atau Kata Sandi salah!");
            }
            return View(modelUser);
        }

        public async Task<IActionResult> isEmailValid(string email)
        {
            string[] allowedDomain = new string[] {"gmail.com", "protonmail.com", "pm.me", "outlook.com", "hotmail.com"};

            if(string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(email))
            {
                return Json("Mohon isi alamat surel Anda");
            }

            var dhawudad = "fardi@mail.com";


            string[] getDomain = email.Split('@');

            var domainValid = false;
            foreach (var item in allowedDomain)
            {
                if(getDomain[1].ToLower() == item.ToLower()){domainValid = true;break;}
            }
            if(!domainValid){
                return Json($"Saat ini domain alamat surel anda ({getDomain[1]}) belum didukung");
            }

            var user = await userManager.FindByEmailAsync(email);

            if(user == null && domainValid) return Json(true);
            
            return Json($"Alamat surel {email} telah dipakai");
        }

        public async Task<IActionResult> isUsernameValid(string username)
        {
            Regex regex = new Regex(@"(?!.*\.\.)(?!.*\.$)[^\W][\w.]{0,15}");
            Match match = regex.Match(username);

            if(match.Success)
            {
                var user = await userManager.FindByNameAsync(username);
                if(user == null)
                {
                    return Json(true);
                }
                return Json($"Nama pengguna '{username}' telah dipakai");
            }
            
            return Json($"Nama pengguna '{username}' tidak valid");

        }

        public IActionResult aksesDitolak()
        {
            return View();
        }
    }
}