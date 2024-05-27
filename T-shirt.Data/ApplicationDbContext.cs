using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using T_shirt.Data.Models;

namespace T_shirt_shop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<ShoppingCartItem>().HasKey(sci => sci.Id);
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<OrderItem>().HasKey(oi => oi.Id);
            modelBuilder.Entity<ApplicationUser>().HasKey(u => u.Id);

            modelBuilder.Entity<OrderItem>()
                .HasOne<Order>(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne<Product>(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne<ApplicationUser>(o => o.ApplicationUser)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.ApplicationUser) 
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}