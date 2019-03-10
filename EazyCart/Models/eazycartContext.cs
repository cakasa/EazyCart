using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EazyCart.Models
{
    public partial class eazycartContext : DbContext
    {
        public eazycartContext()
        {
        }

        public eazycartContext(DbContextOptions<eazycartContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Productsreceipts> Productsreceipts { get; set; }
        public virtual DbSet<Providers> Providers { get; set; }
        public virtual DbSet<Receipts> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=eazycart");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("categories", "eazycart");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(6)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.ToTable("cities", "eazycart");

                entity.HasIndex(e => e.CountryId)
                    .HasName("countryId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(6)");

                entity.Property(e => e.CountryId)
                    .HasColumnName("countryId")
                    .HasColumnType("int(6)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cities_ibfk_1");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.ToTable("countries", "eazycart");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(6)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("products", "eazycart");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("categoryId");

                entity.HasIndex(e => e.Code)
                    .HasName("code")
                    .IsUnique();

                entity.HasIndex(e => e.ProviderId)
                    .HasName("providerId");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("char(6)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryId")
                    .HasColumnType("int(6)");

                entity.Property(e => e.DeliveryPrice)
                    .HasColumnName("deliveryPrice")
                    .HasColumnType("decimal(12,3)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderId)
                    .HasColumnName("providerId")
                    .HasColumnType("int(6)");

                entity.Property(e => e.SellingPrice)
                    .HasColumnName("sellingPrice")
                    .HasColumnType("decimal(12,3)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("products_ibfk_2");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("products_ibfk_1");
            });

            modelBuilder.Entity<Productsreceipts>(entity =>
            {
                entity.ToTable("productsreceipts", "eazycart");

                entity.HasIndex(e => e.ProductCode)
                    .HasName("productCode");

                entity.HasIndex(e => e.ReceiptId)
                    .HasName("receiptId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(12)");

                entity.Property(e => e.DiscountPercentage)
                    .HasColumnName("discountPercentage")
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasColumnName("productCode")
                    .HasColumnType("char(6)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal(6,3)");

                entity.Property(e => e.ReceiptId)
                    .HasColumnName("receiptId")
                    .HasColumnType("int(6)");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.Productsreceipts)
                    .HasForeignKey(d => d.ProductCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productsreceipts_ibfk_1");

                entity.HasOne(d => d.Receipt)
                    .WithMany(p => p.Productsreceipts)
                    .HasForeignKey(d => d.ReceiptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productsreceipts_ibfk_2");
            });

            modelBuilder.Entity<Providers>(entity =>
            {
                entity.ToTable("providers", "eazycart");

                entity.HasIndex(e => e.CityId)
                    .HasName("cityId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(6)");

                entity.Property(e => e.CityId)
                    .HasColumnName("cityId")
                    .HasColumnType("int(6)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Providers)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("providers_ibfk_1");
            });

            modelBuilder.Entity<Receipts>(entity =>
            {
                entity.ToTable("receipts", "eazycart");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(6)");

                entity.Property(e => e.GrandTotal)
                    .HasColumnName("grandTotal")
                    .HasColumnType("decimal(12,3)");

                entity.Property(e => e.TimeOfPurchase).HasColumnName("timeOfPurchase");
            });
        }
    }
}
