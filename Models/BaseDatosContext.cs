using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TransferenciApi.Models
{
    public partial class BaseDatosContext : DbContext
    {
        public BaseDatosContext()
        {
        }

        public BaseDatosContext(DbContextOptions<BaseDatosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cuentum> Cuenta { get; set; }
        public virtual DbSet<Movimiento> Movimientos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IO027G9\\SQLEXPRESS;DataBase=BaseDatos;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contrasenia)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("contrasenia");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("genero");

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("identificacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Cuentum>(entity =>
            {
                entity.HasKey(e => e.Numero)
                    .HasName("PK__cuenta__5138EEC71FAE4CF6");

                entity.ToTable("cuenta");

                entity.Property(e => e.Numero)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Saldo)
                    .HasColumnType("money")
                    .HasColumnName("saldo");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cuenta_cuenta");
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.ToTable("movimiento");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.MovimientoValor)
                    .HasColumnType("money")
                    .HasColumnName("movimiento_valor");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.Property(e => e.SaldoActual)
                    .HasColumnType("money")
                    .HasColumnName("saldo_actual");

                entity.Property(e => e.SaldoInicial)
                    .HasColumnType("money")
                    .HasColumnName("saldo_inicial");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.NumeroNavigation)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.Numero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movimiento_cuenta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
