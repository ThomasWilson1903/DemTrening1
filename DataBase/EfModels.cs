using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DemTrening1.DataBase.Entity;

namespace DemTrening1.DataBase
{
    public partial class EfModels : DbContext
    {

        private static EfModels _instance;
        public static EfModels init()
        {
            if(_instance == null)
            {
                _instance = new EfModels();
            }
            return _instance;
        }


        public EfModels()
        {
        }

        public EfModels(DbContextOptions<EfModels> options)
            : base(options)
        {
        }

        public virtual DbSet<Cone> Cones { get; set; } = null!;
        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<IngredientsHasCone> IngredientsHasCones { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=cfif31.ru;port=3306;user id=ISPr22-33_BirukovAA;password=ISPr22-33_BirukovAA;database=ISPr22-33_BirukovAA_DemTrening1;character set=utf8", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Cone>(entity =>
            {
                entity.HasKey(e => e.IdCones)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdCones).HasColumnName("idCones");

                entity.Property(e => e.NumberCones).HasMaxLength(45);
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.Idingredients)
                    .HasName("PRIMARY");

                entity.ToTable("ingredients");

                entity.Property(e => e.Idingredients).HasColumnName("idingredients");

                entity.Property(e => e.Name).HasMaxLength(45);
            });

            modelBuilder.Entity<IngredientsHasCone>(entity =>
            {
                entity.HasKey(e => new { e.IngredientsIdingredients, e.ConesIdCones })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("ingredients_has_Cones");

                entity.HasIndex(e => e.ConesIdCones, "fk_ingredients_has_Cones_Cones1_idx");

                entity.HasIndex(e => e.Worker, "fk_ingredients_has_Cones_Worker_idx");

                entity.HasIndex(e => e.IngredientsIdingredients, "fk_ingredients_has_Cones_ingredients_idx");

                entity.Property(e => e.IngredientsIdingredients)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ingredients_idingredients");

                entity.Property(e => e.ConesIdCones).HasColumnName("Cones_idCones");

                entity.Property(e => e.Time).HasColumnType("time");

                entity.HasOne(d => d.ConesIdConesNavigation)
                    .WithMany(p => p.IngredientsHasCones)
                    .HasForeignKey(d => d.ConesIdCones)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ingredients_has_Cones_Cones1");

                entity.HasOne(d => d.IngredientsIdingredientsNavigation)
                    .WithMany(p => p.IngredientsHasCones)
                    .HasForeignKey(d => d.IngredientsIdingredients)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ingredients_has_Cones_ingredients");

                entity.HasOne(d => d.WorkerNavigation)
                    .WithMany(p => p.IngredientsHasCones)
                    .HasForeignKey(d => d.Worker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ingredients_has_Cones_Worker");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(e => e.Idworker)
                    .HasName("PRIMARY");

                entity.ToTable("worker");

                entity.Property(e => e.Idworker).HasColumnName("idworker");

                entity.Property(e => e.DoubleName).HasMaxLength(45);

                entity.Property(e => e.NameWorker).HasMaxLength(45);

                entity.Property(e => e.SurNameWorker).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
