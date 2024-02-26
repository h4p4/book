using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RedBook
{
    public partial class RedBookContext : DbContext
    {
        public RedBookContext()
        {
        }

        public RedBookContext(DbContextOptions<RedBookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Family> Families { get; set; } = null!;
        public virtual DbSet<Genuse> Genuses { get; set; } = null!;
        public virtual DbSet<Species> Species { get; set; } = null!;
        public virtual DbSet<Squad> Squads { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=RedBook;Username=postgres;Password=1488");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Title)
                    .HasName("Classes_pkey");

                entity.ToTable("Classes", "RedBook");

                entity.Property(e => e.Title).HasColumnType("character varying");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.HasKey(e => e.Title)
                    .HasName("Families_pkey");

                entity.ToTable("Families", "RedBook");

                entity.Property(e => e.Title).HasColumnType("character varying");

                entity.Property(e => e.SquadTitle).HasColumnType("character varying");

                entity.HasOne(d => d.SquadTitleNavigation)
                    .WithMany(p => p.Families)
                    .HasForeignKey(d => d.SquadTitle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Families_SquadTitle_fkey");
            });

            modelBuilder.Entity<Genuse>(entity =>
            {
                entity.HasKey(e => e.Title)
                    .HasName("Genuses_pkey");

                entity.ToTable("Genuses", "RedBook");

                entity.Property(e => e.Title).HasColumnType("character varying");

                entity.Property(e => e.FamilyTitle).HasColumnType("character varying");

                entity.HasOne(d => d.FamilyTitleNavigation)
                    .WithMany(p => p.Genuses)
                    .HasForeignKey(d => d.FamilyTitle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Genuses_FamilyTitle_fkey");
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.HasKey(e => e.Title)
                    .HasName("Species_pkey");

                entity.ToTable("Species", "RedBook");

                entity.Property(e => e.Title).HasColumnType("character varying");

                entity.Property(e => e.Category).HasColumnType("character varying");

                entity.Property(e => e.Count).HasColumnType("character varying");

                entity.Property(e => e.Distribution).HasColumnType("character varying");

                entity.Property(e => e.GenusTitle).HasColumnType("character varying");

                entity.Property(e => e.Habitat).HasColumnType("character varying");

                entity.Property(e => e.Protection).HasColumnType("character varying");

                entity.HasOne(d => d.GenusTitleNavigation)
                    .WithMany(p => p.Species)
                    .HasForeignKey(d => d.GenusTitle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Species_GenusTitle_fkey");
            });

            modelBuilder.Entity<Squad>(entity =>
            {
                entity.HasKey(e => e.Title)
                    .HasName("Squads_pkey");

                entity.ToTable("Squads", "RedBook");

                entity.Property(e => e.Title).HasColumnType("character varying");

                entity.Property(e => e.ClassTitle).HasColumnType("character varying");

                entity.HasOne(d => d.ClassTitleNavigation)
                    .WithMany(p => p.Squads)
                    .HasForeignKey(d => d.ClassTitle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Squads_Class_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
