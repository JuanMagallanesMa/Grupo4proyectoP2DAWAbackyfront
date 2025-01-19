using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public class PartyContext : DbContext
    {
        public PartyContext(DbContextOptions<PartyContext> options) : base(options)
        { }

        //Agregar las clases para la BD
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Promociones> Promotions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=PruebaDB3Party;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relacion OrderDetail con Order
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order) 
                .WithMany(o => o.OrderDetails) 
                .HasForeignKey(od => od.OrderId);
            //Relacion OrderDetail con Product
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId);
            //Rekacion Product con Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(p => p.CategoryId);

        //Relacion Promociones con Category

        modelBuilder.Entity<Promociones>()
                .HasOne(p =>p.Categoria)
                .WithMany(c => c.Promociones)
                .HasForeignKey(p => p.Id_categoria);

            base.OnModelCreating(modelBuilder);
        }

    }
}
