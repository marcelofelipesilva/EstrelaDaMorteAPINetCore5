using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EstrelaDaMorteAPI.Configurations
{
    public class DbFactoryDbContext :  IDesignTimeDbContextFactory<EstrelaDaMorteDbContext>
    {
        public EstrelaDaMorteDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<EstrelaDaMorteDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            EstrelaDaMorteDbContext contexto = new EstrelaDaMorteDbContext(optionsBuilder.Options);
            return contexto;
        }
    }
}