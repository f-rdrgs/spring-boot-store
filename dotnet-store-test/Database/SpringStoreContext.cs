using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store_test.Database.Models;

public partial class SpringStoreContext : DbContext
{
    public SpringStoreContext()
    {
    }

    public SpringStoreContext(DbContextOptions<SpringStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<OrderList> OrderLists { get; set; }

    public virtual DbSet<OrdersClient> OrdersClients { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=127.0.0.1:8081;Database=spring-store;Username=admin;Password=testest");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("current_status", new[] { "in_stock", "out_of_stock", "low" })
            .HasPostgresEnum("order_status", new[] { "delivered", "order_placed", "en_route", "cancelled" });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("address_pkey");

            entity.ToTable("address");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Country)
                .HasColumnType("character varying")
                .HasColumnName("country");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.IsDefault)
                .HasDefaultValue(true)
                .HasColumnName("is_default");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("character varying")
                .HasColumnName("phone_number");
            entity.Property(e => e.Street)
                .HasColumnType("character varying")
                .HasColumnName("street");
            entity.Property(e => e.StreetNumber).HasColumnName("street_number");
            entity.Property(e => e.Surname)
                .HasColumnType("character varying")
                .HasColumnName("surname");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("address_user_id_fkey");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName)
                .HasColumnType("character varying")
                .HasColumnName("category_name");
            entity.Property(e => e.SubcategoryId).HasColumnName("subcategory_id");

            entity.HasOne(d => d.Subcategory).WithMany(p => p.InverseSubcategory)
                .HasForeignKey(d => d.SubcategoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("category_subcategory_id_fkey");
        });

        modelBuilder.Entity<OrderList>(entity =>
        {
            entity.HasKey(e => new { e.IdOrder, e.IdProduct }).HasName("order_list_pkey");

            entity.ToTable("order_list");

            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.PriceAtOrder)
                .HasDefaultValueSql("0")
                .HasColumnName("price_at_order");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1)
                .HasColumnName("quantity");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderLists)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("order_list_id_order_fkey");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.OrderLists)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("order_list_id_product_fkey");
        });

        modelBuilder.Entity<OrdersClient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_client_pkey");

            entity.ToTable("orders_client");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.OrdersClients)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("orders_client_id_user_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pkey");

            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.Price)
                .HasDefaultValueSql("0")
                .HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasColumnType("character varying")
                .HasColumnName("product_name");
            entity.Property(e => e.QuantityInStock)
                .HasDefaultValue(0)
                .HasColumnName("quantity_in_stock");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("products_id_category_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
