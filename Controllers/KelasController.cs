/* using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrigamiEdu.Helper;
using OrigamiEdu.Models;
using OrigamiEdu.Repository;
using OrigamiEdu.Services;

namespace OrigamiEdu.Controllers
{
    [Authorize]
    public class KelasController : Controller
    {
        private readonly Context context;
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly KelasRepository kelasRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ILogger<KelasController> logger;
        private bool isAccCode { get; set; }

        [TempData]
        public string message { get; set; }


        public KelasController(Context context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, KelasRepository kelasRepository, IHttpContextAccessor httpContextAccessor,ILogger<KelasController> logger)
        {
            this.context = context;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.kelasRepository = kelasRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.logger = logger;
        }

        public async Task<IActionResult> index()
        {
            ViewBag.Count = await kelasRepository.countKelasAsync();
            
            return View(await kelasRepository.getKelasAsync());
        }

        public async Task<IActionResult> index(string ID)
        {
            ViewBag.Count = await kelasRepository.countKelasAsync();
            
            return View(await kelasRepository.getKelasAsync());
        }

        public IActionResult tambah()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> tambah([Bind("nama", "kreator", "userGuide", "isPrivate")] kelas _kelas)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _kelas.fkCreator = await userManager.FindByNameAsync(_kelas.kreator);
                    _kelas.createdDate = DateTime.Now;
 
                    if (!(await kelasRepository.addKelasAsync(_kelas)))
                    {
                        throw new System.Exception("Terjadi kesalahan, Gagal menambahkan kelas.");
                    }
                    else
                    {
                        message = "Kelas berhasil ditambahkan";
                        return RedirectToAction(nameof(index));
                    }
                }
                catch (System.Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            ViewBag.idKelas = _kelas.ID;
            return View(_kelas);
        }

        [HttpPost]
        public async Task<IActionResult> req(string keyKelas, bool byCode)
        {
            try
            {
                var kelasObject = await kelasRepository.isKelasAvailable(keyKelas);

                if(!kelasObject)
                {
                    throw new Exception("Kelas tidak tersedia, periksa kembali kode yang anda masukkan");
                }else
                {
                    isAccCode = byCode;
                    return RedirectToAction(nameof(gabung), new{_kelas = kelasObject});
                }
                // var userTarget = httpContextAccessor.HttpContext.User.Identity.Name.ToString();                  
            }
            catch (System.Exception e)
            {
                message = e.Message;
                return RedirectToAction(nameof(index));
            }
        }   

        [HttpGet]
        public async Task<IActionResult> gabung(string ID)
        {
            var _kelas = await kelasRepository.getKelasSingleAsync(ID);


            var kelasViewObject = new joinGrupView{
                IDKelas = _kelas.ID,
                namaKelas = _kelas.nama,
                userGuide = _kelas.userGuide,
                createdDate = _kelas.createdDate,
                isAccesingByCode = isAccCode,
                isArchived = _kelas.isArchived,
                isPrivate = _kelas.isPrivate,
                kreator = _kelas.kreator
            };
            
            return View(kelasViewObject);
        }

        [HttpPost]
        public async Task<IActionResult> gabung([Bind("IDKelas", "isAgree")] joinGrupView _model, bool codeAcc)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var actor = await userManager.FindByNameAsync(httpContextAccessor.HttpContext.User.Identity.Name);
                    var dtNow = getDateTime.getUTCTime(DateTime.Now);
                    var _kelas = await kelasRepository.getKelasSingleAsync(_model.IDKelas);

                    if(( _kelas == null))
                    {
                        message = "Terjadi kesalahan, silahkan coba kembali";
                        return RedirectToAction(nameof(index));
                    }
                    else
                    {
                        if(codeAcc)
                        {
                            var assign = await kelasRepository.assignMemberToKelasAsync(_kelas, actor, false);
                            if(!assign)
                            {
                                message = "Terjadi kesalahan, silahkan coba kembali";
                                return RedirectToAction(nameof(index));
                            }
                            else
                            {

                            }
                        }
                    }

                }
                catch (System.Exception)
                {
                    
                    throw;
                }
            }
        }
    }
} */