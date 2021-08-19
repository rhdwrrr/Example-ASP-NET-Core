using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrigamiEdu.Models;
using System.Linq;

namespace OrigamiEdu.Repository
{
    public class SekolahRepository
    {
        private readonly Context context;
        private readonly ILogger<SekolahRepository> logger;
        private readonly KabupatenKotaRepository kabupatenKotaRepository;
        private readonly ProvinsiRepository provinsiRepository;

        public SekolahRepository(Context context, ILogger<SekolahRepository> logger, KabupatenKotaRepository kabupatenKotaRepository, ProvinsiRepository provinsiRepository)
        {
            this.context = context;
            this.logger = logger;
            this.kabupatenKotaRepository = kabupatenKotaRepository;
            this.provinsiRepository = provinsiRepository;
        }
        public async Task<List<Sekolah>> readAll()
        {
            var result = await 
            (from s in context.Sekolahs 
            join ktg in context.kategoriSekolahs on s.fkKategoriSekolah.ID equals ktg.ID 
            into sk from sekKat in sk.DefaultIfEmpty() 
            join kab in context.KabupatenKotas on s.fkKabupatenKota.ID equals kab.ID 
            into sKb from sekKab in sKb.DefaultIfEmpty() 
            join p in context.Provinsis on sekKab.fkProvinsi.ID equals p.ID
            into sPr from sekProv in sPr.DefaultIfEmpty()
            select new Sekolah{
                ID = s.ID,
                sekolah = s.sekolah,
                mst_KatgName = sekKat == null ? "(Tidak Tersedia)" : sekKat.namaKategori,
                mst_loc = (sekKab == null || sekProv == null) ? "(Tidak Tersedia)" : $"{sekKab.kabupatenKota}, {sekProv.provinsi}"
            }).ToListAsync();
            
            return result;
        }
        public async Task<Sekolah> readOneByID(string keyID)
        {
            var result = (from s in context.Sekolahs where s.ID.ToString() == keyID
            join ktg in context.kategoriSekolahs on s.fkKategoriSekolah.ID equals ktg.ID 
            into sk from sekKat in sk.DefaultIfEmpty() 
            join kab in context.KabupatenKotas on s.fkKabupatenKota.ID equals kab.ID 
            into sKb from sekKab in sKb.DefaultIfEmpty() 
            join p in context.Provinsis on sekKab.fkProvinsi.ID equals p.ID
            into sPr from sekProv in sPr.DefaultIfEmpty()
            select new Sekolah{
                ID = s.ID,
                sekolah = s.sekolah,
                mst_primaryKtg = sekKat == null ? string.Empty : sekKat.ID.ToString(),
                mst_primaryProvinsi = sekProv == null ? string.Empty : sekProv.ID.ToString(),
                mst_fkKab = sekKab == null ? string.Empty : sekKab.ID.ToString()
            }).FirstOrDefaultAsync();
            
            return await result;
        }

        public async Task<bool> addSekolah(Sekolah sch)
        {
            try
            {
                await context.AddAsync(sch);
                await context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }

        public async Task<bool> editSekolah(Sekolah sekolah)
        {
            try
            {
                // sekolah.fkKabupatenKota = await kabupatenKotaRepository.readOneByID(sekolah.mst_fkKab);
                // sekolah.fkKategoriSekolah = await readKategoriSekolahByID(sekolah.mst_primaryKtg);

                // if(sekolah.fkKategoriSekolah == null || sekolah.fkKabupatenKota == null){
                //     return false;
                // }

                context.Update(sekolah);
                await context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> dumpSekolah(Sekolah sch)
        {
            try
            {
                var dump = new SekolahDump
                {
                    ID = sch.ID,
                    sekolah = sch.sekolah
                };

                await context.AddAsync(dump);
                await context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }

        public async Task<bool> deleteSekolah(Sekolah sekolah)
        {
            try
            {
                if(!(await dumpSekolah(sekolah)))
                {
                    return false;
                }
                context.Remove(sekolah);
                await context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }

        public async Task<List<SekolahDump>> readSekolahDumpsAsync()
        {
            return await context.sekolahDumps.ToListAsync();
        }

        public async Task<bool> recoverSekolah(SekolahDump dump)
        {
            try
            {
                var sk = new Sekolah{
                    ID = dump.ID,
                    sekolah = dump.sekolah
                };
                if(!(await addSekolah(sk)))
                {
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
        // COUNT SEKOLAH ============================================================================
        public async Task<Int32> countAllSekolah()
        {
            return await context.Sekolahs.CountAsync();
        }

        public async Task<Int64> countByKategori(Guid keyKategori)
        {
            var results = await (from s in context.Sekolahs join k in context.kategoriSekolahs on s.fkKategoriSekolah.ID equals k.ID where k.ID == keyKategori select s).ToListAsync();

            return results.Count();
        }
        // KATEGORI =================================================================================

        public async Task<List<KategoriSekolah>> readKategoriSekolahsAsync()
        {
            var result = await context.kategoriSekolahs.ToListAsync();

            return result;
        }

        public async Task<List<KategoriSekolah>> readKategoriSekolahsAsync(string keyID)
        {
            var result = context.kategoriSekolahs.Select(i => new KategoriSekolah{
                ID = i.ID,
                namaKategori = i.namaKategori,
                selected = i.ID.ToString() == keyID
            }).ToListAsync();

            return await result;
        }

        public async Task<KategoriSekolah> readKategoriSekolahByID(string key)
        {
            var result = context.kategoriSekolahs.FirstOrDefaultAsync(k => k.ID.ToString() == key);

            return await result;
        }

        public async Task<bool> addKategoriSekolah(KategoriSekolah kategoriSekolah)
        {
            try
            {
                await context.AddAsync(kategoriSekolah);
                await context.SaveChangesAsync();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> editKategoriSekolah(KategoriSekolah kategoriSekolah)
        {
            try
            {
                context.Update(kategoriSekolah);
                await context.SaveChangesAsync();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> deleteKategoriSekolah(KategoriSekolah kategoriSekolah)
        {
            try
            {
                var Sekolahs = (from s in context.Sekolahs join k in context.kategoriSekolahs on s.fkKategoriSekolah.ID equals k.ID where k.ID == kategoriSekolah.ID select s).ToListAsync();

                foreach (var item in await Sekolahs)
                {
                    if(!(await dumpSekolah(item)))
                    {
                        continue;
                    }
                    return false;
                } 

                context.Remove(kategoriSekolah);
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