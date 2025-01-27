using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Million.Dominio.Entidades;

namespace Million.Persistencia.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets para cada entidad
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<PropertyTrace> PropertyTraces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de claves primarias
            modelBuilder.Entity<Owner>().HasKey(o => o.IdOwner);
            modelBuilder.Entity<Property>().HasKey(p => p.IdProperty);
            modelBuilder.Entity<PropertyImage>().HasKey(pi => pi.IdPropertyImage);
            modelBuilder.Entity<PropertyTrace>().HasKey(pt => pt.IdPropertyTrace);

            // Relaciones
            modelBuilder.Entity<Property>()
                .HasOne(p => p.Owner)
                .WithMany(o => o.Properties)
                .HasForeignKey(p => p.IdOwner);

            modelBuilder.Entity<PropertyImage>()
                .HasOne(pi => pi.Property)
                .WithMany(p => p.PropertyImages)
                .HasForeignKey(pi => pi.IdProperty);

            modelBuilder.Entity<PropertyTrace>()
                .HasOne(pt => pt.Property)
                .WithMany(p => p.PropertyTraces)
                .HasForeignKey(pt => pt.IdProperty);
        }
    }
}
