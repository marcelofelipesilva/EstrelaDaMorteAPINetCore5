using Business.Entities;
using Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class EstrelaDaMorteDbContext : DbContext
    {
        public EstrelaDaMorteDbContext(DbContextOptions<EstrelaDaMorteDbContext>options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NaveMapping());
            modelBuilder.ApplyConfiguration(new PilotoMapping());
            modelBuilder.ApplyConfiguration(new PlanetaMapping());
            base.OnModelCreating(modelBuilder);
        }
       

        public DbSet<Nave> Naves { get; set; }
        public DbSet<Piloto> Pilotos { get; set; }
        public DbSet<Planeta> Planetas { get; set; }
        
    }
}