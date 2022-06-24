using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrigamiEdu.Models;
using OrigamiEdu.Repository;
using OrigamiEdu.Services;

namespace OrigamiEdu
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ========================= DEPENDENCY INJECTION ========================= //
            services.AddIdentity<AppUser, IdentityRole>(options => {
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();
            
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("mssql")))
            ;
            services.AddTransient<ProvinsiRepository>();
            services.AddTransient<KabupatenKotaRepository>();
            services.AddTransient<SekolahRepository>();
            services.AddTransient<UniversitasRepository>();
            services.AddTransient<KelasRepository>();
            services.AddTransient<httpServices>();
            services.AddTransient<dateManagement>();
            services.AddHttpContextAccessor();
            // ======================================================================== //
            services.AddControllersWithViews();

            services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/Akun/Masuk";
                options.Cookie.Name = "origamiEdu";
                options.AccessDeniedPath = "/Akun/aksesDitolak";
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Administrator",
                    areaName : "Administrator",
                    pattern: "Administrator/{controller=Administrator}/{action=index}/{id?}"
                );
                /* endpoints.MapAreaControllerRoute(
                    name: "Kelas",
                    areaName : "Kelas",
                    pattern: "{controller=kelas}/{action=index}/{id?}"
                ); */
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{post?}"
                );
            });
        }
    }
}
