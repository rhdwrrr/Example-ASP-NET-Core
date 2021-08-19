using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using OrigamiEdu.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using OrigamiEdu.Helper;

namespace OrigamiEdu.Repository
{
    public class KelasRepository
    {
        private readonly Context context;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ILogger<KelasRepository> logger;

        public KelasRepository(Context context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<KelasRepository> logger)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.logger = logger;
        }

        public async Task<List<kelas>> getKelasAsync()
        {
            return await (from k in context.kelas 
                          join u in userManager.Users on k.fkCreator.Id equals u.Id
                          select new kelas{
                              ID = k.ID,
                              nama = k.nama,
                              kreator = u.UserName,
                              userGuide = k.userGuide,
                              createdDate = k.createdDate,
                              isArchived = k.isArchived,
                              isPrivate = k.isPrivate
                          }).ToListAsync();
        }

        public async Task<kelas> getKelasSingleAsync(string key)
        {
            return await (from k in context.kelas where k.ID.ToString() == key
                          join u in userManager.Users on k.fkCreator.Id equals u.Id
                          select new kelas{
                              ID = k.ID,
                              nama = k.nama,
                              kreator = u.UserName,
                              userGuide = k.userGuide,
                              isArchived = k.isArchived,
                              isPrivate = k.isPrivate,
                              createdDate = k.createdDate,
                          }).FirstOrDefaultAsync();;
        }

        public async Task<kelas> getKelasSingleNonQuery(string key)
        {
            return await context.kelas.FirstOrDefaultAsync(i => i.ID.ToString() == key);
        }

        public async Task<bool> isKelasAvailable(string key)
        {
            return  await context.kelas.FirstOrDefaultAsync(k => k.ID == key) == null;
        }

        public async Task<Int32> countKelasAsync()
        {
            return await context.kelas.CountAsync();
        }

        private string randomizeCharacterAZNumeric(int val)
        {
            Random random = new Random();
            var charSet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var result = "";
            for (int i = 0; i < val; i++)
            {
                result += charSet[random.Next(charSet.Length)];
            }
            return result;
        }
        public async Task<string> getIDKelas()
        { 
            string key = randomizeCharacterAZNumeric(8);
            do
            {
                key = randomizeCharacterAZNumeric(8);
            } while (!(await isKelasAvailable(key)));

            return key;
        }

        public async Task<bool> addKelasAsync(kelas _kelas)
        {
            try
            {
                // Add Kelas //
                _kelas.ID = await getIDKelas();

                await context.AddAsync(_kelas);
                await context.SaveChangesAsync();
                //==========//

                // Add Member to Kelas //
                if(!(await assignMemberToKelasAsync(_kelas, _kelas.fkCreator, true)))
                {
                    return false;
                }             
                //=====================//
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }

        public async Task<bool> assignMemberToKelasAsync(kelas _kelas, AppUser _user, bool creator)
        {
            try
            {
                var CP = new classParticipant{
                    ID = new Guid(),
                    fkKelas = _kelas,
                    timestamp = DateTime.Now,
                    account = _user,
                    isBannedToPost = false,
                    isCreator = creator
                };

                /* Orang => nama;
                Mahasiswa impelement orang => nama, nim
                Orang orang = new Mahasiswa();
                Orang.nim
                await context.AddAsync(CP); */
                await context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> editKelasAsync(kelas _kelas)
        {
            try
            {
                context.Update(_kelas);
                await context.SaveChangesAsync();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> archieveKelasAsync(string key, bool check)
        {
            try
            {
                var kls = context.kelas.FirstOrDefault(k => k.ID.ToString() == key);
                if(check)
                {
                    kls.isArchived = true;
                }else
                {
                    kls.isArchived = false;
                }

                context.Update(kls);
                await context.SaveChangesAsync();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async Task<bool> isKelasPrivate(string key)
        {
            var kls = await context.kelas.FirstOrDefaultAsync(k => k.ID.ToString() == key);

            return kls.isPrivate;
        }

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++    Kelas Post

        // public async Task<>
        


    }
}