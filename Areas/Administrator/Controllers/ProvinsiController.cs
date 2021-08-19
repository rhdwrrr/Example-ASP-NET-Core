using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrigamiEdu.Helper;
using OrigamiEdu.Models;
using OrigamiEdu.Repository;

namespace OrigamiEdu.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Administrator")]
    public class ProvinsiController : Controller
    {
        private readonly Context _context;
        private readonly ProvinsiRepository provinsiRepository;

        [TempData]
        public string message { get; set; }

        public ProvinsiController(Context context, ProvinsiRepository provinsiRepository)
        {
            _context = context;
            this.provinsiRepository = provinsiRepository;
        }
        
        public async Task<IActionResult> index()
        {
            /* var data = (from p in _context.Provinsis select new Provinsi{
                mst_primary = p.ID.ToString(),
                mst_namaProvinsi = p.provinsi
            }).OrderBy(p => p.mst_namaProvinsi).ToList(); */
            var data = await provinsiRepository.readAll();
            return View(data.OrderBy(i => i.provinsi));
        }

        [HttpGet]
        public async Task<IActionResult> addOrEdit(string ID = "")
        {
            if(string.IsNullOrEmpty(ID))
            {
                return View(new Provinsi{ID = Guid.Empty});
            }
            else
            {
                var data = await provinsiRepository.readOneByID(ID);

                if(data == null)
                {
                    message = "Terjadi kesalahan, provinsi tidak tersedia";
                    return RedirectToAction(nameof(index));
                }
                return View(data);
            }
        }

        /* [HttpPost]
        public async Task<IActionResult> addOrEdit([Bind("ID", "nama")] Provinsi modProvinsi)
        {
            if(modProvinsi.ID == Guid.Empty)
            {
                if(modProvinsi.provinsi.Contains(';'))
                {
                    string[] splitted = modProvinsi.provinsi.Split(';');
                    string added = "";
                    var state = false;
                    foreach (var str in splitted)
                    {
                        if(string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                        {
                            state = true;
                            continue;
                        }

                        if(!(await provinsiRepository.add(new Provinsi{ID = new Guid(),provinsi = str.Trim()})))
                        {
                            if(!(string.IsNullOrEmpty(added)))
                            {
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
                        if(!(string.IsNullOrEmpty(added)))
                        {
                            ModelState.AddModelError(string.Empty, $"Terjadi kesalahan, pastikan data telah terisi dengan benar!, Provinsi{added} telah berhasil ditambahkan");
                        }else{
                            ModelState.AddModelError(string.Empty, $"Terjadi kesalahan, pastikan data telah terisi dengan benar!");
                        }
                    }else{
                        message = "Data Berhasil Disimpan";
                        // return RedirectToAction(nameof(index));
                    }
                }
                else{
                    if(!(await provinsiRepository.add(new Provinsi{ID = new Guid(),provinsi = modProvinsi.provinsi.Trim()}))
                    )
                    {
                        ModelState.AddModelError(string.Empty, "Terjadi kesalahan, pastikan data telah terisi dengan benar!");
                    }
                    else
                    {
                        message = "Data Berhasil Disimpan";
                        // return RedirectToAction(nameof(index));
                    }
                }
            }
            else
            {
                if(!(await provinsiRepository.edit(modProvinsi)))
                {
                    ModelState.AddModelError("", "Terjadi kesalaham, pastikan data telah terisi dengan benar!");
                }
                else{
                    message = "Data berhasil disimpan";
                    // return RedirectToAction(nameof(index));
                }
            }
        } */
        
        public IActionResult tambah(){
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> tambah(Provinsi prov)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    if(prov.provinsi.Contains(';'))
                    {
                        string[] splitted = prov.provinsi.Split(';');
                        string added = "";
                        var state = false;
                        foreach (var str in splitted)
                        {
                            if(string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                            {
                                state = true;
                                continue;
                            }

                            if(!(await provinsiRepository.add(new Provinsi{ID = new Guid(),provinsi = str.Trim()})))
                            {
                                if(!(string.IsNullOrEmpty(added)))
                                {
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
                            if(!(string.IsNullOrEmpty(added)))
                            {
                                ModelState.AddModelError(string.Empty, $"Terjadi kesalahan, pastikan data telah terisi dengan benar!, Provinsi{added} telah berhasil ditambahkan");
                            }else{
                                ModelState.AddModelError(string.Empty, $"Terjadi kesalahan, pastikan data telah terisi dengan benar!");
                            }
                        }else{
                            message = "Data Berhasil Disimpan";
                            return RedirectToAction(nameof(index));
                        }
                    }
                    else{
                        if(!(await provinsiRepository.add(new Provinsi{ID = new Guid(),provinsi = prov.provinsi.Trim()}))
                        )
                        {
                            ModelState.AddModelError(string.Empty, "Terjadi kesalahan, pastikan data telah terisi dengan benar!");
                        }
                        else
                        {
                            message = "Data Berhasil Disimpan";
                            return RedirectToAction(nameof(index));
                        }
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View(prov);
        }
        
        public async Task<IActionResult> edit(string ID)
        {

            var data = await provinsiRepository.readOneByID(ID);

            if(data == null)
            {
                message = "Terjadi kesalahan, provinsi tidak tersedia";
                return RedirectToAction(nameof(index));
            }
            return View(data);
        }
        
        [HttpPost]
        public async Task<IActionResult> edit(Provinsi prov)
        {
            if(ModelState.IsValid)
            {
                if(prov.provinsi.Contains(';'))
                {
                    ModelState.AddModelError("provinsi", "Penggunaan semicolon dilarang!");
                }
                else{
                    try
                    {
                        if(!(await provinsiRepository.edit(prov)))
                        {
                            ModelState.AddModelError("", "Terjadi kesalaham, pastikan data telah terisi dengan benar!");
                        }
                        else{
                            message = "Data berhasil disimpan";
                            return RedirectToAction(nameof(index));
                        }
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e.Message);
                        // return RedirectToAction("index", new{Area = "Administrator", message = });
                    }
                }
            }
            return View(prov);
        }

        
        public async Task<IActionResult> hapus(string ID)
        {
            try
            {
                if(!(await provinsiRepository.delete(_context.Provinsis.FirstOrDefault(p => p.ID.ToString() == ID)))
                )
                {
                    message = "Terjadi kesalahan, gagal menghapus!";
                    return RedirectToAction(nameof(index));
                }
                
                message = "Data berhasil dihapus";
                return RedirectToAction(nameof(index));
            }
            catch (Exception e)
            {
                message = e.Message;
                return RedirectToAction(nameof(index));
            }
        }

        public async Task<IActionResult> dihapus()
        {
            return View(await provinsiRepository.readProvinsiDumpsAsync());
        }

        public async Task<IActionResult> pulihkan(string ID)
        {
            try
            {
                if(!(await provinsiRepository.recover(_context.provinsiDumps.FirstOrDefault(i => i.ID.ToString() == ID))))
                {
                    message = "Terjadi kesalahan!";
                    return RedirectToAction(nameof(dihapus));
                }
                message = "Provinsi berhasil dipulihkan!";
                return RedirectToAction(nameof(index));
            }
            catch (System.Exception)
            {
                message = "Terjadi kesalahan!";
                return RedirectToAction(nameof(dihapus));
            }
        }
    }
}