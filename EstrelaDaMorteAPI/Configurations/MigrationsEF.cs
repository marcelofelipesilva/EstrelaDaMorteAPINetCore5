using System.Linq;
using Infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EstrelaDaMorteAPI.Configurations
{
    public static class EntityFrameworkExtensions
    {
        public static IApplicationBuilder UseApplyMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var EstrelaDaMorteDbContext = serviceScope.ServiceProvider.GetService<EstrelaDaMorteDbContext>())
                {
                    var migracoesPendentes = EstrelaDaMorteDbContext.Database.GetPendingMigrations();

                    if (migracoesPendentes.Count() == 0)
                    {
                        return app;
                    }

                    EstrelaDaMorteDbContext.Database.Migrate();
                }
            }
            return app;
        }
    }
}