using System;
using System.Collections.Generic;
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
    public class UniversitasController : Controller
    {
        private readonly Context context;
        private readonly ILogger<UniversitasController> logger;
        private readonly UniversitasRepository universitasRepository;
        private readonly ProvinsiRepository provinsiRepository;

        [TempData]
        public string message { get; set; }

        public UniversitasController(Context context, ILogger<UniversitasController> logger, UniversitasRepository universitasRepository, ProvinsiRepository provinsiRepository)
        {
            this.context = context;
            this.logger = logger;
            this.universitasRepository = universitasRepository;
            this.provinsiRepository = provinsiRepository;
        }
// ============================================================================================================== //
        public async Task<IActionResult> index()
        {
            ViewBag.Universitas = await universitasRepository.readUniversitasAsync();

            ViewBag.kategoriUniversitas = await universitasRepository.readKategoriUniversitas();

            ViewBag.countAll = await universitasRepository.countUniversitasAsync();
            return View();
        }

        public IActionResult tambahUniversitas()
        {
            ViewBag.comboKategori = context.kategoriUniversitas.OrderBy(kU => kU.katgUniv).Select(kU => new SelectListItem{
                Value = kU.ID.ToString(),
                Text = kU.katgUniv
            });

            ViewBag.comboProvinsi = context.Provinsis.OrderBy(p => p.provinsi).Select(p => new SelectListItem{
                Text = p.provinsi,
                Value = p.ID.ToString()
            });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> tambahUniversitas(Universitas _universitas)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var ktg = await universitasRepository.readSingleKategoriUniversitas(_universitas.mst_fkKatUniv);
                    var prv = await provinsiRepository.readOneByID(_universitas.mst_fkProvinsi);
                    if(ktg == null || prv == null)
                    {
                        ModelState.AddModelError("", "Terjadi kesalahan, data tidak valid!");
                    }
                    else{
                        if(_universitas.universitas.Contains(';'))
                        {
                            string[] splitUniv = _universitas.universitas.Split(';');
                            var added = "";
                            var state = false;
                            foreach (var item in splitUniv)
                            {
                                if(string.IsNullOrEmpty(item) || string.IsNullOrWhiteSpace(item))
                                {
                                    state = true;
                                    continue;
                                }

                                if(!(await universitasRepository.addUniversitas(new Universitas{
                                    ID = new Guid(),
                                    universitas = item.Trim(),
                                    fkKategoriUniversitas = ktg,
                                    fkProvinsi = prv
                                })))
                                {
                                    state = false;
                                    if(!(string.IsNullOrEmpty(added))){added.Remove(added.Length-1, 1);}
                                    ModelState.AddModelError("", "Terjadi kesalahan, data tidak valid!");
                                    break;
                                }else{
                                    added += $" {item.Trim()},";
                                    state = true;
                                }
                            }
                            if(!state)
                            {
                                if(!(string.IsNullOrEmpty(added))){ModelState.AddModelError("", "Terjadi kesalahan, data tidak valid!");}
                                else{ModelState.AddModelError("", $"Terjadi kesalahan, data tidak valid!. Universitas{added} telah berhasil ditambahkan");}
                            }
                            else{message = "Data berhasil disimpan!"; return RedirectToAction(nameof(index));}
                        }
                        else{
                            if(!(await universitasRepository.addUniversitas(new Universitas{
                                ID = new Guid(),
                                universitas = _universitas.mst_namaUniv.Trim(),
                                fkKategoriUniversitas = ktg,
                                fkProvinsi = prv
                            }))){
                                ModelState.AddModelError("", "Terjadi kesalahan, data tidak valid!");
                            }else{
                                message = "Data berhasil disimpan";
                                return RedirectToAction(nameof(index));
                            }
                        }
                    }
                    
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            ViewBag.comboKategori = context.kategoriUniversitas.OrderBy(kU => kU.katgUniv).Select(kU => new SelectListItem{
                Value = kU.ID.ToString(),
                Text = kU.katgUniv,
                Selected = kU.ID.ToString() == _universitas.mst_fkKatUniv ? true : false
            });
            ViewBag.comboProvinsi = context.Provinsis.OrderBy(p => p.provinsi).Select(p => new SelectListItem{
                Text = p.provinsi,
                Value = p.ID.ToString(),
                Selected = p.ID.ToString() == _universitas.mst_fkProvinsi ? true : false
            });

            return View(_universitas);
        }

        public async Task<IActionResult> editUniversitas(string ID)
        {
            try
            {
                var data = await universitasRepository.readSingleUniversitasAsync(ID);

                ViewBag.comboKategori = context.kategoriUniversitas.OrderBy(kU => kU.katgUniv).Select(kU => new SelectListItem{
                    Value = kU.ID.ToString(),
                    Text = kU.katgUniv,
                    Selected = kU.ID.ToString() == data.mst_fkKatUniv
                });
                ViewBag.comboProvinsi = context.Provinsis.OrderBy(p => p.provinsi).Select(p => new SelectListItem{
                    Text = p.provinsi,
                    Value = p.ID.ToString(),
                    Selected = p.ID.ToString() == data.mst_fkProvinsi
                });

                return View(data);
            }
            catch (Exception e)
            {
                message = e.Message;
                return RedirectToAction(nameof(index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> editUniversitas(Universitas _universitas)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var ktg = await universitasRepository.readSingleKategoriUniversitas(_universitas.mst_fkKatUniv);
                    var prv = await provinsiRepository.readOneByID(_universitas.mst_fkProvinsi);
                    if(ktg == null || prv == null)
                    {
                        ModelState.AddModelError("", "Terjadi kesalahan, data tidak valid!");
                    }
                    else{

                        if(_universitas.universitas.Contains(';'))
                        {
                            ModelState.AddModelError("universitas", "Penggunaan semicolon tidak dibolehkan!");
                        }else{
                            if(!(await universitasRepository.editUniversitas(new Universitas{
                                ID = _universitas.ID,
                                universitas = _universitas.universitas,
                                fkKategoriUniversitas = ktg,
                                fkProvinsi = prv
                            }))){
                                ModelState.AddModelError("", "Terjadi kesalahan, data tidak valid!");
                            }else{
                                message = "Data berhasil disimpan";
                                return RedirectToAction(nameof(index));
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            ViewBag.comboKategori = context.kategoriUniversitas.OrderBy(kU => kU.katgUniv).Select(kU => new SelectListItem{
                Value = kU.ID.ToString(),
                Text = kU.katgUniv,
                Selected = kU.ID.ToString() == _universitas.mst_fkKatUniv ? true : false
            });
            ViewBag.comboProvinsi = context.Provinsis.OrderBy(p => p.provinsi).Select(p => new SelectListItem{
                Text = p.provinsi,
                Value = p.ID.ToString(),
                Selected = p.ID.ToString() == _universitas.mst_fkProvinsi ? true : false
            });
            return View(_universitas);
        }

        public async Task<IActionResult> hapusUniversitas(string ID)
        {
            try
            {
                if(!(await universitasRepository.deleteUniversitas(context.universitas.FirstOrDefault(i => i.ID.ToString() == ID))))
                {
                    message = "Terjadi kesalahan, gagal menghapus";
                }else{
                    message = "Data berhasil dihapus";
                }
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return RedirectToAction(nameof(index));

        }





// =============================================================================================================  //





        public IActionResult tambahKategoriUniversitas()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> tambahKategoriUniversitas(KategoriUniversitas _katUniv)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    if(_katUniv.katgUniv.Contains(';'))
                    {
                        string[] splitKategoriUniv = _katUniv.katgUniv.Split(';');

                        var added = "";
                        var state = false;
                        foreach (var item in splitKategoriUniv)
                        {
                            if(string.IsNullOrWhiteSpace(item) || string.IsNullOrEmpty(item))
                            {
                                state = true;
                                continue;
                            }

                            if(!(await universitasRepository.addKategoriUniversitas(new KategoriUniversitas{
                                ID = new Guid(),
                                katgUniv = item.Trim()
                            })))
                            {
                                state = false;
                                if(!(string.IsNullOrEmpty(added))){
                                    added.Remove(added.Length-1, 1);
                                }
                                break;
                            }else{
                                state = true;
                                added += $" {item.Trim()},";
                                continue;
                            }
                        }
                        if(!state)
                        {
                            if(string.IsNullOrEmpty(added))
                            {
                                ModelState.AddModelError("", "Terjadi kesalahan, data tidak valid!");
                            }else{
                                ModelState.AddModelError("", $"Terjadi kesalahan, data tidak valid! Kategori Universitas{added} telah ditambahkan");
                            }
                        }else{
                            message = "Data berhasil disimpan";
                            return RedirectToAction(nameof(index));
                        }
                    }else{
                        if(!(await universitasRepository.addKategoriUniversitas(new KategoriUniversitas{
                            ID = new Guid(),
                            katgUniv = _katUniv.katgUniv.Trim()
                        }))){
                            ModelState.AddModelError("", "Terjadi kesalahan, data tidak valid!");
                        }else{
                            message = "Data berhasil disimpan";
                            return RedirectToAction(nameof(index));
                        }
                    }
                }
                catch (Exception e){
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View(_katUniv);
        }

        public async Task<IActionResult> editKategoriUniversitas(string ID)
        {
            try
            {
                var data = await universitasRepository.readSingleKategoriUniversitas(ID);

                return View(data);
            }
            catch (Exception e)
            {
                message = e.Message;
                return RedirectToAction(nameof(index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> editKategoriUniversitas(KategoriUniversitas _katUniv)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    if(_katUniv.mst_namaKatUniv.Contains(';'))
                    {
                        ModelState.AddModelError("","Penggunaan semicolon tidak dibolehkan");
                    }else{
                       if(!(await universitasRepository.editKategoriUniversitas(_katUniv)))
                       {
                           ModelState.AddModelError("","Terjadi kesalahan, gagal menyimpan!");
                       }else{
                           message = "Data berhasil disimpan";
                           return RedirectToAction(nameof(index));
                       }

                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            return View(_katUniv);
        }

        public async Task<IActionResult> hapusKategoriUniversitas(string ID)
        {
            try
            {
                if(!(await universitasRepository.deleteKategoriUniversitas(context.kategoriUniversitas.FirstOrDefault(k => k.ID.ToString() == ID)))){
                    message = "Terjadi kesalahan, data gagal dihapus";
                }else{
                    message = "Data berhasil dihapus";
                }
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return RedirectToAction(nameof(index));
        }
    // ========================================================================================================= //

        public async Task<IActionResult> updateStatistik(string ID)
        {
            var univ = await universitasRepository.readOnlyUniversitas(ID);
            
            var statsView = new updateStatsView{
                lists = await universitasRepository.StatistikUniversitasAsync(ID),
                idUniv = univ.ID.ToString(),
                namaUniv = univ.universitas
            };

            return View(statsView);
        }
        
        [HttpPost]
        public async Task<IActionResult> updateStatistik(updateStatsView update)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var uniqueYear = new HashSet<string>();

                    foreach (var item in update.lists)
                    {
                        // CEK DOUBLE TANGGAL //
                        if(uniqueYear.Contains(item.year.ToString().Trim()))
                        {
                            throw new Exception("Terjadi kesalahan, silahkan periksa kembali data 0");
                        }
                        else if(item.year < 2010 || item.year > Int16.Parse(DateTime.Now.ToString("yyyy")))
                        {
                            throw new Exception("Terjadi kesalahan, silahkan periksa kembali data 1");
                        }else{
                            uniqueYear.Add(item.year.ToString());
                        }

                        // CEK MINUS STATISTIK
                        if(item.kuota < 0 || item.peminat < 0)
                        {
                            throw new Exception("Terjadi kesalahan, silahkan periksa kembali data 2");
                        }

                        // ASSIGN ID UNIVERSITAS
                        item.fkUniv = await universitasRepository.readOnlyUniversitas(update.idUniv);
                        
                    }


                    if(!(await universitasRepository.updateStatistik(update.lists)))
                    {
                        throw new Exception("Terjadi kesalahan, silahkan periksa kembali data 3");
                    }
                    else
                    {
                        message = "Data berhasil disimpan!";
                        return RedirectToAction(nameof(index));
                    }

                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }

            }
            return View(update);
            
        }
        public async Task<IActionResult> hapusStatistik(string ID)
        {
            try
            {
                string univKey;

                var _stats = await universitasRepository.singleStatistikUniversitasAsync(ID);

                univKey = _stats.mst_primaryUniversitas;

                context.Remove(_stats);
                await context.SaveChangesAsync();
                message = "Data berhasil dihapus";
                return RedirectToAction("updateStatistik", new {ID = univKey});
            }
            catch (Exception e)
            {
                message = e.Message;
                return RedirectToAction(nameof(index));
            }

            
        }

        [HttpPost]
        public async Task<IActionResult> delStats(string ID)
        {
            try
            {
                if(!(await universitasRepository.deleteStatik(ID)))
                {
                    throw new Exception("Terjadi Kesalahan");
                }else
                {
                    return Json("Data berhasil dihapus");
                }
            }
            catch (System.Exception e)
            {
                return Json($"Terjadi kesalahan, {e.Message}");
            }
        }

        private bool isUniqueCollection(string[] myArray, bool checkNull)
        {
            var unique = new HashSet<string>();
            foreach (var item in myArray)
            {
                if( !checkNull && (string.IsNullOrWhiteSpace(item) || string.IsNullOrEmpty(item)) )
                {
                    continue;
                }
                if( checkNull && (string.IsNullOrWhiteSpace(item) || string.IsNullOrEmpty(item)) )
                {
                    return false;
                }
                if(unique.Contains(item)){
                    return false;
                }
                unique.Add(item);
            }
            return true;
        }

        
        /* [HttpPost]
        public async Task<IActionResult> updateStatistik(string[] keyID, string[] year, string[] kuota, string[] peminat, string idUniversitas)
        {
            try
            {
                var checkDoubledID = isUniqueCollection(keyID, false);
                var checkDoubledYear = isUniqueCollection(year, true);
                if(!checkDoubledID || !checkDoubledYear || string.IsNullOrEmpty(idUniversitas) || string.IsNullOrWhiteSpace(idUniversitas) || ((keyID.Length != year.Length) && (keyID.Length != kuota.Length) && (keyID.Length != peminat.Length)))
                {
                    message = "Gagal menyimpan, data yang dimasukkan tidak memenuhi syarat";
                    return RedirectToAction(nameof(updateStatistik), new{ID = idUniversitas});
                }

                for (int i = 0; i < keyID.Length; i++)
                {
                    if(Int32.Parse(year[i]) < 2010 || Int32.Parse(year[i]) > Int32.Parse(DateTime.Now.Year.ToString()))
                    {
                        message = "Rentang tahun tidak memenuhi syarat";
                        return RedirectToAction(nameof(updateStatistik), new{ID = idUniversitas});
                    }
                    if(string.IsNullOrEmpty(kuota[i]) || string.IsNullOrWhiteSpace(kuota[i]) || string.IsNullOrWhiteSpace(peminat[i]) || string.IsNullOrEmpty(peminat[i]) || Int32.Parse(kuota[i]) < 0 || Int32.Parse(peminat[i]) < 0)
                    {
                        message = "Gagal menyimpan, data yang dimasukkan tidak memenuhi syarat";
                        return RedirectToAction(nameof(updateStatistik), new{ID = idUniversitas});
                    }
                }
                

                for (int i = 0; i < keyID.Length; i++)
                {
                    if(string.IsNullOrEmpty(keyID[i]) || string.IsNullOrWhiteSpace(keyID[i]))
                    {
                        var _stats = new statistikUniversitas{
                            fkUniv = context.universitas.FirstOrDefault(u => u.ID.ToString() == idUniversitas),
                            year = Int32.Parse(year[i]),
                            peminat = Int32.Parse(peminat[i]),
                            kuota = Int32.Parse(kuota[i])
                        };

                        if(_stats.fkUniv == null)
                        {
                            message = "Gagal menyimpan, data yang dimasukkan tidak memenuhi syarat";
                            return RedirectToAction(nameof(updateStatistik), new{ID = idUniversitas});
                        }

                        context.Add(_stats);
                        await context.SaveChangesAsync();
                        continue;
                    }
                    var _Stats = context.statistikUnivs.FirstOrDefault(s => s.ID.ToString() == keyID[i]);
                    _Stats.fkUniv = context.universitas.FirstOrDefault(u => u.ID.ToString() == idUniversitas);
                    if(_Stats.fkUniv == null)
                    {
                        message = "Gagal menyimpan, data yang dimasukkan tidak memenuhi syarat";
                        return RedirectToAction(nameof(updateStatistik), new{ID = idUniversitas});
                    }
                    _Stats.year = Int32.Parse(year[i]);
                    _Stats.peminat = Int32.Parse(peminat[i]);
                    _Stats.kuota = Int32.Parse(kuota[i]);

                    context.Update(_Stats);
                    await context.SaveChangesAsync();
                }
                message = "Data berhasil disimpan";
                return RedirectToAction(nameof(index));
            }
            catch (Exception e)
            {
                message = e.Message;
                return RedirectToAction(nameof(updateStatistik), new{ID = idUniversitas});
            }
            
        } */

        
    }
}