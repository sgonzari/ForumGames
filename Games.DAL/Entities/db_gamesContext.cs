using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Games.DAL.Entities
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
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<GamesCategory> GamesCategory { get; set; }
        public virtual DbSet<GamesPlatforms> GamesPlatforms { get; set; }
        public virtual DbSet<Platforms> Platforms { get; set; }
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

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.IdComment)
                    .HasName("PRIMARY");

                entity.ToTable("comments");

                entity.HasIndex(e => e.FkIdGame)
                    .HasName("FK_Game");

                entity.HasIndex(e => e.FkUsername)
                    .HasName("FK_User");

                entity.Property(e => e.IdComment)
                    .HasColumnName("id_comment")
                    .HasColumnType("int(4)");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment")
                    .HasMaxLength(255);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkIdGame)
                    .HasColumnName("fk_id_game")
                    .HasColumnType("int(4)");

                entity.Property(e => e.FkUsername)
                    .IsRequired()
                    .HasColumnName("fk_username")
                    .HasMaxLength(25);

                entity.HasOne(d => d.FkIdGameNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.FkIdGame)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Game");

                entity.HasOne(d => d.FkUsernameNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.FkUsername)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User");
            });

            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasKey(e => e.IdGame)
                    .HasName("PRIMARY");

                entity.ToTable("games");

                entity.HasIndex(e => e.FkUsername)
                    .HasName("Users_FK");

                entity.Property(e => e.IdGame)
                    .HasColumnName("id_game")
                    .HasColumnType("int(4)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.FkUsername)
                    .IsRequired()
                    .HasColumnName("fk_username")
                    .HasMaxLength(25);

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasColumnType("decimal(4,0)");

                entity.Property(e => e.LaunchDate)
                    .HasColumnName("launch_date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Multiplayer).HasColumnName("multiplayer");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.HasOne(d => d.FkUsernameNavigation)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.FkUsername)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Users_FK");
            });

            modelBuilder.Entity<GamesCategory>(entity =>
            {
                entity.HasKey(e => new { e.FkIdGame, e.FkIdCategory })
                    .HasName("PRIMARY");

                entity.ToTable("games_category");

                entity.HasIndex(e => e.FkIdCategory)
                    .HasName("Category_Game_FK");

                entity.Property(e => e.FkIdGame)
                    .HasColumnName("fk_id_game")
                    .HasColumnType("int(4)");

                entity.Property(e => e.FkIdCategory)
                    .HasColumnName("fk_id_category")
                    .HasColumnType("int(4)");

                entity.HasOne(d => d.FkIdCategoryNavigation)
                    .WithMany(p => p.GamesCategory)
                    .HasForeignKey(d => d.FkIdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Category_Game_FK");

                entity.HasOne(d => d.FkIdGameNavigation)
                    .WithMany(p => p.GamesCategory)
                    .HasForeignKey(d => d.FkIdGame)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Game_Category_FK");
            });

            modelBuilder.Entity<GamesPlatforms>(entity =>
            {
                entity.HasKey(e => new { e.FkIdGame, e.FkIdPlatform })
                    .HasName("PRIMARY");

                entity.ToTable("games_platforms");

                entity.HasIndex(e => e.FkIdPlatform)
                    .HasName("Platform_Game_FK");

                entity.Property(e => e.FkIdGame)
                    .HasColumnName("fk_id_game")
                    .HasColumnType("int(4)");

                entity.Property(e => e.FkIdPlatform)
                    .HasColumnName("fk_id_platform")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.FkIdGameNavigation)
                    .WithMany(p => p.GamesPlatforms)
                    .HasForeignKey(d => d.FkIdGame)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Game_Platform_FK");

                entity.HasOne(d => d.FkIdPlatformNavigation)
                    .WithMany(p => p.GamesPlatforms)
                    .HasForeignKey(d => d.FkIdPlatform)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Platform_Game_FK");
            });

            modelBuilder.Entity<Platforms>(entity =>
            {
                entity.HasKey(e => e.IdPlatform)
                    .HasName("PRIMARY");

                entity.ToTable("platforms");

                entity.Property(e => e.IdPlatform)
                    .HasColumnName("id_platform")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Platform)
                    .IsRequired()
                    .HasColumnName("platform")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(25);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(25);

                entity.Property(e => e.Group)
                    .IsRequired()
                    .HasColumnName("group")
                    .HasMaxLength(25)
                    .HasDefaultValueSql("'''user'''");

                entity.Property(e => e.Passwd)
                    .IsRequired()
                    .HasColumnName("passwd")
                    .HasMaxLength(25);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("int(10)")
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
