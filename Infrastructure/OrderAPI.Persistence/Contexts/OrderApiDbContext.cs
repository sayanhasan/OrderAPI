using Microsoft.EntityFrameworkCore;
using OrderAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Persistence.Contexts
{
    public class OrderApiDbContext : DbContext
    {
        public OrderApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ProductsBuilder
            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().Property(x => x.Quantity).HasColumnType("decimal(20,5)");
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(20,5)");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnType("varchar(500)");
            //one to many rs
            modelBuilder.Entity<Product>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region OrderBuilder
            modelBuilder.Entity<Order>().HasKey(x => x.Id);
            modelBuilder.Entity<Order>().Property(x => x.OrderDate).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Order>().Property(x => x.CustomerName).HasColumnType("varchar(500)");
            //one to many rs
            modelBuilder.Entity<Order>()
                .HasOne(x => x.Product)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>()
              .HasOne(x => x.Company)
              .WithMany(x => x.Orders)
              .HasForeignKey(x => x.CompanyId)
              .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region CompanyBuilder
            modelBuilder.Entity<Company>().HasKey(x => x.Id);
            modelBuilder.Entity<Company>().Property(x => x.OrderStartTime).HasColumnType("time");
            modelBuilder.Entity<Company>().Property(x => x.OrderEndTime).HasColumnType("time");
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
