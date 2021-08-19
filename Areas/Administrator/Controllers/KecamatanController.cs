/* using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrigamiEdu.Models;
using System;
using System.Linq;
// using System.Collections.IEnumerable;

namespace OrigamiEdu.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class KecamatanController : Controller
    {
        private readonly Context _context;

        public KecamatanController(Context context)
        {
            _context = context;
        }
        
        public IActionResult index(string message)
        {
            if(message != null)
            {
                ViewBag.message = message;
            }
            var data = (from kec in _context.Kecamatans join kab in _context.KabupatenKotas on kec.fkKabKota.ID equals kab.ID join prov in _context.Provinsis on kab.fkProvinsi.ID equals prov.ID select new Kecamatan{
                mst_primary = kec.ID.ToString(),
                mst_namaKecamatan = kec.kecamatan,
                mst_kabProv = kab.kabupatenKota + ", " + prov.provinsi,
                mst_namaProv = prov.provinsi
            }).OrderBy(d => d.mst_namaProv).ToList();
            return View(data);
        }
        
        public IActionResult tambah()
        {
            // ViewBag.comboProvinsi = _context.Provinsis.Select(p => new SelectListItem{
            //     Value = p.ID.ToString(),
            //     Text = p.provinsi
            // }).OrderBy(p => p.Text);
            
            // var objView = new Kecamatan{
            //     comboProvinsi = _context.Provinsis.Select(p => new SelectListItem{
            //         Value = p.ID.ToString(),
            //         Text = p.provinsi
            //     }).OrderBy(p => p.Text)
            // };
            
            return View();
        }
        
        [HttpPost]
        public JsonResult chComboKabKota(string ID, string action)
        {
            if(action == "add-load")
            {
                var objViewKabKota = (from kab in _context.KabupatenKotas join pr in _context.Provinsis on kab.fkProvinsi.ID equals pr.ID where pr.ID.ToString() == ID select new KabupatenKota{
                    mst_primary = kab.ID.ToString(),
                    mst_namaKabKota = kab.kabupatenKota
                }).OrderBy(obj => obj.mst_namaKabKota);
                if(objViewKabKota == null) return Json(null);
                return Json(objViewKabKota);
            }
            else if(action == "edit-load")
            {
                var objKec = (from kec in _context.Kecamatans join kab in _context.KabupatenKotas on kec.fkKabKota.ID equals kab.ID join pr in _context.Provinsis on kab.fkProvinsi.ID equals pr.ID where kec.ID.ToString() == ID select new Kecamatan{
                    mst_primary = kec.ID.ToString(),
                    mst_primaryKabKota = kab.ID.ToString(),
                    mst_primaryProvinsi = pr.ID.ToString()
                }).FirstOrDefault();
                if(objKec == null) return Json(null);
                
                
                var objKab = (from kab in _context.KabupatenKotas join pr in _context.Provinsis on kab.fkProvinsi.ID equals pr.ID where pr.ID.ToString() == objKec.mst_primaryProvinsi select new KabupatenKota{
                    mst_primary = kab.ID.ToString(),
                    mst_namaKabKota = kab.kabupatenKota,
                    selected = kab.ID.ToString() == objKec.mst_primaryKabKota ? "selected" : ""
                });
                if(objKab == null) return Json(null);
                return Json(objKab);    
            }
            else if(action == "add-change")
            {
                 var objViewKabKota = (from kab in _context.KabupatenKotas join pr in _context.Provinsis on kab.fkProvinsi.ID equals pr.ID where pr.ID.ToString() == ID select new KabupatenKota{
                    mst_primary = kab.ID.ToString(),
                    mst_namaKabKota = kab.kabupatenKota
                }).OrderBy(obj => obj.mst_namaKabKota);
                if(objViewKabKota == null) return Json(null);
                return Json(objViewKabKota);
            }else if(action == "edit-change")
            {
                var objKab = (from kab in _context.KabupatenKotas join pr in _context.Provinsis on kab.fkProvinsi.ID equals pr.ID where pr.ID.ToString() == ID select new KabupatenKota{
                    mst_primary = kab.ID.ToString(),
                    mst_namaKabKota = kab.kabupatenKota
                }).OrderBy(obj => obj.mst_namaKabKota);
                if(objKab == null) return Json(null);
                return Json(objKab);
            }
            return Json(null);
        }
        [HttpPost]
        public JsonResult chComboProvinsi(string ID, string action)
        {
            if(action == "add")
            {
                var prov = _context.Provinsis.OrderBy(p => p.provinsi).Select(p => new Provinsi{
                    mst_primary = p.ID.ToString(),
                    mst_namaProvinsi = p.provinsi
                });
                
                if(prov == null) return Json(null);
                
                return Json(prov);
            }else if(action == "change")
            {
                var oP = (from kec in _context.Kecamatans join kab in _context.KabupatenKotas on kec.fkKabKota.ID equals kab.ID join pr in _context.Provinsis on kab.fkProvinsi.ID equals pr.ID where kec.ID.ToString() == ID select new Provinsi{
                    mst_primary = pr.ID.ToString()
                }).FirstOrDefault();
                
                if(oP == null) return Json(null);

                var prov = _context.Provinsis.OrderBy(p => p.provinsi).Select(p => new Provinsi{
                    mst_primary = p.ID.ToString(),
                    mst_namaProvinsi = p.provinsi,
                    selected = oP.mst_primary == p.ID.ToString() ? "selected" : ""
                });
                if(prov == null) return Json(null);
                return Json(prov);
            }
            return Json(null);
        }
        
        [HttpPost]
        public IActionResult tambah([Bind("mst_namaKecamatan", "mst_primaryKabKota", "mst_primaryProvinsi")] Kecamatan oKec)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var objProv = _context.Provinsis.FirstOrDefault(pr => pr.ID.ToString() == oKec.mst_primaryProvinsi);
                    var objKab = _context.KabupatenKotas.FirstOrDefault(kab => kab.ID.ToString() == oKec.mst_primaryKabKota);
                    
                    if(objKab == null || objProv == null)
                    {
                        return RedirectToAction("index", new{ Area = "Administrator", message = "Kabupaten/Kota tidak ditemukan"});
                    }
                    
                    if(oKec.mst_namaKecamatan.Contains(';'))
                    {
                        if(oKec.mst_namaKecamatan[oKec.mst_namaKecamatan.Length-1] == ';')
                        {
                            oKec.mst_namaKecamatan.Remove(oKec.mst_namaKecamatan.Length-1 , 1);
                        }
                        var helper = oKec.mst_namaKecamatan.Split(';');
                        foreach (var item in helper)
                        {
                            var dbKec = new Kecamatan()
                            {
                                kecamatan = item,
                                fkKabKota = objKab
                            };
                            _context.Add(dbKec);
                            _context.SaveChanges();
                        }
                    }
                    else{
                        var dbKec = new Kecamatan()
                        {
                            kecamatan = oKec.mst_namaKecamatan,
                            fkKabKota = objKab
                        };
                        _context.Add(dbKec);
                        _context.SaveChanges();
                    }
                    return RedirectToAction("index", new{Area = "Administrator", message = "Data berhasil disimpan"});
                }
                catch (Exception e)
                {
                    return RedirectToAction("index", new{Area = "Administrator", message = "Jika Anda melihat error ini, tolong hubungi developer dan dokumentasikan kode error berikut:\n"+ e.Message});
                }
            }
            return View();
        }
        
        public IActionResult edit(string ID)
        {
            // try
            // {
            //     var objEdit = (from kec in _context.Kecamatans join kab in _context.KabupatenKotas on kec.fkKabKota.ID equals kab.ID join pr in _context.Provinsis on kab.fkProvinsi.ID equals pr.ID where kec.ID.ToString() == ID select new Kecamatan{
            //         mst_primary = kec.ID.ToString(),
            //         mst_namaKecamatan = kec.kecamatan,
            //         mst_primaryKabKota = kab.ID.ToString(),
            //         mst_primaryProvinsi = pr.ID.ToString()
            //     }).FirstOrDefault();
            //     objEdit.comboProvinsi = _context.Provinsis.Select(x => new SelectListItem{
            //             Text = x.provinsi,
            //             Value = x.ID.ToString(),
            //             Selected = objEdit.mst_primaryProvinsi == x.ID.ToString() ? true : false
            //         }).OrderBy(x => x.Text);
            //     objEdit.comboKabKota = _context.KabupatenKotas.Where(x => x.fkProvinsi.ID.ToString() == objEdit.mst_primaryProvinsi).Select(x => new SelectListItem{
            //             Text = x.kabupatenKota,
            //             Value = x.ID.ToString(),
            //             Selected = x.ID.ToString() == objEdit.mst_primaryKabKota? true : false
            //         }).OrderBy(x => x.Text);
            //     return View(objEdit);
            // }
            // catch (Exception e)
            // {
            //     return RedirectToAction("index", new{Area = "Administrator", message = "Jika Anda melihat error ini, tolong hubungi developer dan dokumentasikan kode error berikut:\n"+ e.Message});
            // }
            var obj = (from kec in _context.Kecamatans where kec.ID.ToString() == ID select new Kecamatan{
                mst_primary = kec.ID.ToString(),
                mst_namaKecamatan = kec.kecamatan
            }).FirstOrDefault();
            return View(obj);
        }
        
        [HttpPost]
        public IActionResult edit([Bind("mst_primary", "mst_namaKecamatan", "mst_primaryKabKota", "mst_primaryProvinsi")] Kecamatan oKec)
        {
            if(ModelState.IsValid)
            {
                if(oKec.mst_namaKecamatan.Contains(';'))
                {
                    return RedirectToAction("index", new{Area = "Administrator", message = "Hanya mendukung satu data, penggunaan semicolon dilarang!"});
                }
                try
                {
                    var objKab = _context.KabupatenKotas.FirstOrDefault(kab => kab.ID.ToString() == oKec.mst_primaryKabKota);
                    var objKec = _context.Kecamatans.FirstOrDefault(kec => kec.ID.ToString() == oKec.mst_primary);
                    if(objKec == null || objKab == null)
                    {
                        return RedirectToAction("index", new{Area = "Administrator", message = "Data tidak ditemukan, gagal mengubah"});
                    }
                    objKec.kecamatan = oKec.mst_namaKecamatan;
                    objKec.fkKabKota = objKab;
                    
                    _context.Update(objKec);
                    _context.SaveChanges();
                    return RedirectToAction("index", new{Area = "Administrator", message = "Data berhasil diubah"});
                }
                catch (Exception e)
                {
                    return RedirectToAction("index", new{Area = "Administrator", message = "Jika Anda melihat error ini, tolong hubungi developer dan dokumentasikan kode error berikut:\n"+ e.Message});
                }
            }
            return View();
        }
        
        public IActionResult hapus(string ID)
        {
            try
            {
                var objKec = _context.Kecamatans.FirstOrDefault(kec => kec.ID.ToString() == ID);
                if(objKec == null)
                {
                    return RedirectToAction("index", new{Area = "Administrator", message = "Data tidak ditemukan, gagal menghapus"});
                }
                _context.Remove(objKec);
                _context.SaveChanges();
                return RedirectToAction("index", new{Area = "Administrator", message = "Data berhasil dihapus"});
            }
            catch (Exception e)
            {
                return RedirectToAction("index", new{Area = "Administrator", message = "Jika Anda melihat error ini, tolong hubungi developer dan dokumentasikan kode error berikut:\n"+ e.Message});
            }
        }
    }
} */