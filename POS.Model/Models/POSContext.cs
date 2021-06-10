using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace POS.Model.Models
{
    public partial class POSContext : DbContext
    {
        public POSContext()
        {
        }

        public POSContext(DbContextOptions<POSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buy> Buys { get; set; }
        public virtual DbSet<BuyDetail> BuyDetails { get; set; }
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<Cut> Cuts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Sell> Sells { get; set; }
        public virtual DbSet<SellDetail> SellDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localDB)\\AntaresInstance;Database=POS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Buy>(entity =>
            {
                entity.ToTable("Buy");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.ProviderId).HasColumnName("provider_id");

                entity.Property(e => e.ProviderName)
                    .HasMaxLength(100)
                    .HasColumnName("provider_name");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Buys)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK_Buy_ToProvider");
            });

            modelBuilder.Entity<BuyDetail>(entity =>
            {
                entity.ToTable("BuyDetail");

                entity.Property(e => e.BuyId).HasColumnName("buy_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("product_price");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("quantity");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.Buy)
                    .WithMany(p => p.BuyDetails)
                    .HasForeignKey(d => d.BuyId)
                    .HasConstraintName("FK_BuyDetail_ToBuy");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BuyDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_BuyDetail_ToProduct");
            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.ToTable("Configuration");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(200)
                    .HasColumnName("company_name");

                entity.Property(e => e.InputMode).HasColumnName("input_mode");

                entity.Property(e => e.PrintOnSale).HasColumnName("print_on_sale");

                entity.Property(e => e.Printer)
                    .HasMaxLength(100)
                    .HasColumnName("printer");
            });

            modelBuilder.Entity<Cut>(entity =>
            {
                entity.ToTable("Cut");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Total).HasColumnName("total");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Categoria).HasMaxLength(100);

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CodigoBarras).HasMaxLength(100);

                entity.Property(e => e.Ieps)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("IEPS");

                entity.Property(e => e.Iva)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("IVA");

                entity.Property(e => e.Marca)
                    .HasMaxLength(200)
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Precio).HasColumnType("money");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("Provider");

                entity.Property(e => e.BusinessName)
                    .HasMaxLength(100)
                    .HasColumnName("business_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Rfc)
                    .HasMaxLength(25)
                    .HasColumnName("rfc");
            });

            modelBuilder.Entity<Sell>(entity =>
            {
                entity.ToTable("Sell");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Canceled).HasColumnName("canceled");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Folio)
                    .HasMaxLength(20)
                    .HasColumnName("folio");

                entity.Property(e => e.Serie)
                    .HasMaxLength(20)
                    .HasColumnName("serie");

                entity.Property(e => e.Subtotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("subtotal");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total");
            });

            modelBuilder.Entity<SellDetail>(entity =>
            {
                entity.ToTable("SellDetail");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .HasColumnName("productName");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("quantity");

                entity.Property(e => e.SellId).HasColumnName("sell_id");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SellDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_SellDetail_Product");

                entity.HasOne(d => d.Sell)
                    .WithMany(p => p.SellDetails)
                    .HasForeignKey(d => d.SellId)
                    .HasConstraintName("FK_SellDetail_Sell");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
