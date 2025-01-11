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
        //Agregar las clases para la BD
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=peliculacodefirst;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Genre) //Esto indica que Movie tiene una propiedad de navegación llamada Genre que apunta a una única entidad Genre.
                .WithMany(g => g.Movies) //Aquí defines que Genre tiene una colección de películas (Movies) como propiedad de navegación.
                .HasForeignKey(m => m.GenreId);//Indica que la relación se establece mediante una clave foránea en la tabla Movie.

            
            base.OnModelCreating(modelBuilder);
        }

    }
}
