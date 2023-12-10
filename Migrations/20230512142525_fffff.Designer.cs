﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoqaydaGP.Data;

namespace MoqaydaGP.Migrations
{
    [DbContext(typeof(MoqaydaDbContext))]
    [Migration("20230512142525_fffff")]
    partial class fffff
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoqaydaGP.Entities.BarteredPrivateItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PrivateItemId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductOwnerId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PrivateItemId");

                    b.HasIndex("ProductOwnerId");

                    b.HasIndex("UserId");

                    b.ToTable("BarteredPrivateItem");
                });

            modelBuilder.Entity("MoqaydaGP.Entities.BarteredProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductOwnerId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductOwnerId");

                    b.HasIndex("UserId");

                    b.ToTable("BarteredProduct");
                });

            modelBuilder.Entity("MoqaydaGP.Entities.Category", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryBgColor")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(100);

                    b.Property<bool?>("IsAcTive")
                        .HasColumnType("bit");

                    b.Property<string>("PathImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("MoqaydaGP.Entities.PrivateItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PathImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrivateItemDescription")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(8000);

                    b.Property<string>("PrivateItemeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PrivateItem");
                });

            modelBuilder.Entity("MoqaydaGP.Entities.PrivateSwap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PrivateItemId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductOwnerId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PrivateItemId");

                    b.HasIndex("ProductOwnerId");

                    b.HasIndex("UserId");

                    b.ToTable("PrivateSwap");
                });

            modelBuilder.Entity("MoqaydaGP.Entities.ProdToSwap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductOwnerId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductOwnerId");

                    b.HasIndex("UserId");

                    b.ToTable("ProdToSwap");
                });

            modelBuilder.Entity("MoqaydaGP.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AvailableSince")
                        .HasColumnType("datetime2");

                    b.Property<short?>("CategoryId")
                        .HasColumnType("smallint");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWishlistItem")
                        .HasColumnType("bit");

                    b.Property<bool?>("Isfavourite")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modifiedby")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("NumberOfQuantity")
                        .HasColumnType("int");

                    b.Property<string>("PathImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductBgColor")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(8000);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("ProductToSwap")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("MoqaydaGP.Entities.ProductOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("ProductOwner");
                });

            modelBuilder.Entity("MoqaydaGP.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PathImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MoqaydaGP.Entities.WishlistItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("WishlistItem");
                });

            modelBuilder.Entity("MoqaydaGP.Entities.BarteredPrivateItem", b =>
                {
                    b.HasOne("MoqaydaGP.Entities.PrivateItem", "PrivateItem")
                        .WithMany("BarteredPrivateItem")
                        .HasForeignKey("PrivateItemId");

                    b.HasOne("MoqaydaGP.Entities.ProductOwner", "ProductOwner")
                        .WithMany("BarteredPrivateItem")
                        .HasForeignKey("ProductOwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MoqaydaGP.Entities.User", "User")
                        .WithMany("BarteredPrivateItem")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MoqaydaGP.Entities.BarteredProduct", b =>
                {
                    b.HasOne("MoqaydaGP.Entities.Product", "Product")
                        .WithMany("BarteredProduct")
                        .HasForeignKey("ProductId");

                    b.HasOne("MoqaydaGP.Entities.ProductOwner", "ProductOwner")
                        .WithMany("BarteredProduct")
                        .HasForeignKey("ProductOwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MoqaydaGP.Entities.User", "User")
                        .WithMany("BarteredProduct")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MoqaydaGP.Entities.PrivateItem", b =>
                {
                    b.HasOne("MoqaydaGP.Entities.User", "User")
                        .WithMany("PrivateItem")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MoqaydaGP.Entities.PrivateSwap", b =>
                {
                    b.HasOne("MoqaydaGP.Entities.PrivateItem", "PrivateItem")
                        .WithMany("PrivateSwap")
                        .HasForeignKey("PrivateItemId");

                    b.HasOne("MoqaydaGP.Entities.ProductOwner", "ProductOwner")
                        .WithMany("PrivateSwap")
                        .HasForeignKey("ProductOwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MoqaydaGP.Entities.User", "User")
                        .WithMany("PrivateSwap")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MoqaydaGP.Entities.ProdToSwap", b =>
                {
                    b.HasOne("MoqaydaGP.Entities.Product", "Product")
                        .WithMany("ProdToSwap")
                        .HasForeignKey("ProductId");

                    b.HasOne("MoqaydaGP.Entities.ProductOwner", "ProductOwner")
                        .WithMany("ProdToSwap")
                        .HasForeignKey("ProductOwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MoqaydaGP.Entities.User", "User")
                        .WithMany("ProdToSwap")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MoqaydaGP.Entities.Product", b =>
                {
                    b.HasOne("MoqaydaGP.Entities.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MoqaydaGP.Entities.User", "User")
                        .WithMany("Product")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MoqaydaGP.Entities.ProductOwner", b =>
                {
                    b.HasOne("MoqaydaGP.Entities.Product", "Product")
                        .WithMany("ProductOwner")
                        .HasForeignKey("ProductId");

                    b.HasOne("MoqaydaGP.Entities.User", "User")
                        .WithMany("ProductOwner")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MoqaydaGP.Entities.WishlistItem", b =>
                {
                    b.HasOne("MoqaydaGP.Entities.Product", "Product")
                        .WithMany("WishlistItem")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MoqaydaGP.Entities.User", "User")
                        .WithMany("WishlistItem")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
