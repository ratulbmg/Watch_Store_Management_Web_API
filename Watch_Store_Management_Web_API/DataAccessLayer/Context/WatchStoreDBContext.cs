using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities;

namespace Watch_Store_Management_Web_API.DataAccessLayer.Context
{
    public partial class WatchStoreDBContext : DbContext
    {
        public WatchStoreDBContext()
        {
        }

        public WatchStoreDBContext(DbContextOptions<WatchStoreDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<CartDetail> CartDetails { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConStr");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Landmark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Addresses__UserI__14270015");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Carts__UserId__2B0A656D");
            });

            modelBuilder.Entity<CartDetail>(entity =>
            {
                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartDetai__CartI__2DE6D218");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartDetai__Produ__2EDAF651");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

        

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__AddressI__1F98B2C1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__UserId__1EA48E88");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__Order__22751F6C");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__Produ__236943A5");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__BrandI__1BC821DD");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__Catego__1AD3FDA4");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName, "UQ__Users__C9F284569B0D5FD3")
                    .IsUnique();

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__RoleId__114A936A");
            });

            SeedTheData(modelBuilder);  // Call SeedTheData from bellow
            OnModelCreatingPartial(modelBuilder);
        }

        #region SEED THE INITIAL DATA
        private void SeedTheData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(SeedingInitialData.GetRoles());
            modelBuilder.Entity<Category>()
                .HasData(SeedingInitialData.GetCategories());
            modelBuilder.Entity<Brand>()
                .HasData(SeedingInitialData.GetBrand());
        }
        #endregion

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        internal Task<int> FindAsync(int v)
        {
            throw new NotImplementedException();
        }
    }
}
