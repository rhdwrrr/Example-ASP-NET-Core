using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OrigamiEdu.Helper;
using OrigamiEdu.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using OrigamiEdu.Repository;

namespace OrigamiEdu.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class KabupatenKotaController : Controller
    {
        private readonly Context _context;
        private readonly ILogger<KabupatenKotaController> logger;
        private readonly KabupatenKotaRepository kabupatenKotaRepository;
        private readonly ProvinsiRepository provinsiRepository;

        [TempData]
        public string message { get; set; }

        public KabupatenKotaController
        (Context context, ILogger<KabupatenKotaController> logger, KabupatenKotaRepository kabupatenKotaRepository, ProvinsiRepository provinsiRepository)
        {
            _context = context;
            this.logger = logger;
            this.kabupatenKotaRepository = kabupatenKotaRepository;
            this.provinsiRepository = provinsiRepository;
        }
        
        public async Task<IActionResult> index()
        {
            return View(await kabupatenKotaRepository.readAll());
        }
        
        public async Task<IActionResult> tambah()
        {
            var provinsi = await provinsiRepository.readAll();

            ViewBag.comboProvinsi = provinsi.Select(p => new SelectListItem{
                    Text = p.provinsi,
                    Value = p.ID.ToString()
                }).OrderBy(p => p.Text);
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> tambah(KabupatenKota kab)
        {
            if(ModelState.IsValid)
            {
                var provinsi = await provinsiRepository.readOneByID(kab.mst_primaryProvinsi);
                if(provinsi == null)
                {
                    ModelState.AddModelError("mst_primaryProvinsi", "Data tidak valid!");
                }
                else{
                    try{
                        if(kab.kabupatenKota.Contains(';'))
                        {
                            string[] splitted = kab.kabupatenKota.Split(';');
                            
                            var added = string.Empty;
                            var state = false;
                            foreach (var str in splitted)
                            {
                                if(string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                                {
                                    state = true;
                                    continue;
                                }
                                if(!(await kabupatenKotaRepository.add(new KabupatenKota{
                                        ID = new Guid(),
                                        kabupatenKota = str.Trim(),
                                        fkProvinsi = provinsi
                                    }))
                                ){
                                    if(!(string.IsNullOrEmpty(added))){
                                        added.Remove(added.Length - 1, 1);
                                    }
                                    state = false;
                                    break;
                                }
                                else{
                                    added += $" {str},";
                                    state = true;
                                    continue;
                                }
                            }

                            if(!state)
                            {
                                if(string.IsNullOrEmpty(added))
                                {
                                    ModelState.AddModelError("", "Terjadi kesalahan, pastikan data telah terisi dengan benar!");
                                }
                                else{
                                    ModelState.AddModelError("", $"Terjadi kesalahan, pastikan data telah terisi dengan benar! Kabupaten{added} telah berhasil disimpan!");
                                }
                            }else{
                                message = "Data berhasil disimpan";
                                return RedirectToAction(nameof(index));
                            }
                        }
                        else
                        {
                            if(!(await kabupatenKotaRepository.add(new KabupatenKota{
                                    ID = new Guid(),
                                    kabupatenKota = kab.kabupatenKota.Trim(),
                                    fkProvinsi = provinsi
                                }))
                            ){
                                ModelState.AddModelError("", "Terjadi kesalahan, pastikan data telah terisi dengan benar!");
                            }
                            else{
                                message = "Data berhasil disimpan";
                                return RedirectToAction(nameof(index));
                            }
                        }    
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", $"{e.Message}");
                        // return RedirectToAction("index", new{Area = "Administrator", message = });
                    }
                }
            }
            
            ViewBag.comboProvinsi = _context.Provinsis.Select(p => new SelectListItem{
                Text = p.provinsi,
                Value = p.ID.ToString(),
                Selected = p.ID.ToString() == kab.mst_primaryProvinsi ? true : false
            }).OrderBy(p => p.Text);
            return View(kab);
        }
        
        [HttpGet]
        public async Task<IActionResult> edit(string ID)
        {
            try
            {
                var result = await kabupatenKotaRepository.readOneByID(ID);

                var provinsi = await provinsiRepository.readAllByID(result.mst_primaryProvinsi);

                ViewBag.comboProvinsi = provinsi.Select(p => new SelectListItem{
                    Text = p.provinsi,
                    Value = p.ID.ToString(),
                    Selected = p.selected
                }).OrderBy(p => p.Text);

                return View(result);
            }
            catch (Exception e)
            {
                message = e.Message;
                return RedirectToAction(nameof(index));
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> edit(KabupatenKota kab)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var provinsi = await provinsiRepository.readOneByID(kab.mst_primaryProvinsi);
                    if(provinsi == null)
                    {
                        ModelState.AddModelError("mst_primaryProvinsi", "Data tidak valid!");
                    }
                    else{
                        if(kab.kabupatenKota.Contains(';'))
                        {
                            ModelState.AddModelError("kabupatenKota", "Penggunaan semicolon dilarang!");
                        }
                        else{
                            if(!(await kabupatenKotaRepository.edit(new KabupatenKota{
                                ID = kab.ID,
                                kabupatenKota = kab.kabupatenKota,
                                fkProvinsi = provinsi
                            }))
                            ){
                                ModelState.AddModelError("", "Terjadi kesalahan, pastikan data telah terisi dengan benar!");
                            }else{
                                message = "Data berhasil disimpan";
                                return RedirectToAction(nameof(index));                    
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", $"{e.Message}");
                }
            }

            ViewBag.comboProvinsi = _context.Provinsis.Select(p => new SelectListItem{
                Text = p.provinsi,
                Value = p.ID.ToString(),
                Selected = p.ID.ToString() == kab.mst_primaryProvinsi ? true : false
            }).OrderBy(p => p.Text);

            return View(kab);
        }
        
        public async Task<IActionResult> hapus(string ID)
        {
            // ===================== DELETE KABUPATEN ====================== //
            try
            {
                if(!(await kabupatenKotaRepository.delete(_context.KabupatenKotas.FirstOrDefault(k => k.ID.ToString() == ID)))
                ){
                    message = "Terjadi kesalahan, gagal menyimpan!";
                    return RedirectToAction(nameof(index));
                }
                message = "Berhasil menyimpan";
                return RedirectToAction(nameof(index));
            }
            catch (Exception e)
            {
                message = e.Message;
                return RedirectToAction(nameof(index));
            }
            // ================= END DELETE KABUPATEN ======================== //
        }

        public async Task<IActionResult> dihapus()
        {
            return View(await kabupatenKotaRepository.readKabupatenKotaDumpsAsync());
        }

        public async Task<IActionResult> pulihkan(string ID)
        {
            try
            {
                if(!(await kabupatenKotaRepository.recoverKabupatenKota(_context.kabupatenKotaDumps.FirstOrDefault(i => i.ID.ToString() == ID))))
                {
                    message = "Terjadi kesalahan!";
                    return RedirectToAction(nameof(dihapus));
                }
                message = "Kabupaten/Kota berhasil dipulihkan!";
                return RedirectToAction(nameof(index));
            }
            catch (System.Exception e)
            {
                message = e.Message;
                return RedirectToAction(nameof(dihapus));
            }
        }
    }
}