using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryMaJononi.Data;
using InventoryMaJononi.Data.Entity;
using InventoryMaJononi.Service;
using InventoryMaJononi.Service.Interface;
using InventoryMaJononi.ServiceMasterData;
using InventoryMaJononi.ServiceMasterData.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryMaJononi
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region ERP Database Settings

            services.AddDbContext<InventoryMaJononiDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("InventoryConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<InventoryMaJononiDbContext>()
                .AddDefaultTokenProviders();
            #endregion

            #region Auth Related Settings
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(12);
                //options.Lockout.MaxFailedAccessAttempts = 5;
                //options.Lockout.AllowedForNewUsers = true;

                //// User settings.
                //options.User.AllowedUserNameCharacters =
                //    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                //options.User.RequireUniqueEmail = false;
            });

            #endregion


            services.AddSession(options =>
            {
                options.Cookie.Name = ".AdventureWorks.Session";
                options.IdleTimeout = TimeSpan.FromHours(24);
                options.Cookie.IsEssential = true;
            });

            #region Service

            services.AddScoped<IEmployeeCodeService, EmployeeCodeService>();
            services.AddScoped<IUserService, UserService>();

            #endregion

            #region MasterDat

            services.AddScoped<IBranchService, BranchService>();

            #endregion

            #region Areas Config
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/areas/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/areas/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();
            app.UseSession();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
