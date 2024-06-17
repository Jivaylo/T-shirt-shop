using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using T_shirt.Data;
using T_shirt.Data.Models;
using T_shirt.Data.DataGenerator;
using T_shirt.Data.Models.Models;
using Microsoft.AspNetCore.Builder;

namespace T_shirt_shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("StoreDbContextConnection") ?? throw new InvalidOperationException("Connection string 'StoreDbContextConnection' not found.");

            builder.Services.AddDbContext<StoreDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services
                .AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<StoreDbContext>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
            builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();
            builder.Services.AddSingleton<Cart>();

            WebApplication app = builder.Build();

            // After the app is built the order of middlewares matter!

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            //app.MapDefaultControllerRoute();

            app.MapRazorPages();
            app.EnsurePopulated();
            app.EnsurePopulatedIdentity();
            
            app.Run();
        }
    }
}
