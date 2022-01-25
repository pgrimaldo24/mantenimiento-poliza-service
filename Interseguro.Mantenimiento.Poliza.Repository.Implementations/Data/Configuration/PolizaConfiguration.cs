using Interseguro.Mantenimiento.Poliza.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interseguro.Mantenimiento.Poliza.Repository.Implementations.Data.Configuration
{
    public class PolizaConfiguration : IEntityTypeConfiguration<PolizaEntity>
    {
         public void Configure(EntityTypeBuilder<PolizaEntity> builder)
         {
            builder.HasKey(e => e.NumPoliza)
                     .HasName("PK__Poliza__A742136E220F750F");

            builder.ToTable("Poliza");

            builder.Property(e => e.NumPoliza)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("num_poliza");

            builder.Property(e => e.CodPersona)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cod_persona");

            builder.Property(e => e.FecInicioVigencia)
                 .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fec_inicio_vigencia");


            builder.Property(e => e.MontoPrimaBruta)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("monto_prima_bruta"); 

            builder.Property(e => e.Igv)
                .HasColumnType("int")
                .HasColumnName("igv");
             
            builder.Property(e => e.MontoPrimaNeta)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("monto_prima_neta");

            builder.HasOne(d => d.CodPersonaNavigation)
                .WithMany(p => p.Polizas)
                .HasForeignKey(d => d.CodPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Poliza");

            builder.Property(e => e.Status)
              .HasColumnType("bit")
              .HasColumnName("status")
              .HasDefaultValueSql("(1)");
        }
    }
}
