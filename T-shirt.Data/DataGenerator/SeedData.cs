using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_shirt_shop.Data;

namespace T_shirt.Data.Models.DataGenerator
{
    public static class SeedData
    {
        public static void Tshirts(ApplicationDbContext context)
        {
            if (!context.Products.Any())
            {
                var arsenal = new Product
                {
                    Name = "Arsenal"
                };

                var barcelona = new Product
                {
                    Name = "Barcelona"
                };

                var realMadrid = new Product
                {
                    Name = "Real Madrid"
                };

                var bayernMunchen = new Product
                {
                    Name = "Bayern Munchen"
                };

                context.Products.AddRange(arsenal, barcelona, realMadrid, bayernMunchen);
                context.SaveChanges();
                var arsenalTShirt = new Product
                {
                    Name = "Arsenal T-Shirt",
                    Description = "Official Arsenal T-Shirt",
                    Price = 140m,
                    ImageUrl = "/images/arsenal-t-shirt.jpg",
                };

                var barcelonaTShirt = new Product
                {
                    Name = "Barcelona T-Shirt",
                    Description = "Official Barcelona T-Shirt",
                    Price = 140m,
                    ImageUrl = "/images/barcelona-t-shirt.jpg",
                };

                var realMadridTShirt = new Product
                {
                    Name = "Real Madrid T-Shirt",
                    Description = "Official Real Madrid T-Shirt",
                    Price = 140m,
                    ImageUrl = "/images/real-madrid-t-shirt.jpg",
                };

                var bayernMunchenTShirt = new Product
                {
                    Name = "Bayern Munchen T-Shirt",
                    Description = "Official Bayern Munchen T-Shirt",
                    Price = 140m,
                    ImageUrl = "/images/bayern-munchen-t-shirt.jpg",
                };

                context.Products.AddRange(arsenalTShirt, barcelonaTShirt, realMadridTShirt, bayernMunchenTShirt);
                context.SaveChanges();
            }
        }
    }
}
