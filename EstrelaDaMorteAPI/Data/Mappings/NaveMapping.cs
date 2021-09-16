using Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class NaveMapping : IEntityTypeConfiguration<Nave>
    {
        public void Configure(EntityTypeBuilder<Nave> builder)
        {
            builder.ToTable("TB_NAVE");
            builder.HasKey(p => p.IdNave);
            builder.Property(p => p.IdNave).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome);
            builder.Property(p => p.Modelo);
            builder.Property(p => p.Passageiros);
            builder.Property(p => p.Carga);
            builder.Property(p => p.Classe);
          
        }
    }
}