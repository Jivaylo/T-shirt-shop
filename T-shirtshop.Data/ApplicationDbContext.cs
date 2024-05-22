using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using T_shirtshop.Data.Models;

namespace T_shirt_shop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TShirt> TShirts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }

      //  public void Seed()
      //  {
      //      if (!this.ShirtSizes.Any())
       //     {
        //        this.ShirtSizes.Add(new ShirtSize { Name = "S", Price = 77, SortPriority = 10 });
         //       this.ShirtSizes.Add(new ShirtSize { Name = "M", Price = 149, SortPriority = 20 });
         //       this.ShirtSizes.Add(new ShirtSize { Name = "L", Price = 149, SortPriority = 30 });
         //       this.ShirtSizes.Add(new ShirtSize { Name = "XL", Price = 149, SortPriority = 40 });
         //       this.ShirtSizes.Add(new ShirtSize { Name = "XXL", Price = 149, SortPriority = 50 });
         //       this.ShirtSizes.Add(new ShirtSize { Name = "XXXL", Price = 159, SortPriority = 60 });
         //   }
          //  if (!this.ShirtTypes.Any())
          //  {
          //      this.ShirtTypes.Add(new ShirtType { Name = "Adidas", SortPriority = 10 });
          //      this.ShirtTypes.Add(new ShirtType { Name = "Puma", SortPriority = 20 });
          //      this.ShirtTypes.Add(new ShirtType { Name = "Nike", SortPriority = 30 });
           // }
           // this.SaveChanges();
       // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasKey(t => t.Id);
            modelBuilder.Entity<TShirt>().HasKey(t => t.Id);
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<OrderItem>().HasKey(oi => oi.Id);
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);

            modelBuilder.Entity<Team>().Property(t => t.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<TShirt>().Property(t => t.Price).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.OrderDate).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(c => c.Email).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.TShirtId });

            modelBuilder.Entity<OrderItem>()
                .HasOne<Order>(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}