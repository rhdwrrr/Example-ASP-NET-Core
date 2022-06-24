using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OrigamiEdu.Models
{
    public class Context : IdentityDbContext<AppUser>
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        // ============================= ACTIVE DB ============================== //
        public DbSet<Provinsi> Provinsis { get; set; }
        public DbSet<KabupatenKota> KabupatenKotas { get; set; }
        public DbSet<Sekolah> Sekolahs { get; set; }
        public DbSet<KategoriSekolah> kategoriSekolahs { get; set; }
        public DbSet<Universitas> universitas { get; set; }
        public DbSet<KategoriUniversitas> kategoriUniversitas { get; set; }
        public DbSet<statistikUniversitas> statistikUnivs { get; set; }
        public DbSet<kelas> kelas { get; set; }
        public DbSet<classParticipant> classParticipants { get; set; }
        public DbSet<notification> notifications { get; set; }
        public DbSet<adminNotification> adminNotifications { get; set; }
        public DbSet<dumpedUserFromClass> dumpedUserFromClasses { get; set; }
        // ====================================================================== //

        // ======================== DUMPED REGISTRY DB ========================== //
        public DbSet<ProvinsiDump> provinsiDumps { get; set; }
        public DbSet<KabupatenKotaDump> kabupatenKotaDumps { get; set; }
        public DbSet<SekolahDump> sekolahDumps { get; set; }
        public DbSet<UniversitasDump> universitasDumps { get; set; }
        // ====================================================================== //




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<notification>(f => {
                f.HasNoKey();
            });
            builder.Entity<adminNotification>(f => {
                f.HasNoKey();
            });
            builder.Entity<dumpedUserFromClass>(f => {
                f.HasNoKey();
            });


            
            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
              foreignKey.DeleteBehavior = DeleteBehavior.Cascade;  
            }
        }

        private void SeedAllUsersData(ModelBuilder builder){
            Guid RoleId_SuperAdmin = Guid.NewGuid();
            Guid RoleId_User = Guid.NewGuid();
            while (RoleId_SuperAdmin == RoleId_User)
            {
                RoleId_User = Guid.NewGuid();
            }

            #region [Seed Role]
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole{
                    Id = RoleId_SuperAdmin.ToString(),
                    Name = "SuperAdmin",
                    ConcurrencyStamp = "1",
                    NormalizedName = "Admin"
                },
                new IdentityRole{
                    Id = RoleId_User.ToString(),
                    Name = "User",
                    ConcurrencyStamp = "2",
                    NormalizedName = "User"
                }
            );
            #endregion
            
            var SuperAdminID = Guid.NewGuid();

            #region [Seed User]
                AppUser user = new AppUser{
                    Id = SuperAdminID.ToString(),
                    UserName = "admin",
                    LockoutEnabled = false,
                    Email = "admin@dummy.com"
                };
                PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
                passwordHasher.HashPassword(user, "Admin*123456");
                builder.Entity<AppUser>().HasData(user);
            #endregion

            #region  [Seed UserRole]
                builder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>{
                        RoleId = RoleId_SuperAdmin.ToString(),
                        UserId = SuperAdminID.ToString()
                    }
                );
            #endregion
        }
    }
}