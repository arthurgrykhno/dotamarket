﻿// <auto-generated />
using System;
using DotaMarket.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotaMarket.DataLayer.Migrations
{
    [DbContext(typeof(DotaMarketContext))]
    [Migration("20230412233323_Initial2")]
    partial class Initial2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DotaMarket.DataLayer.Entities.Inventory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ItemsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ItemsId");

                    b.HasIndex("UserId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("DotaMarket.DataLayer.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Hero")
                        .HasColumnType("int");

                    b.Property<Guid>("InventoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ItemHistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("ItemPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ItemSlot")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rare")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemHistoryId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("DotaMarket.DataLayer.Entities.ItemHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ItemAction")
                        .HasColumnType("int");

                    b.Property<Guid?>("SellerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ItemHistories");
                });

            modelBuilder.Entity("DotaMarket.DataLayer.Entities.Market", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Market");
                });

            modelBuilder.Entity("DotaMarket.DataLayer.Entities.MarketHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("MarketHistories");
                });

            modelBuilder.Entity("DotaMarket.DataLayer.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("InventoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DotaMarket.DataLayer.Entities.Inventory", b =>
                {
                    b.HasOne("DotaMarket.DataLayer.Entities.Item", "Items")
                        .WithMany()
                        .HasForeignKey("ItemsId");

                    b.HasOne("DotaMarket.DataLayer.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Items");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DotaMarket.DataLayer.Entities.Item", b =>
                {
                    b.HasOne("DotaMarket.DataLayer.Entities.ItemHistory", "ItemHistory")
                        .WithMany()
                        .HasForeignKey("ItemHistoryId");

                    b.Navigation("ItemHistory");
                });

            modelBuilder.Entity("DotaMarket.DataLayer.Entities.Market", b =>
                {
                    b.HasOne("DotaMarket.DataLayer.Entities.Item", "Items")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("DotaMarket.DataLayer.Entities.MarketHistory", b =>
                {
                    b.HasOne("DotaMarket.DataLayer.Entities.User", null)
                        .WithOne("ActionHistory")
                        .HasForeignKey("DotaMarket.DataLayer.Entities.MarketHistory", "UserId");
                });

            modelBuilder.Entity("DotaMarket.DataLayer.Entities.User", b =>
                {
                    b.HasOne("DotaMarket.DataLayer.Entities.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("DotaMarket.DataLayer.Entities.User", b =>
                {
                    b.Navigation("ActionHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
