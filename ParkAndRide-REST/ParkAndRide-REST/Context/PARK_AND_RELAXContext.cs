using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ParkAndRide_REST.Models;

namespace ParkAndRide_REST.Context
{
    public partial class PARK_AND_RELAXContext : DbContext
    {
      /*  public virtual DbSet<string> Event { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=LENOVO-PC\SQLEXPRESS;Database=PARK_AND_RELAX;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<string>(entity =>
            {
                entity.ToTable("EVENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Category)
                    .HasColumnName("CATEGORY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnName("DATE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Information)
                    .IsRequired()
                    .HasColumnName("INFORMATION")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasColumnName("PLACE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("PRICE")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }*/
    }
}
