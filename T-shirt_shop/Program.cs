using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using T_shirt.Data;
using T_shirt.Data.Models;
using T_shirt.Data.DataGenerator;
using T_shirt.Data.Models.Models;
using T_shirt_shop.Data;

namespace T_shirt_shop
{
    public class Program
    {
            public IConfiguration Configuration { get; set; }

        public Program(IConfiguration config)
        {
            Configuration = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<StoreDbContext>(opts =>
            {
                opts.UseSqlServer(Configuration["ConnectionStrings:SportsStoreConnection"]);
            });

            services.AddScoped<IStoreRepository, EFStoreRepository>();
            services.AddScoped<IOrderRepository, EFOrderRepository>();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddServerSideBlazor();

            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:IdentityConnection"]));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsProduction())
            {
                app.UseExceptionHandler("/error");
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("catpage", "{category}/Page{productPage:int}",
                    new { Controller = "Home", action = "Index" }
                );

                endpoints.MapControllerRoute("page", "Page{productPage:int}",
                    new { Controller = "Home", action = "Index", productPage = 1 }
                );

                endpoints.MapControllerRoute("category", "{category}",
                    new { Controller = "Home", action = "Index", productPage = 1 }
                );

                endpoints.MapControllerRoute("pagination", "Products/Page{productPage}",
                    new { Controller = "Home", action = "Index", productPage = 1 }
                );

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");
            });

          //  SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
