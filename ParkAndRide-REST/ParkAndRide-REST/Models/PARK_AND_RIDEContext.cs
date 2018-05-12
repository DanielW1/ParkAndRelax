using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ParkAndRide_REST.Models
{
    public partial class PARK_AND_RIDEContext : DbContext
    {
        public virtual DbSet<Wydarzenie> Wydarzenie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=LENOVO-PC\SQLEXPRESS;Database=PARK_AND_RIDE;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wydarzenie>(entity =>
            {
                entity.ToTable("WYDARZENIE");

                entity.HasIndex(e => e.Id)
                    .HasName("IX_WYDARZENIE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cena).HasColumnName("CENA");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("DATA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Informacje)
                    .IsRequired()
                    .HasColumnName("INFORMACJE")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Kategoria)
                    .HasColumnName("KATEGORIA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Miejscowosc)
                    .IsRequired()
                    .HasColumnName("MIEJSCOWOSC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("NAZWA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NrBudynku)
                    .HasColumnName("NR_BUDYNKU")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NrMieszkania)
                    .HasColumnName("NR_MIESZKANIA")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Ulica)
                    .HasColumnName("ULICA")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
