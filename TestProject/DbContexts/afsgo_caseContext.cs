using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestProject.Entities;

namespace TestProject.DbContexts
{
    public partial class afsgo_caseContext : DbContext
    {
        public afsgo_caseContext()
        {
        }

        public afsgo_caseContext(DbContextOptions<afsgo_caseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserToken> UserTokens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=afsgo_case;uid=root;password=gd9mqUG7JrH9cHP", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transactions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Input)
                    .HasMaxLength(100)
                    .HasColumnName("input");

                entity.Property(e => e.Output)
                    .HasMaxLength(100)
                    .HasColumnName("output");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UserMail)
                    .HasMaxLength(100)
                    .HasColumnName("user_mail");
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.ToTable("user_tokens");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Secret)
                    .HasMaxLength(100)
                    .HasColumnName("secret");

                entity.Property(e => e.Token)
                    .HasMaxLength(100)
                    .HasColumnName("token");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
