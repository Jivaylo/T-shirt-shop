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
        private const string adminPassword = "123456";
        public static async void EnsurePopulatedIdentity(this IApplicationBuilder app)
        {

            RoleManager<IdentityRole> roleManager = app.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();

            await roleManager.CreateAsync(new IdentityRole("Admin"));


            StoreDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<StoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            UserManager<ApplicationUser> userManager = app.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<UserManager<ApplicationUser>>();
            ApplicationUser user = await userManager.FindByNameAsync(adminUser);
            if (user == null)
            {
                user = new ApplicationUser();
                user.UserName = adminUser;
                user.Email = "admin@mal.com";
                user.PhoneNumber = "555-1234";
                IdentityResult result = await userManager.CreateAsync(user, adminPassword);
            }

            if (!await userManager.IsInRoleAsync(user, "Admin"))
            {
                var rolesAddResult = await userManager.AddToRoleAsync(user, "Admin");

                var roless = await userManager.GetRolesAsync(user);
            }
        }
    }
}