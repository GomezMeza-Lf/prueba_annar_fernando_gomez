using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace prueba_fernando_gomez.Models
{
    public partial class prueba_fernando_gomezContext : DbContext
    {
        public prueba_fernando_gomezContext()
        {
        }

        public prueba_fernando_gomezContext(DbContextOptions<prueba_fernando_gomezContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbEstadoAfiliacion> TbEstadoAfiliacions { get; set; } = null!;
        public virtual DbSet<TbPaciente> TbPacientes { get; set; } = null!;
        public virtual DbSet<TbTipoDeDocumento> TbTipoDeDocumentos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-RHPIS5R;Database=prueba_fernando_gomez;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbEstadoAfiliacion>(entity =>
            {
                entity.HasKey(e => e.IdAfiliacion)
                    .HasName("PK__tb_estad__BBF1A6EEBE6E08AE");

                entity.ToTable("tb_estadoAfiliacion");

                entity.Property(e => e.IdAfiliacion).HasColumnName("idAfiliacion");

                entity.Property(e => e.EstadoAfiliacion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("estadoAfiliacion");
            });

            modelBuilder.Entity<TbPaciente>(entity =>
            {
                entity.HasKey(e => e.IdPacientes)
                    .HasName("PK__tb_pacie__EA2131FD7106B1D7");

                entity.ToTable("tb_pacientes");

                entity.Property(e => e.IdPacientes).HasColumnName("idPacientes");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(100)
                    .HasColumnName("correoElectronico");

                entity.Property(e => e.FechaDeNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaDeNacimiento");

                entity.Property(e => e.IdAfiliacion).HasColumnName("idAfiliacion");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("idTipoDocumento");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.NumeroDeDocumento).HasColumnName("numeroDeDocumento");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdAfiliacionNavigation)
                    .WithMany(p => p.TbPacientes)
                    .HasForeignKey(d => d.IdAfiliacion)
                    .HasConstraintName("FK__tb_pacien__idAfi__4222D4EF");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.TbPacientes)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .HasConstraintName("FK__tb_pacien__idTip__412EB0B6");
            });

            modelBuilder.Entity<TbTipoDeDocumento>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento)
                    .HasName("PK__tb_tipoD__61FDF9F5AE8DE113");

                entity.ToTable("tb_tipoDeDocumento");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("idTipoDocumento");

                entity.Property(e => e.NombreTipoDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreTipoDocumento");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
