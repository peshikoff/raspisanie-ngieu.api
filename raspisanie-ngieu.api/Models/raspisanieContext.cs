using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace raspisanie_ngieu.api.Models
{
    public partial class raspisanieContext : DbContext
    {
        public raspisanieContext()
        {

        }

        public raspisanieContext(DbContextOptions<raspisanieContext> options)
            : base(options)
        {
        }
        public virtual DbSet<StoredProcedureModel> StoredProcedureModels { get; set; } = null!;
        public virtual DbSet<Groups> Groups { get; set; } = null!;
        public virtual DbSet<Weeks> Weeks { get; set; } = null!;
        public virtual DbSet<Teachers> Teachers { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=raspisanie-ngieuDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<StoredProcedureModel>(entity =>
            {
                entity.HasNoKey();

            });
            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasNoKey();

            });
            modelBuilder.Entity<Weeks>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasNoKey();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
