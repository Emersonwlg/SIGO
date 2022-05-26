using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigo.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sigo.Data.Mappings
{
    public class ConsultoriaAcessoriaMapping : IEntityTypeConfiguration<ConsultoriaAcessoria>
    {
        public void Configure(EntityTypeBuilder<ConsultoriaAcessoria> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.RazaoSocial)
               .IsRequired()
               .HasColumnType("varchar(200)");

            builder.Property(n => n.NomeFantasia)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(n => n.Cnpj)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(n => n.Periodo)
             .IsRequired();

            builder.Property(n => n.Setor)
              .IsRequired();

            builder.Property(n => n.DataInicio)
             .IsRequired();

            builder.Property(n => n.DataFim)
             .IsRequired();

            builder.Property(n => n.TipoDepartamento)
              .IsRequired();

            builder.Property(n => n.Descricao)
             .IsRequired()
             .HasColumnType("varchar(200)");

            builder.Property(n => n.Ativo)
              .IsRequired();

            builder.Property(n => n.IdTipoNormaExterna)
              .IsRequired();

            builder.ToTable("ConsultoriaAcessoria");
        }
    }
}
