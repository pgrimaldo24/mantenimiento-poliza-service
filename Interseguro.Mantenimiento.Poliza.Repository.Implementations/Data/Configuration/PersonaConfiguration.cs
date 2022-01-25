using Interseguro.Mantenimiento.Poliza.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interseguro.Mantenimiento.Poliza.Repository.Implementations.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<PersonaEntity>
    {
        public void Configure(EntityTypeBuilder<PersonaEntity> builder)
        {
            builder.HasKey(e => e.CodPersona)
                     .HasName("PK__Persona__40188ACA87CF9EEE");

            builder.ToTable("Persona");

            builder.Property(e => e.CodPersona)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cod_persona");

            builder.Property(e => e.ApeMaterno)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ape_materno");

            builder.Property(e => e.ApePaterno)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ape_paterno");

            builder.Property(e => e.NomPersona)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nom_persona");
        }
    }
}
