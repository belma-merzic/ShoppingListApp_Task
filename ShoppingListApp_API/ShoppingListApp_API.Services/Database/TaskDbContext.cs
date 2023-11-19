using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShoppingListApp_API.Services.Database;

public partial class TaskDbContext : DbContext
{
    public TaskDbContext()
    {
    }

    public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Shopper> Shoppers { get; set; }

    public virtual DbSet<ShoppingList> ShoppingLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Task_DB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Item__727E83EBC59DB928");

            entity.ToTable("Item");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ItemName).HasMaxLength(50);
        });

        modelBuilder.Entity<Shopper>(entity =>
        {
            entity.HasKey(e => e.ShopperId).HasName("PK__Shopper__1291733F18E77DB8");

            entity.ToTable("Shopper");

            entity.Property(e => e.ShopperId).HasColumnName("ShopperID");
            entity.Property(e => e.ShopperName).HasMaxLength(50);
        });

        modelBuilder.Entity<ShoppingList>(entity =>
        {
            entity.HasKey(e => e.ShoppingListId).HasName("PK__Shopping__6CBBDD7456453DC5");

            entity.ToTable("ShoppingList");

            entity.Property(e => e.ShoppingListId).HasColumnName("ShoppingListID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ShopperId).HasColumnName("ShopperID");

            entity.HasOne(d => d.Item).WithMany(p => p.ShoppingLists)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__ShoppingL__ItemI__3C69FB99");

            entity.HasOne(d => d.Shopper).WithMany(p => p.ShoppingLists)
                .HasForeignKey(d => d.ShopperId)
                .HasConstraintName("FK__ShoppingL__Shopp__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
