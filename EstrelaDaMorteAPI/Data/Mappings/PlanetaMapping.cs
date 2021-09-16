using Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class PlanetaMapping : IEntityTypeConfiguration<Planeta>
    {
        public void Configure(EntityTypeBuilder<Planeta> builder)
        {
            builder.ToTable("TB_PLANETA");
            builder.HasKey(p => p.IdPlaneta);
            builder.Property(p => p.IdPlaneta).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome);
            builder.Property(p => p.Orbita);
            builder.Property(p => p.Clima);
            builder.Property(p => p.Populacao);
            builder.Property(p => p.Rotacao);
            builder.Property(p => p.Diametro);
        }
    }
}