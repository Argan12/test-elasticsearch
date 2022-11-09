using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Elasticsearch.Models
{
    public partial class ElasticsearchContext : DbContext
    {
        public ElasticsearchContext()
        {
        }

        public ElasticsearchContext(DbContextOptions<ElasticsearchContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<GetAlbums> GetAlbums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:ElasticsearchContext");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Album");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Artist).HasColumnName("ARTIST");

                entity.Property(e => e.Genres)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("GENRES");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("NAME");

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("YEAR");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Genres)
                    .HasMaxLength(250)
                    .HasColumnName("GENRES");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("NAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
