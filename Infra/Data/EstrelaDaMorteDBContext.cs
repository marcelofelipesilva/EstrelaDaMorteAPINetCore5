using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class EstrelaDaMorteDBContext : DbContext
    {
        public EstrelaDaMorteDBContext(DbContextOptions<EstrelaDaMorteDBContext>options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Server=172.17.0.6;Database=SchoolDB;User Id=sa;Password=App@12345;");
        }
        
        
    }
}