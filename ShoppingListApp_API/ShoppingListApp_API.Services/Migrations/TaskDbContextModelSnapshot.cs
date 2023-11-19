﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingListApp_API.Services.Database;

#nullable disable

namespace ShoppingListApp_API.Services.Migrations
{
    [DbContext(typeof(TaskDbContext))]
    partial class TaskDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShoppingListApp_API.Services.Database.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ItemID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("ItemName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ItemId")
                        .HasName("PK__Item__727E83EBC59DB928");

                    b.ToTable("Item", (string)null);
                });

            modelBuilder.Entity("ShoppingListApp_API.Services.Database.Shopper", b =>
                {
                    b.Property<int>("ShopperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ShopperID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShopperId"));

                    b.Property<string>("ShopperName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ShopperId")
                        .HasName("PK__Shopper__1291733F18E77DB8");

                    b.ToTable("Shopper", (string)null);
                });

            modelBuilder.Entity("ShoppingListApp_API.Services.Database.ShoppingList", b =>
                {
                    b.Property<int>("ShoppingListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ShoppingListID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoppingListId"));

                    b.Property<int?>("ItemId")
                        .HasColumnType("int")
                        .HasColumnName("ItemID");

                    b.Property<int?>("ShopperId")
                        .HasColumnType("int")
                        .HasColumnName("ShopperID");

                    b.HasKey("ShoppingListId")
                        .HasName("PK__Shopping__6CBBDD7456453DC5");

                    b.HasIndex("ItemId");

                    b.HasIndex("ShopperId");

                    b.ToTable("ShoppingList", (string)null);
                });

            modelBuilder.Entity("ShoppingListApp_API.Services.Database.ShoppingList", b =>
                {
                    b.HasOne("ShoppingListApp_API.Services.Database.Item", "Item")
                        .WithMany("ShoppingLists")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK__ShoppingL__ItemI__3C69FB99");

                    b.HasOne("ShoppingListApp_API.Services.Database.Shopper", "Shopper")
                        .WithMany("ShoppingLists")
                        .HasForeignKey("ShopperId")
                        .HasConstraintName("FK__ShoppingL__Shopp__3B75D760");

                    b.Navigation("Item");

                    b.Navigation("Shopper");
                });

            modelBuilder.Entity("ShoppingListApp_API.Services.Database.Item", b =>
                {
                    b.Navigation("ShoppingLists");
                });

            modelBuilder.Entity("ShoppingListApp_API.Services.Database.Shopper", b =>
                {
                    b.Navigation("ShoppingLists");
                });
#pragma warning restore 612, 618
        }
    }
}