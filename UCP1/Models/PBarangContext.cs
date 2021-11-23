using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1.Models
{
    public partial class PBarangContext : DbContext
    {
        public PBarangContext()
        {
        }

        public PBarangContext(DbContextOptions<PBarangContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Barang> Barangs { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<Kurir> Kurirs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.IdAdministrator);

                entity.ToTable("Administrator");

                entity.Property(e => e.IdAdministrator)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Administrator");

                entity.Property(e => e.IdPerusahaan).HasColumnName("ID_Perusahaan");

                entity.Property(e => e.NamaAdministrator)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Administrator");

                entity.Property(e => e.NomorTelepon)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nomor_Telepon");
            });

            modelBuilder.Entity<Barang>(entity =>
            {
                entity.HasKey(e => e.IdDetailBarang);

                entity.ToTable("Barang");

                entity.Property(e => e.IdDetailBarang)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Detail_Barang");

                entity.Property(e => e.AlamatPengirim)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Alamat_Pengirim");

                entity.Property(e => e.AlamatTujuan)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Alamat_Tujuan");

                entity.Property(e => e.BeratBarang).HasColumnName("Berat_Barang");

                entity.Property(e => e.NamaPenerima)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Penerima");

                entity.Property(e => e.NamaPengirim)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Pengirim");

                entity.Property(e => e.NomorResiPengiriman)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nomor_Resi_Pengiriman");

                entity.Property(e => e.StatusBarang)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Status_Barang");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.ToTable("Customer");

                entity.Property(e => e.IdCustomer)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Customer");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaCustomer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Customer");

                entity.Property(e => e.NomorTelepon)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nomor_Telepon");
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.HasKey(e => e.IdDetailBarang);

                entity.ToTable("Detail");

                entity.Property(e => e.IdDetailBarang)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Detail_Barang");

                entity.Property(e => e.IdAdministrator).HasColumnName("ID_Administrator");

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.IdKurir).HasColumnName("ID_Kurir");

                entity.Property(e => e.NomorResiPengiriman)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nomor_Resi_Pengiriman");

                entity.HasOne(d => d.IdAdministratorNavigation)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.IdAdministrator)
                    .HasConstraintName("FK_Detail_Administrator");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_Detail_Customer");

                entity.HasOne(d => d.IdDetailBarangNavigation)
                    .WithOne(p => p.Detail)
                    .HasForeignKey<Detail>(d => d.IdDetailBarang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detail_Barang");

                entity.HasOne(d => d.IdKurirNavigation)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.IdKurir)
                    .HasConstraintName("FK_Detail_Kurir");
            });

            modelBuilder.Entity<Kurir>(entity =>
            {
                entity.HasKey(e => e.IdKurir);

                entity.ToTable("Kurir");

                entity.Property(e => e.IdKurir)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Kurir");

                entity.Property(e => e.IdPerusahaan).HasColumnName("ID_Perusahaan");

                entity.Property(e => e.NamaKurir)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Kurir");

                entity.Property(e => e.NomorTelepon)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nomor_Telepon");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
