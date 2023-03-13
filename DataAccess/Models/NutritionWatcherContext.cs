using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class NutritionWatcherContext : DbContext
    {
        public NutritionWatcherContext()
        {
        }

        public NutritionWatcherContext(DbContextOptions<NutritionWatcherContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<MealLog> MealLogs { get; set; } = null!;
        public virtual DbSet<MealLogItem> MealLogItems { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=(local); database=NutritionWatcher;user=sa;password=123456;Integrated Security=true;TrustServerCertificate=Yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__login__CB9A1CDFF9EEE156");

                entity.ToTable("login");

                entity.HasIndex(e => e.Username, "UQ__login__F3DBC57206A45053")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("userID");

                entity.Property(e => e.GoogleId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("GoogleID");

                entity.Property(e => e.IsBanned).HasColumnName("isBanned");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("passwordHash");

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("passwordSalt");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Login)
                    .HasForeignKey<Login>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__login__userID__4CA06362");
            });

            modelBuilder.Entity<MealLog>(entity =>
            {
                entity.ToTable("mealLog");

                entity.Property(e => e.MealLogId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mealLogID");

                entity.Property(e => e.LogDate)
                    .HasColumnType("date")
                    .HasColumnName("logDate");

                entity.Property(e => e.LogNote)
                    .HasColumnType("text")
                    .HasColumnName("logNote");

                entity.Property(e => e.LogTime).HasColumnName("logTime");

                entity.Property(e => e.MealLogName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("mealLogName");

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MealLogs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mealLog__userID__4F7CD00D");
            });

            modelBuilder.Entity<MealLogItem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__mealLogI__56A1284AC8FB9850");

                entity.ToTable("mealLogItem");

                entity.Property(e => e.ItemId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("itemID");

                entity.Property(e => e.ActualWeight).HasColumnName("actualWeight");

                entity.Property(e => e.CaloriePerServing).HasColumnName("caloriePerServing");

                entity.Property(e => e.CarbPerServing).HasColumnName("carbPerServing");

                entity.Property(e => e.FatPerServing).HasColumnName("fatPerServing");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("itemName");

                entity.Property(e => e.MealLogId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mealLogID");

                entity.Property(e => e.ProteinPerServing).HasColumnName("proteinPerServing");

                entity.Property(e => e.ServingWeight).HasColumnName("servingWeight");

                entity.HasOne(d => d.MealLog)
                    .WithMany(p => p.MealLogItems)
                    .HasForeignKey(d => d.MealLogId)
                    .HasConstraintName("FK__mealLogIt__mealL__52593CB8");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("userID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("lastName");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
