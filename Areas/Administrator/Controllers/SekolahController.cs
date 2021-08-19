using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OrigamiEdu.Models;
using OrigamiEdu.Repository;

namespace OrigamiEdu.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SekolahController : Controller
    {
        private readonly Context _context;
        private readonly ILogger<SekolahController> logger;
        private readonly SekolahRepository sekolahRepository;
        private readonly KabupatenKotaRepository kabupatenKotaRepository;
        private readonly ProvinsiRepository provinsiRepository;

        [TempData]
        public string message { get; set; }
        public SekolahController(Context context, ILogger<SekolahController> logger, SekolahRepository sekolahRepository, KabupatenKotaRepository kabupatenKotaRepository, ProvinsiRepository provinsiRepository)
        {
            _context = context;
            this.logger = logger;
            this.sekolahRepository = sekolahRepository;
            this.kabupatenKotaRepository = kabupatenKotaRepository;
            this.provinsiRepository = provinsiRepository;
        }
        
        public async Task<IActionResult> index()
        {
            ViewBag.dataSch = await sekolahRepository.readAll();

            var kat = await sekolahRepository.readKategoriSekolahsAsync();
            ViewBag.dataKtg = kat;

            ViewBag.countAll = await sekolahRepository.countAllSekolah();
            
            return View();
        }
        
        public IActionResult tambah()
        {
            ViewBag.comboProvinsi = _context.Provinsis.Select(p => new SelectListItem{
                Text = p.provinsi,
                Value = p.ID.ToString()
            }).OrderBy(t => t.Text);

            ViewBag.comboKategori = _context.kategoriSekolahs.Select(kt => new SelectListItem{
                Text = kt.namaKategori,
                Value = kt.ID.ToString()
            }).OrderBy(t => t.Text);

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> tambah(Sekolah sch)
        {
            if(ModelState.IsValid)
            {
                var prv = await provinsiRepository.readOneByID(sch.mst_primaryProvinsi);
                var kbpt = await kabupatenKotaRepository.readSingle(sch.mst_fkKab);
                var kat = await sekolahRepository.readKategoriSekolahByID(sch.mst_primaryKtg);
                kbpt.mst_primaryProvinsi = null;
                if(prv == null || kbpt == null || kat == null)
                {
                    ModelState.AddModelError("mst_primaryProvinsi", "Data tidak valid");
                }
                else{
                    try
                    {
                        if(sch.sekolah.Contains(';'))
                        {
                            string[] split = sch.sekolah.Split(';');
                            var added = "";
                            var state = false;
                            foreach (var item in split)
                            {
                                if(string.IsNullOrEmpty(item) || string.IsNullOrWhiteSpace(item))
                                {
                                    state = true;
                                    continue;
                                }

                                if(!(await sekolahRepository.addSekolah(new Sekolah{
                                    ID = new Guid(),
                                    sekolah = item.Trim(),
                                    fkKabupatenKota = kbpt,
                                    fkKategoriSekolah = kat
                                }))){
                                    state = false;
                                    if(!(string.IsNullOrEmpty(added)))
                                    {
                                        added.Remove(added.Length - 1, 1);
                                    }
                                    break;
                                }else{
                                    state = true;
                                    added += $" {item},";
                                    continue;
                                }
                            }
                            if(!state)
                            {
                                if(string.IsNullOrEmpty(added))
                                {
                                    ModelState.AddModelError("", $"Terjadi kesalahan, pastikan data telah terisi dengan benar!");
                                }else{
                                    ModelState.AddModelError(string.Empty, $"Terjadi kesalahan, pastikan data telah terisi dengan benar!, Sekolah{added} telah berhasil ditambahkan");
                                }
                            }else{
                                message = "Data berhasil ditambahkan!";
                                return RedirectToAction(nameof(index));
                            }
                        }
                        else{
                            if(!(await sekolahRepository.addSekolah(new Sekolah{
                                ID = new Guid(),
                                sekolah = sch.sekolah.Trim(),
                                fkKabupatenKota = kbpt,
                                fkKategoriSekolah = kat
                            })))
                            {
                                ModelState.AddModelError("", $"Terjadi kesalahan, pastikan data telah terisi dengan benar!");
                            }else{
                                message = "Data tersimpan";
                                return RedirectToAction(nameof(index));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e.Message);
                    }
                }
            }

            ViewBag.comboProvinsi = _context.Provinsis.Select(p => new SelectListItem{
                Text = p.provinsi,
                Value = p.ID.ToString()
            }).OrderBy(t => t.Text);

            ViewBag.comboKategori = _context.kategoriSekolahs.Select(kt => new SelectListItem{
                Text = kt.namaKategori,
                Value = kt.ID.ToString()
            }).OrderBy(t => t.Text);

            return View(sch);
        }

        public async Task<IActionResult> edit(string ID)
        {
            try
            {
                var result = await sekolahRepository.readOneByID(ID);
                var kategori = await sekolahRepository.readKategoriSekolahsAsync(result.mst_primaryKtg);
                var prov = await provinsiRepository.readAllByID(result.mst_primaryProvinsi);
                var kabupatenKota = await kabupatenKotaRepository.readByProvinsi(result.mst_primaryProvinsi, result.mst_fkKab);

                ViewBag.comboProvinsi = prov.OrderBy(p => p.provinsi).Select(p => new SelectListItem{
                    Text = p.provinsi,
                    Value = p.ID.ToString(),
                    Selected = p.selected
                });

                ViewBag.comboKabupaten = kabupatenKota.OrderBy(k => k.kabupatenKota).Select(k => new SelectListItem{
                    Text = k.kabupatenKota,
                    Value = k.ID.ToString(),
                    Selected = k.selected
                });

                ViewBag.kategori = kategori.OrderBy(kt => kt.namaKategori).Select(kt => new SelectListItem{
                    Text = kt.namaKategori,
                    Value = kt.ID.ToString(),
                    Selected = kt.selected
                });

                return View(result);
            }
            catch (System.Exception e)
            {
                message = e.Message;
                return RedirectToAction(nameof(index));
            }
            
        }
        
        [HttpPost]
        public async Task<IActionResult> edit(Sekolah sch)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var prv = await provinsiRepository.readOneByID(sch.mst_primaryProvinsi);
                    var kbpt = await kabupatenKotaRepository.readSingle(sch.mst_fkKab);
                    var kat = await sekolahRepository.readKategoriSekolahByID(sch.mst_primaryKtg);
                    kbpt.mst_primaryProvinsi = null;
                    if(sch.sekolah.Contains(';') || prv == null || kbpt == null || kat == null){
                        ModelState.AddModelError("", "Data tidak valid atau terdapat semicolon pada kolom Nama Sekolah!");
                    } 
                    else{
                        if(!(await sekolahRepository.editSekolah(new Sekolah{
                            ID = sch.ID,
                            sekolah = sch.sekolah.Trim(),
                            fkKabupatenKota = kbpt,
                            fkKategoriSekolah = kat
                        })))
                        {
                            ModelState.AddModelError(string.Empty, $"Terjadi kesalahan, pastikan data telah terisi dengan benar!");
                        }else{
                            message = "Data berhasil disimpan!";
                            return RedirectToAction(nameof(index));
                        }
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, $"{e.Message}");
                }                    
            }

            ViewBag.comboProvinsi = _context.Provinsis.OrderBy(p => p.provinsi).Select(p => new SelectListItem{
                Text = p.provinsi,
                Value = p.ID.ToString(),
                Selected = p.ID.ToString() == sch.mst_primaryProvinsi
            });

            ViewBag.comboKabupaten = (from k in _context.KabupatenKotas join p in _context.Provinsis on k.fkProvinsi.ID equals p.ID where p.ID.ToString() == sch.mst_primaryProvinsi select new SelectListItem{
                Text = k.kabupatenKota,
                Value = k.ID.ToString(),
                Selected = k.ID.ToString() == sch.mst_fkKab 
            });

            ViewBag.kategori = _context.kategoriSekolahs.OrderBy(kt => kt.namaKategori).Select(kt => new SelectListItem{
                Text = kt.mst_namaKtg,
                Value = kt.ID.ToString(),
                Selected = kt.ID.ToString() == sch.mst_primaryKtg
            });
            
            return View(sch);    
        }
        
        public async Task<IActionResult> hapusSekolah(string ID)
        {
            try
            {
                if(!(await sekolahRepository.deleteSekolah(_context.Sekolahs.FirstOrDefault(s => s.ID.ToString() == ID))))
                {
                    message = "Terjadi kesalahan!, Gagal menghapus";
                    return RedirectToAction(nameof(index));
                }
                
                message = "Data berhasil dihapus";
            }
            catch (Exception e)
            {
                message =  e.Message;
            }
            return RedirectToAction(nameof(index));
        }

        public async Task<IActionResult> dihapus()
        {
            return View(await sekolahRepository.readSekolahDumpsAsync());
        }

        public async Task<IActionResult> pulihkan(string ID){
            try
            {
                if(!(await sekolahRepository.recoverSekolah(_context.sekolahDumps.FirstOrDefault(i => i.ID.ToString() == ID))))
                {
                    message = "Terjadi kesalaham, gagal memulihkan!";
                    return RedirectToAction(nameof(index));
                }
                message = "Sekolah berhasil dipulihkan!";
                return RedirectToAction(nameof(index));
            }
            catch (System.Exception e)
            {
                message = e.Message;
                return RedirectToAction(nameof(index));
            }
        }

        // ================================= JSON COMBOBOX =================================== //
        
        [HttpPost]
        public JsonResult comboProv(string ID)
        {
            var prov = _context.Provinsis.OrderBy(p => p.provinsi).Select(p => new Provinsi{
                mst_primary = p.ID.ToString(),
                mst_namaProvinsi = p.provinsi
            });
            
            return Json(prov);
        }
        
        [HttpPost]
        public async Task<JsonResult> comboKab(string ID)
        {
            var data = await kabupatenKotaRepository.readByProvinsi(ID, string.Empty);
            var results = data.Select(i => new {
                key = i.ID.ToString(),
                kabupatenKota = i.kabupatenKota,
                prim = i.ID.ToString()
            });
            return Json(results.AsQueryable());
        }

        [HttpPost]
        public JsonResult comboKategori(string ID)
        {
            var oKat = _context.kategoriSekolahs.OrderBy(i => i.namaKategori).Select(i => new KategoriSekolah{
                mst_primary = i.ID.ToString(),
                mst_namaKtg = i.namaKategori
            });

            return Json(oKat);
        }
            




        // =========================================== KATEGORI ===================================== //
        public IActionResult tambahKategori()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> tambahKategori(KategoriSekolah kategori)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    if(kategori.namaKategori.Contains(';'))
                    {
                        var splitted = kategori.namaKategori.Split(';');

                        var added = "";
                        var state = false;
                        foreach (var item in splitted)
                        {
                            if(string.IsNullOrWhiteSpace(item) || string.IsNullOrEmpty(item))
                            {
                                state = true;
                                continue;
                            }
                            if(!(await sekolahRepository.addKategoriSekolah(new KategoriSekolah{
                                ID = new Guid(),
                                namaKategori = item.Trim()
                            })))
                            {
                                state = false;
                                if(!(string.IsNullOrEmpty(added)))
                                {
                                    added.Remove(added.Length - 1, 1);
                                }
                                break;
                            }else{
                                state = true;
                                continue;
                            }
                        }
                        if(!state)
                        {
                            if(string.IsNullOrEmpty(added))
                            {
                                ModelState.AddModelError(string.Empty, $"Terjadi kesalahan, pastikan data telah terisi dengan benar!");
                            }else{
                                 ModelState.AddModelError(string.Empty, $"Terjadi kesalahan, pastikan data telah terisi dengan benar! Kategori{added} telah ditambahkan");
                            }
                        }else{
                            message = "Data berhasil disimpan";
                            return RedirectToAction(nameof(index));
                        }
                    }
                    else{
                        if(!(await sekolahRepository.addKategoriSekolah(new KategoriSekolah{
                            ID = new Guid(),
                            namaKategori = kategori.namaKategori.Trim()
                        }))){
                            ModelState.AddModelError(string.Empty, $"Terjadi kesalahan, pastikan data telah terisi dengan benar!");
                        }else{
                            message = "Data berhasil disimpan";
                            return RedirectToAction(nameof(index));
                        }
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, $"{e.Message}");
                }
            }
            return View(kategori);
        }

        public async Task<IActionResult> editKategori(string ID)
        {
            try
            {
                var kat = sekolahRepository.readKategoriSekolahByID(ID);

                return View(await kat);
            }
            catch (Exception e)
            {
                message = e.Message;
                return RedirectToAction(nameof(index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> editKategori(KategoriSekolah kategoriSekolah)
        {
            if(ModelState.IsValid)
            {
                if(kategoriSekolah.mst_namaKtg.Contains(';'))
                {
                    ModelState.AddModelError("namaKategori", "Penggunaan semicolon dilarang!");
                }
                else{
                    try
                    {
                        if(!(await sekolahRepository.editKategoriSekolah(new KategoriSekolah{
                            ID = kategoriSekolah.ID,
                            namaKategori = kategoriSekolah.namaKategori.Trim()
                        }))){
                             ModelState.AddModelError(string.Empty, $"Terjadi kesalahan, pastikan data telah terisi dengan benar!");
                        }else{
                            message = "Data berhasil disimpan!";
                            return RedirectToAction(nameof(index));
                        }
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e.Message);
                    }
                } 
            }
            return View(kategoriSekolah);
        }   

        public async Task<IActionResult> hapusKategori(string ID)
        {
            try
            {
                if(!(await sekolahRepository.deleteKategoriSekolah(_context.kategoriSekolahs.FirstOrDefault(i => i.ID.ToString() == ID))))
                {
                    message = "Terjadi kesalahan, gagal menghapus!";
                    return RedirectToAction(nameof(index));
                }else{
                    message = "Data berhasil dihapus";
                    return RedirectToAction(nameof(index));
                }
            }
            catch (Exception e)
            {
                message = e.Message;
                return RedirectToAction(nameof(index));
            }
        }

        // ==================================== END KATEGORI ======================================== //
    }
}