using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ООО_Посуда.Models
{
    public partial class tradeContext : DbContext
    {
        public static tradeContext DbContext { get; private set; } = new tradeContext();

        public tradeContext()
        {
        }

        public tradeContext(DbContextOptions<tradeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Manufacture> Manufactures { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Orderproduct> Orderproducts { get; set; } = null!;
        public virtual DbSet<Pickuppoint> Pickuppoints { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Street> Streets { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<Unit> Units { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("user=root;server=localhost;database=trade;password=a678e321r", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")).UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PRIMARY");

                entity.ToTable("category");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.CategoryName).HasMaxLength(45);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IdCity)
                    .HasName("PRIMARY");

                entity.ToTable("city");

                entity.Property(e => e.IdCity).HasColumnName("idCity");

                entity.Property(e => e.CityName).HasMaxLength(50);
            });

            modelBuilder.Entity<Manufacture>(entity =>
            {
                entity.HasKey(e => e.IdManufactures)
                    .HasName("PRIMARY");

                entity.ToTable("manufactures");

                entity.Property(e => e.IdManufactures).HasColumnName("idManufactures");

                entity.Property(e => e.ManufacturerName).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.HasIndex(e => e.OrderStatusId, "FK_Order_Status_idx");

                entity.HasIndex(e => e.UserId, "FK_Order_User_idx");

                entity.HasIndex(e => e.OrderPickupPointId, "FK_Order_picp_idx");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderCode).HasMaxLength(45);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.OrderPickupPointId).HasColumnName("OrderPickupPointID");

                entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.OrderPickupPoint)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderPickupPointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_picp");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<Orderproduct>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductArticleNumber })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("orderproduct");

                entity.HasIndex(e => e.ProductArticleNumber, "fk_order");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OrderID");

                entity.Property(e => e.ProductArticleNumber)
                    .HasMaxLength(100)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Count).HasMaxLength(45);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderproducts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderproduct_ibfk_1");

                entity.HasOne(d => d.ProductArticleNumberNavigation)
                    .WithMany(p => p.Orderproducts)
                    .HasForeignKey(d => d.ProductArticleNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order");
            });

            modelBuilder.Entity<Pickuppoint>(entity =>
            {
                entity.HasKey(e => e.IdPickupPoint)
                    .HasName("PRIMARY");

                entity.ToTable("pickuppoint");

                entity.HasIndex(e => e.CityId, "FK_PickupPoint_City_idx");

                entity.HasIndex(e => e.StreetId, "FK_PickupPoint_Street_idx");

                entity.Property(e => e.IdPickupPoint).HasColumnName("idPickupPoint");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Home).HasMaxLength(45);

                entity.Property(e => e.Index).HasMaxLength(45);

                entity.Property(e => e.StreetId).HasColumnName("StreetID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Pickuppoints)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PickupPoint_City");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.Pickuppoints)
                    .HasForeignKey(d => d.StreetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PickupPoint_Street");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductArticleNumber)
                    .HasName("PRIMARY");

                entity.ToTable("product");

                entity.HasIndex(e => e.ProductCategoryId, "FK_Product_Category_idx");

                entity.HasIndex(e => e.ProductManufacturerId, "FK_Product_Manufacturer_idx");

                entity.HasIndex(e => e.ProductSupplierId, "FK_Product_Supplier_idx");

                entity.HasIndex(e => e.ProductUnitId, "FK_Product_Unit_idx");

                entity.Property(e => e.ProductArticleNumber)
                    .HasMaxLength(100)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.ProductCost).HasPrecision(19, 4);

                entity.Property(e => e.ProductDescription).HasColumnType("text");

                entity.Property(e => e.ProductManufacturerId).HasColumnName("ProductManufacturerID");

                entity.Property(e => e.ProductName).HasColumnType("text");

                entity.Property(e => e.ProductPhoto).HasMaxLength(250);

                entity.Property(e => e.ProductSupplierId).HasColumnName("ProductSupplierID");

                entity.Property(e => e.ProductUnitId).HasColumnName("ProductUnitID");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.ProductManufacturer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Manufacturer");

                entity.HasOne(d => d.ProductSupplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductSupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Supplier");

                entity.HasOne(d => d.ProductUnit)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Unit");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(100);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PRIMARY");

                entity.ToTable("status");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.Property(e => e.StatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.HasKey(e => e.IdStreet)
                    .HasName("PRIMARY");

                entity.ToTable("street");

                entity.Property(e => e.IdStreet).HasColumnName("idStreet");

                entity.Property(e => e.StreetName).HasMaxLength(50);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.IdSupplier)
                    .HasName("PRIMARY");

                entity.ToTable("supplier");

                entity.Property(e => e.IdSupplier).HasColumnName("idSupplier");

                entity.Property(e => e.SupplierName).HasMaxLength(50);
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasKey(e => e.Idunit)
                    .HasName("PRIMARY");

                entity.ToTable("unit");

                entity.Property(e => e.Idunit).HasColumnName("idunit");

                entity.Property(e => e.UnitName).HasMaxLength(45);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.UserRole, "UserRole");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserLogin).HasColumnType("text");

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.Property(e => e.UserPassword).HasColumnType("text");

                entity.Property(e => e.UserPatronymic).HasMaxLength(100);

                entity.Property(e => e.UserSurname).HasMaxLength(100);

                entity.HasOne(d => d.UserRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
