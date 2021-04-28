using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Games.DAL.Entitites
{
    public partial class db_gamesContext : DbContext
    {
        public db_gamesContext()
        {
        }

        public db_gamesContext(DbContextOptions<db_gamesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=164.68.113.2;port=3306;user=sebas;password=IesPabloPicasso;database=db_games");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PRIMARY");

                entity.ToTable("category");

                entity.Property(e => e.IdCategory)
                    .HasColumnName("id_category")
                    .HasColumnType("int(4)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasKey(e => e.IdGame)
                    .HasName("PRIMARY");

                entity.ToTable("games");

                entity.HasIndex(e => e.FkIdCategory)
                    .HasName("Category_FK");

                entity.HasIndex(e => e.FkUsername)
                    .HasName("Users_FK");

                entity.Property(e => e.IdGame)
                    .HasColumnName("id_game")
                    .HasColumnType("int(4)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.FkIdCategory)
                    .HasColumnName("fk_id_category")
                    .HasColumnType("int(4)");

                entity.Property(e => e.FkUsername)
                    .IsRequired()
                    .HasColumnName("fk_username")
                    .HasMaxLength(25);

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasColumnType("int(4)");

                entity.Property(e => e.LaunchDate)
                    .HasColumnName("launch_date")
                    .HasColumnType("date");

                entity.Property(e => e.Multiplayer).HasColumnName("multiplayer");

                entity.Property(e => e.Platform)
                    .IsRequired()
                    .HasColumnName("platform")
                    .HasMaxLength(255);

                entity.Property(e => e.Requirements)
                    .IsRequired()
                    .HasColumnName("requirements")
                    .HasMaxLength(255);

                entity.HasOne(d => d.FkIdCategoryNavigation)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.FkIdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Category_FK");

                entity.HasOne(d => d.FkUsernameNavigation)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.FkUsername)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Users_FK");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(25);

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(45);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(25);

                entity.Property(e => e.Passwd)
                    .IsRequired()
                    .HasColumnName("passwd")
                    .HasMaxLength(25);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("int(9)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(25);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
