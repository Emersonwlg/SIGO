using Norma.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Norma.Data.Mappings
{
    public class NormaInternaMapping : IEntityTypeConfiguration<NormaInterna>
    {
        public void Configure(EntityTypeBuilder<NormaInterna> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Codigo)
               .IsRequired()
               .HasColumnType("varchar(200)");

            builder.Property(n => n.Titulo)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(n => n.TipoNorma)
              .IsRequired();

            builder.Property(n => n.DataPublicacao)
             .IsRequired();

            builder.Property(n => n.Autor)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(n => n.Ativo)
               .IsRequired();


            builder.ToTable("NormaInterna");
        }
    }
}