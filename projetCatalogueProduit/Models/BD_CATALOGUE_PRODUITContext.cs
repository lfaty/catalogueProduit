using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace projetCatalogueProduit.Models
{
    public partial class BD_CATALOGUE_PRODUITContext : DbContext
    {
        public BD_CATALOGUE_PRODUITContext()
        {
        }

        public BD_CATALOGUE_PRODUITContext(DbContextOptions<BD_CATALOGUE_PRODUITContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatCategorie> CatCategories { get; set; } = null!;
        public virtual DbSet<CatProduit> CatProduits { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-1AL2BBT\\SQLEXPRESS;Database=BD_CATALOGUE_PRODUIT;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatCategorie>(entity =>
            {
                entity.HasKey(e => e.CodeCategorie);

                entity.ToTable("CAT_CATEGORIE");

                entity.Property(e => e.CodeCategorie).HasColumnName("CODE_CATEGORIE");

                entity.Property(e => e.DateSaisie)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_SAISIE");

                entity.Property(e => e.LibelleCategorie).HasColumnName("LIBELLE_CATEGORIE");
            });

            modelBuilder.Entity<CatProduit>(entity =>
            {
                entity.HasKey(e => e.CodeProduit);

                entity.ToTable("CAT_PRODUIT");

                entity.Property(e => e.CodeProduit).HasColumnName("CODE_PRODUIT");

                entity.Property(e => e.CodeCategorie).HasColumnName("CODE_CATEGORIE");

                entity.Property(e => e.DateSaisie)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_SAISIE");

                entity.Property(e => e.DescriptionProduit).HasColumnName("DESCRIPTION_PRODUIT");

                entity.Property(e => e.ImageProduit).HasColumnName("IMAGE_PRODUIT");

                entity.Property(e => e.LibelleProduit)
                    .HasMaxLength(200)
                    .HasColumnName("LIBELLE_PRODUIT");

                entity.Property(e => e.UrlImageProduit).HasColumnName("URL_IMAGE_PRODUIT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
