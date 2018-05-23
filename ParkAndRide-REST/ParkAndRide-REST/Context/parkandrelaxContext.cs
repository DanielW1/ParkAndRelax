using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ParkAndRide_REST.Models
{
    public partial class parkandrelaxContext : DbContext
    {
        public virtual DbSet<Event> Event { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=tcp:parkandrelax.database.windows.net,1433;Initial Catalog=parkandrelax;Persist Security Info=False;User ID=daniel@parkandrelax;Password=parkandrelax1_;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("EVENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Category)
                    .HasColumnName("CATEGORY")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnName("DATE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Information)
                    .IsRequired()
                    .HasColumnName("INFORMATION")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasColumnName("PLACE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("PRICE")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
