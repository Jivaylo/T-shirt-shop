using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace T_shirt.Data.Models.Models
{
    public static class IdentitySeedData
    {
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
            UserManager<ApplicationUser> userManager = app.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<UserManager<ApplicationUser>>();
            ApplicationUser user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "admin@example.com";
                user.PhoneNumber = "555-1234";
                IdentityResult result = await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}