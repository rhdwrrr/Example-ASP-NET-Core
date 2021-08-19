using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrigamiEdu.Models;
using System.Linq;
using System;

namespace OrigamiEdu.Repository
{
    public class KabupatenKotaRepository
    {
        private readonly Context context;
        private readonly ILogger<KabupatenKotaRepository> logger;

        public KabupatenKotaRepository(Context context, ILogger<KabupatenKotaRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public async Task<Int32> countKabupaten()
        {
            return await context.KabupatenKotas.CountAsync();
        }
        public async Task<List<KabupatenKota>> readAll()
        {
            var result = (from k in context.KabupatenKotas 
                          join p in context.Provinsis on k.fkProvinsi.ID equals p.ID 
                          into kabProv from kp in kabProv.DefaultIfEmpty() 
                          select new KabupatenKota{
                              ID = k.ID,
                              kabupatenKota = k.kabupatenKota,
                              mst_namaProvinsi = kp == null ? "Tidak Tersedia" : kp.provinsi
                          }).ToListAsync();

            return await result;
        }
        public async Task<List<KabupatenKota>> readByProvinsi(string provinsiID, string kabID)
        {
            var result = await (from k in context.KabupatenKotas join p in context.Provinsis on k.fkProvinsi.ID equals p.ID where p.ID.ToString() == provinsiID select new KabupatenKota{
                ID = k.ID,
                kabupatenKota = k.kabupatenKota,
                selected = k.ID.ToString() == kabID
            }).ToListAsync();

            return result;
        }
        public async Task<KabupatenKota> readOneByID(string keyID)
        {
            var result = (from k in context.KabupatenKotas where k.ID.ToString() == keyID 
                          join p in context.Provinsis on k.fkProvinsi.ID equals p.ID 
                          into kabProv from kp in kabProv.DefaultIfEmpty() 
                          select new KabupatenKota{
                            ID = k.ID,
                            kabupatenKota = k.kabupatenKota,
                            mst_primaryProvinsi = kp == null ? string.Empty : kp.ID.ToString()
                          }).FirstOrDefaultAsync();

            return await result;
        }
        public async Task<KabupatenKota> readSingle(string keyID)
        {
            return await context.KabupatenKotas.FirstOrDefaultAsync(i => i.ID.ToString() == keyID);
        }
        public async Task<bool> add(KabupatenKota kab)
        {
            try
            {
                await context.AddAsync(kab);
                await context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async Task<bool> edit(KabupatenKota kabupatenKota)
        {
            try
            {
                context.Update(kabupatenKota);
                await context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
                
            }
        }

        public async Task<bool> dumpKabupaten(KabupatenKota kab)
        {
            try
            {
                // ================================ start dump
                var dump = new KabupatenKotaDump{
                    ID = kab.ID,
                    kabupatenKota = kab.kabupatenKota
                };
                await context.AddAsync(dump);
                await context.SaveChangesAsync();
                // ================================ end dump

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> delete(KabupatenKota kabupaten)
        {
            try
            {
                if(!(await dumpKabupaten(kabupaten))){
                    return false;
                }
                // ================================ start delete kabupaten
                context.Remove(kabupaten);
                await context.SaveChangesAsync();
                // ================================ end delete kabupaten
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        // ========================================= DUMPED ITEMS

        public async Task<List<KabupatenKotaDump>> readKabupatenKotaDumpsAsync()
        {
            return await context.kabupatenKotaDumps.ToListAsync();
        }

        public async Task<bool> recoverKabupatenKota(KabupatenKotaDump dump)
        {
            try
            {
                if(!(await add(new KabupatenKota{ID = dump.ID, kabupatenKota = dump.kabupatenKota})))
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
        
    }
}