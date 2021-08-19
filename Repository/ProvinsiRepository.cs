using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrigamiEdu.Models;
using System.Linq;

namespace OrigamiEdu.Repository
{
    public class ProvinsiRepository
    {
        private readonly Context context;
        private readonly ILogger<ProvinsiRepository> logger;
        private readonly KabupatenKotaRepository kabupatenKotaRepository;

        public ProvinsiRepository(Context context, ILogger<ProvinsiRepository> logger, KabupatenKotaRepository kabupatenKotaRepository)
        {
            this.context = context;
            this.logger = logger;
            this.kabupatenKotaRepository = kabupatenKotaRepository;
        }

        public async Task<List<Provinsi>> readAll()
        {
            var result = context.Provinsis.ToListAsync();

            return await result;
        }
        public async Task<List<Provinsi>> readAllByID(string provinsiID)
        {
            var result = context.Provinsis.ToListAsync();

            foreach (var item in await result)
            {
                item.selected = item.ID.ToString() == provinsiID;
            }

            return await result;
        }
        public async Task<Provinsi> readOneByID(string provinsiID)
        {
            var result = context.Provinsis.FindAsync(new Guid(provinsiID));

            return await result;
        }

        public async Task<bool> add(Provinsi provinsi)
        {
            try
            {
                /* var provinsiModel = new Provinsi{
                    ID = new Guid(),
                    provinsi = provinsi.provinsi.Trim()
                }; */
                await context.AddAsync(provinsi);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> edit(Provinsi provinsi)
        {
            try
            {
                context.Update(provinsi);
                await context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> dumpProvinsi(Provinsi prov)
        {
            try
            {
                // ============================ start dump
                var dump = new ProvinsiDump{
                    ID = prov.ID,
                    provinsi = prov.provinsi
                };
                await context.AddAsync(dump);
                await context.SaveChangesAsync();
                // ============================ end dump
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> delete(Provinsi prov)
        {
            try
            {
                var kabs = (from k in context.KabupatenKotas join p in context.Provinsis on k.fkProvinsi.ID equals p.ID where p.ID == prov.ID select k).ToListAsync();

                foreach (var item in await kabs)
                {
                    if(!(await kabupatenKotaRepository.dumpKabupaten(item)))
                    {
                        return false;
                    }
                }
                // ============================ start delete provinsi
                if(!(await dumpProvinsi(prov)))
                {
                    return false;
                }
                context.Remove(prov);
                await context.SaveChangesAsync();
                // ============================ end delete
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }






        public async Task<List<ProvinsiDump>> readProvinsiDumpsAsync()
        {
            return await context.provinsiDumps.ToListAsync();
        }

        public async Task<bool> recover(ProvinsiDump dump)
        {
            try
            {
                if(!(await add(new Provinsi{ID = dump.ID, provinsi = dump.provinsi})))
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