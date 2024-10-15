﻿// <auto-generated />
using System;
using CakeAppApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CakeAppApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241009112106_Adding OrderId To Products Automatically When Creating Order")]
    partial class AddingOrderIdToProductsAutomaticallyWhenCreatingOrder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CakeAppApi.Models.Entities.CustomCake", b =>
                {
                    b.Property<Guid>("CustomCakeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdditionalCakeLayer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CakeFilling")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CakeForm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasSugarDecoration")
                        .HasColumnType("bit");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfFloor")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfSlices")
                        .HasColumnType("int");

                    b.HasKey("CustomCakeId");

                    b.ToTable("CustomCakes");
                });

            modelBuilder.Entity("CakeAppApi.Models.Entities.IncludedProduct", b =>
                {
                    b.Property<Guid>("IncludedProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("IncludedProductId");

                    b.HasIndex("OrderId");

                    b.ToTable("IncludedProducts");
                });

            modelBuilder.Entity("CakeAppApi.Models.Entities.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomCakeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CakeAppApi.Models.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CakeAppApi.Models.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CakeAppApi.Models.Entities.IncludedProduct", b =>
                {
                    b.HasOne("CakeAppApi.Models.Entities.Order", null)
                        .WithMany("IncludedProducts")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("CakeAppApi.Models.Entities.Order", b =>
                {
                    b.Navigation("IncludedProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
