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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=partystordb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relacion OrderDetail con Order
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order) 
                .WithMany(o => o.OrderDetails) 
                .HasForeignKey(od => od.OrderId);
            //Relacion Order con User
            modelBuilder.Entity<Order>()
                .HasOne(o=>o.User)
                .WithMany(u=>u.Orders)
                .HasForeignKey(o => o.UserId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
