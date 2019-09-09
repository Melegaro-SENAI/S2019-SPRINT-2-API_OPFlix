using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class OPFlixContext : DbContext
    {
        public OPFlixContext()
        {
        }

        public OPFlixContext(DbContextOptions<OPFlixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<FilmesEseries> FilmesEseries { get; set; }
        public virtual DbSet<Permissao> Permissao { get; set; }
        public virtual DbSet<Plataformas> Plataformas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        // Unable to generate entity type for table 'dbo.TipoCategoria'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2C3VBO6\\SQLEXPRESS; Initial Catalog=T_OPFlix;User Id=sa;Pwd=132 ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Categori__7D8FE3B2A998F077")
                    .IsUnique();

                entity.Property(e => e.IdCategoria).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FilmesEseries>(entity =>
            {
                entity.HasKey(e => e.IdFilmesEseries);

                entity.ToTable("FilmesESeries");

                entity.Property(e => e.IdFilmesEseries).HasColumnName("IdFilmesESeries");

                entity.Property(e => e.DataLançamento).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permissao>(entity =>
            {
                entity.HasKey(e => e.IdPermissao);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Plataformas>(entity =>
            {
                entity.HasKey(e => e.IdPlataforma);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Platafor__7D8FE3B2E6E3B196")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D105347043D847")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPermissaoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPermissao)
                    .HasConstraintName("FK__Usuarios__IdPerm__0F2D40CE");
            });
        }
    }
}
