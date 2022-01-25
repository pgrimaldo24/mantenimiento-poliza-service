using Interseguro.Mantenimiento.Poliza.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interseguro.Mantenimiento.Poliza.Repository.Implementations.Data.Configuration
{
    public class CredencialesConfiguration : IEntityTypeConfiguration<CredencialesEntity>
    {
        public void Configure(EntityTypeBuilder<CredencialesEntity> builder)
        {
            builder.HasKey(e => e.CodCredencial)
                   .HasName("PK__Credenci__EF710E2ED6A53B5A");
             
            builder.Property(e => e.CodCredencial).HasColumnName("cod_credencial");

            builder.Property(e => e.Contrasena)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contrasena");

            builder.Property(e => e.Usuario)
             .IsRequired()
             .HasMaxLength(50)
             .IsUnicode(false)
             .HasColumnName("usuario");

            builder.Property(e => e.Flag).HasColumnName("flag");

            builder.Property(e => e.FechaRegistro)
                      .HasColumnType("datetime")
                      .HasColumnName("fecha_registro")
                      .HasDefaultValueSql("(getdate())");
        }
    }
}
