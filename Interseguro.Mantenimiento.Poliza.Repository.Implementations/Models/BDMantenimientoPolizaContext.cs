using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Interseguro.Mantenimiento.Poliza.Repository.Implementations.Models
{
    public partial class BDMantenimientoPolizaContext : DbContext
    {
        public BDMantenimientoPolizaContext()
        {
        }

        public BDMantenimientoPolizaContext(DbContextOptions<BDMantenimientoPolizaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Credenciale> Credenciales { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Poliza> Polizas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=BDMantenimientoPoliza;User Id=sa;Password=Peru123.;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credenciale>(entity =>
            {
                entity.HasKey(e => e.CodCredencial)
                    .HasName("PK__Credenci__EF710E2ED6A53B5A");

                entity.Property(e => e.CodCredencial).HasColumnName("cod_credencial");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contrasena");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Flag)
                    .HasColumnName("flag")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.CodPersona)
                    .HasName("PK__Persona__40188ACA87CF9EEE");

                entity.ToTable("Persona");

                entity.Property(e => e.CodPersona)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cod_persona");

                entity.Property(e => e.ApeMaterno)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ape_materno");

                entity.Property(e => e.ApePaterno)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ape_paterno");

                entity.Property(e => e.NomPersona)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nom_persona");
            });

            modelBuilder.Entity<Poliza>(entity =>
            {
                entity.HasKey(e => e.NumPoliza)
                    .HasName("PK__Poliza__A742136E220F750F");

                entity.ToTable("Poliza");

                entity.Property(e => e.NumPoliza)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("num_poliza");

                entity.Property(e => e.CodPersona)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cod_persona");

                entity.Property(e => e.FecInicioVigencia)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("fec_inicio_vigencia");

                entity.Property(e => e.Igv).HasColumnName("igv");

                entity.Property(e => e.MontoPrimaBruta)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("monto_prima_bruta");

                entity.Property(e => e.MontoPrimaNeta)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("monto_prima_neta");

                entity.HasOne(d => d.CodPersonaNavigation)
                    .WithMany(p => p.Polizas)
                    .HasForeignKey(d => d.CodPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Poliza");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
