using Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class PilotoMapping : IEntityTypeConfiguration<Piloto>
    {
        public void Configure(EntityTypeBuilder<Piloto> builder)
        {
            builder.ToTable("TB_PILOTO");
            builder.HasKey(p => p.IdPiloto);
            builder.Property(p => p.IdPiloto).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome);
            builder.Property(p => p.AnoNascimento);
            builder.HasOne(p => p.Planeta)
                .WithMany().HasForeignKey(fk => fk.IdPlaneta);
        }
    }
}