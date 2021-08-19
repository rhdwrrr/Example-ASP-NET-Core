using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrigamiEdu.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace OrigamiEdu.Repository
{
    public class UniversitasRepository
    {
        private readonly Context context;
        private readonly ILogger<UniversitasRepository> logger;
        private readonly ProvinsiRepository provinsiRepository;
        private readonly UserManager<AppUser> userManager;

        public UniversitasRepository(Context context, ILogger<UniversitasRepository> logger,ProvinsiRepository provinsiRepository, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.logger = logger;
            this.provinsiRepository = provinsiRepository;
            this.userManager = userManager;
        }

        // Kategori Universitas ================================================================
        public async Task<List<KategoriUniversitas>> readKategoriUniversitas()
        {
            return await context.kategoriUniversitas.ToListAsync();
        }

        public async Task<KategoriUniversitas> readSingleKategoriUniversitas(string ID)
        {
            return await context.kategoriUniversitas.FirstOrDefaultAsync(i => i.ID.ToString() == ID);
        }
        public async Task<List<KategoriUniversitas>> readAndSelectKategori(string ID)
        {
            return await context.kategoriUniversitas.Select(i => new KategoriUniversitas{
                ID = i.ID,
                katgUniv = i.katgUniv,
                selected = i.ID.ToString() == ID
            }).ToListAsync();
        }

        public async Task<bool> addKategoriUniversitas(KategoriUniversitas kategoriUniversitas)
        {
            try
            {
                await context.AddAsync(kategoriUniversitas);
                await context.SaveChangesAsync();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> editKategoriUniversitas(KategoriUniversitas kategoriUniversitas)
        {
            try
            {
                context.Update(kategoriUniversitas);
                await context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> deleteKategoriUniversitas(KategoriUniversitas kategori)
        {
            try
            {
                context.Remove(kategori);
                await context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        // Universitas ===============================================================================
        public async Task<Int32> countUniversitasAsync()
        {
            return await context.universitas.CountAsync();
        }
        public async Task<List<Universitas>> readUniversitasAsync(){
            return await (from u in context.universitas 
                          join k in context.kategoriUniversitas on u.fkKategoriUniversitas.ID equals k.ID
                          into uK from uniKtg in uK.DefaultIfEmpty()
                          join p in context.Provinsis on u.fkProvinsi.ID equals p.ID
                          into uP from uniProv in uP.DefaultIfEmpty() select new Universitas{
                              ID = u.ID,
                              universitas = u.universitas,
                              mst_fkProvinsi = uniProv == null ? "(Tidak tersedia)" : uniProv.provinsi,
                              mst_fkKatUniv = uniKtg == null ? "(Tidak tersedia)" : uniKtg.katgUniv
                          }).ToListAsync();
        }
        public async Task<Universitas> readSingleUniversitasAsync(string ID){
            return await (from u in context.universitas where u.ID.ToString() == ID
                          join k in context.kategoriUniversitas on u.fkKategoriUniversitas.ID equals k.ID
                          into uK from uniKtg in uK.DefaultIfEmpty()
                          join p in context.Provinsis on u.fkProvinsi.ID equals p.ID
                          into uP from uniProv in uP.DefaultIfEmpty() select new Universitas{
                              ID = u.ID,
                              universitas = u.universitas,
                              mst_fkProvinsi = uniProv == null ? string.Empty : uniProv.ID.ToString(),
                              mst_fkKatUniv = uniKtg == null ? string.Empty : uniKtg.ID.ToString()
                          }).FirstOrDefaultAsync();
        }
        public async Task<Universitas> readOnlyUniversitas(string ID){
            return await context.universitas.FirstOrDefaultAsync(i => i.ID.ToString() == ID);
        }
        public async Task<bool> addUniversitas(Universitas univ)
        {
            try
            {
                await context.AddAsync(univ);
                await context.SaveChangesAsync();
                
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async Task<bool> editUniversitas(Universitas univ)
        {
            try
            {
                context.Update(univ);
                await context.SaveChangesAsync();
                
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async Task<bool> dumpUniversitas(Universitas univ)
        {
            try
            {
                var dump = new UniversitasDump{
                    ID = univ.ID,
                    universitas = univ.universitas
                };
                await context.AddAsync(dump);
                await context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async Task<bool> deleteUniversitas(Universitas universitas)
        {
            try
            {
                if(!(await dumpUniversitas(universitas)))
                {
                    return false;
                }
                context.Remove(universitas);
                await context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async Task<List<UniversitasDump>> readDumpedUniversitas()
        {
            return await context.universitasDumps.ToListAsync();
        }
        public async Task<bool> recoverUniversitasAsync(UniversitasDump dump)
        {
            try
            {
                if(!(await addUniversitas(new Universitas{
                    ID = dump.ID,
                    universitas = dump.universitas
                }))){
                    return false;
                }
                context.Remove(dump);
                await context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        // Statistik Universitas =========================================================

        public async Task<List<statistikUniversitas>> StatistikUniversitasAsync(string univID)
        {
            return await (from st in context.statistikUnivs 
                          join u in context.universitas on st.fkUniv.ID equals u.ID
                          where u.ID.ToString() == univID select st)
                          .ToListAsync();
        }
        public async Task<statistikUniversitas> singleStatistikUniversitasAsync(string statID)
        {
            return await (from st in context.statistikUnivs where st.ID.ToString() == statID
                          join u in context.universitas on st.fkUniv.ID equals u.ID
                          select new statistikUniversitas{
                              ID = st.ID,
                              mst_primaryUniversitas = u.ID.ToString()
                          })
                          .FirstOrDefaultAsync();
        }

        public async Task<bool> updateStatistik(List<statistikUniversitas> statistiks)
        {
            try
            {
                foreach (var item in statistiks)
                {
                    if(!(item.ID == Guid.Empty))
                    {
                        context.Update(item);
                    }
                    else
                    {
                        await context.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }

        public async Task<bool> deleteStatik(string ID)
        {
            try
            {
                var stats = await context.statistikUnivs.FirstOrDefaultAsync(i => i.ID.ToString() == ID);

                context.Remove(stats);
                await context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}