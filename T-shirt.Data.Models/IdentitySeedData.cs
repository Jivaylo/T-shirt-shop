using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace T_shirt.Data.Models.Models
{
    public static class IdentitySeedData
    {
        private const string adminRole = "Admin";

        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";
        public static async void EnsurePopulatedIdentity(this IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<StoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            using (var scope = app.ApplicationServices.CreateScope()) 
            {
            
                UserManager<ApplicationUser> userManager = scope.ServiceProvider
                .GetRequiredService<UserManager<ApplicationUser>>();

                RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(adminRole))
                    await roleManager.CreateAsync(new IdentityRole { Name = adminRole });

                ApplicationUser user = await userManager.FindByNameAsync(adminUser);
                if (user == null)
                {
                    user = new ApplicationUser();
                    user.UserName = adminUser;
                    user.Email = "admin@example.com";
                    user.PhoneNumber = "555-1234";
                    IdentityResult result = await userManager.CreateAsync(user, adminPassword);
                }

                await userManager.AddToRoleAsync(user, adminRole);
            }
        }
    }
}