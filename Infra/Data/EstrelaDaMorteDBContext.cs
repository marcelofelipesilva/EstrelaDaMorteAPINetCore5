using Business.Entities;
using Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class EstrelaDaMorteDBContext : DbContext
    {
        public EstrelaDaMorteDBContext(DbContextOptions<EstrelaDaMorteDBContext>options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NaveMapping());
            modelBuilder.ApplyConfiguration(new PilotoMapping());
            modelBuilder.ApplyConfiguration(new PlanetaMapping());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Server=172.17.0.6;Database=EstrelaDaMorte;User Id=sa;Password=App@12345;");
        }

        public DbSet<Nave> Naves { get; set; }
        public DbSet<Piloto> Pilotos { get; set; }
        public DbSet<Planeta> Planetas { get; set; }
        
    }
}