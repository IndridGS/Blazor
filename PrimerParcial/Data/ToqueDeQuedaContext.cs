using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Data
{
    public class ToqueDeQuedaContext: DbContext
    {

        public ToqueDeQuedaContext(DbContextOptions<ToqueDeQuedaContext> options)
            : base(options) { }

        public DbSet<Persona> Personas{ get; set; }
        public DbSet<Vehiculo> vehiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
                        .HasOne(p => p.Vehiculo)
                        .WithOne(p => p.Persona)
                        .HasForeignKey<Vehiculo>(p => p.PersonaId);
            base.OnModelCreating(modelBuilder);
        }
    }

}
