using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace tallerbaseAngelo.Models
{
    public partial class tallerBackendRubioMeroContext : DbContext
    {
        public tallerBackendRubioMeroContext()
        {
        }

        public tallerBackendRubioMeroContext(DbContextOptions<tallerBackendRubioMeroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genero> Generos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; DataBase=tallerBackendRubioMero;Trusted_Connection=True; TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.HasIndex(e => e.GeneroId, "IX_Usuario_GeneroId");

                entity.Property(e => e.Clave)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsario)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Genero)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.GeneroId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
