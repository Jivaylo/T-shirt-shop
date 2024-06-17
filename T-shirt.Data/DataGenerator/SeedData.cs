using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_shirt.Data.Models;

namespace T_shirt.Data.DataGenerator
{
    public static class SeedData
    {
        public static void EnsurePopulated(this IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                     new Product
                     {
                         Name = "Barcelona T-Shirt",
                         Description = "Official Barcelona T-Shirt",
                         Category = "Football",
                         ImageUrl = "https://m.media-amazon.com/images/I/512eTK+cUNL._AC_SX679_.jpg",
                         Price = 140
                     },
                    new Product
                    {
                        Name = "Milan T-Shirt",
                        Description = "Official Milan T-Shirt",
                        Category = "Football",
                        ImageUrl = "https://www.tradeinn.com/f/13805/138053961/puma-ac-milan-home-21-22-t-shirt.jpg",
                        Price = 110
                    },
                    new Product
                    {
                        Name = "Bayern Munchen T-Shirt",
                        Description = "Official Bayern Munchen T-Shirt",
                        Category = "Football",
                        ImageUrl = "https://images.footballfanatics.com/bayern-munich/fc-bayern-adidas-home-shirt-2023-24_ss4_p-13375728+u-cmx2q37haxuzndsfy1fi+v-a461f452377b4db4b5fb14a4355518ae.jpg?_hv=2&w=900",
                        Price = 130
                    },
                    new Product
                    {
                        Name = "Arsenal T-Shirt",
                        Description = "Official Arsenal T-Shirt",
                        Category = "Football",
                        ImageUrl = "https://www.tradeinn.com/f/13739/137396714/adidas-arsenal-fc-home-20-21-t-shirt.jpg",
                        Price = 130
                    },
                    new Product
                    {
                        Name = "Real Madrid T-Shirt",
                        Description = "Official Real Madrid T-Shirt",
                        Category = "Football",
                        ImageUrl = "https://theshoppies.pk/wp-content/uploads/2023/06/Real-Madrid-2023-24-Home-jERSEY.jpg",
                        Price = 135
                    }
                
                );
                context.SaveChanges();
            }
        }
    }
}
