using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MogobariWebAPI.Models
{
    public partial class Mogobari_dbContext : DbContext
    {
        public Mogobari_dbContext()
        {
        }

        public Mogobari_dbContext(DbContextOptions<Mogobari_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerPassword> CustomerPassword { get; set; }
        public virtual DbSet<CustomerRole> CustomerRole { get; set; }
        public virtual DbSet<DeliveryDate> DeliveryDate { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=windows-7de51d1\\sqlexpress;Initial Catalog=Mogobari_db;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("IX_AddressF")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber)
                    .HasName("IX_AddressF_1")
                    .IsUnique();

                entity.Property(e => e.Address1)
                    .HasColumnName("Address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.ParentCategoryId)
                    .HasName("IX_Category");

                entity.Property(e => e.MetaKeywords).HasMaxLength(400);

                entity.Property(e => e.MetaTitle).HasMaxLength(400);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.PriceRanges).HasMaxLength(400);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.Property(e => e.BillingAddressId).HasColumnName("BillingAddress_Id");

                entity.Property(e => e.Email).HasMaxLength(1000);

                entity.Property(e => e.EmailToRevalidate).HasMaxLength(1000);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhotoPath)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingAddressId).HasColumnName("ShippingAddress_Id");

                entity.Property(e => e.SystemName).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Customer_Address");
            });

            modelBuilder.Entity<CustomerPassword>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerPassword)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerPassword_Customer");
            });

            modelBuilder.Entity<CustomerRole>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SystemName).HasMaxLength(255);
            });

            modelBuilder.Entity<DeliveryDate>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.AdditionalShippingCharge).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.AllowedQuantities).HasMaxLength(1000);

                entity.Property(e => e.BasepriceAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.BasepriceBaseAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Height).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Length).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ManufacturerPartNumber).HasMaxLength(400);

                entity.Property(e => e.MaximumCustomerEnteredPrice).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MinimumCustomerEnteredPrice).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.OldPrice).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Width).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("IX_Vendor")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.MetaKeywords).HasMaxLength(400);

                entity.Property(e => e.MetaTitle).HasMaxLength(400);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Vendor)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Vendor_Address");
            });
        }
    }
}
