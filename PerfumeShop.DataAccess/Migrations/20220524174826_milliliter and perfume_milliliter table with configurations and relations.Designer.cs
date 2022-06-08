﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PerfumeShop.DataAccess;

#nullable disable

namespace PerfumeShop.DataAccess.Migrations
{
    [DbContext(typeof(PerfumeContext))]
    [Migration("20220524174826_milliliter and perfume_milliliter table with configurations and relations")]
    partial class milliliterandperfume_millilitertablewithconfigurationsandrelations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PerfumeShop.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BrandName")
                        .IsUnique();

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("PerfumeShop.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryName")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PerfumeShop.Domain.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PerfumeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PerfumeId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("PerfumeShop.Domain.Entities.Milliliter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Milliliters");
                });

            modelBuilder.Entity("PerfumeShop.Domain.Entities.Perfume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Perfumes");
                });

            modelBuilder.Entity("PerfumeShop.Domain.Entities.PerfumeMilliliter", b =>
                {
                    b.Property<int>("PerfumeId")
                        .HasColumnType("int");

                    b.Property<int>("MilliliterId")
                        .HasColumnType("int");

                    b.HasKey("PerfumeId", "MilliliterId");

                    b.HasIndex("MilliliterId");

                    b.ToTable("PerfumeMilliliters");
                });

            modelBuilder.Entity("PerfumeShop.Domain.Entities.PerfumeProductType", b =>
                {
                    b.Property<int>("PerfumeId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.HasKey("PerfumeId", "ProductTypeId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("PerfumeProductTypes");
                });

            modelBuilder.Entity("PerfumeShop.Domain.Entities.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("PerfumeShop.Domain.Entities.Image", b =>
                {
                    b.HasOne("PerfumeShop.Domain.Entities.Perfume", "Perfume")
                        .WithMany("Images")
                        .HasForeignKey("PerfumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfume");
                });

            modelBuilder.Entity("PerfumeShop.Domain.Entities.Perfume", b =>
                {
                    b.HasOne("PerfumeShop.Domain.Entities.Brand", "Brand")
                        .WithMany("Perfumes")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PerfumeShop.Domain.Entities.Category", "Category")
                        .WithMany("Perfumes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PerfumeShop.Domain.Entities.PerfumeMilliliter", b =>
                {
                    b.HasOne("PerfumeShop.Domain.Entities.Milliliter", "Milliliter")
                        .WithMany("PerfumeMilliliters")
                        .HasForeignKey("MilliliterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PerfumeShop.Domain.Entities.Perfume", "Perfume")
                        .WithMany("PerfumeMilliliters")
                        .HasForeignKey("PerfumeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Milliliter");

                    b.Navigation("Perfume");
                });

            modelBuilder.Entity("PerfumeShop.Domain.Entities.PerfumeProductType", b =>
                {
                    b.HasOne("PerfumeShop.Domain.Entities.Perfume", "Perfume")
                        .WithMany("PerfumeProductTypes")
                        .HasForeignKey("PerfumeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PerfumeShop.Domain.Entities.ProductType", "ProductType")
                        .WithMany("PerfumeProductTypes")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Perfume");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("PerfumeShop.Domain.Entities.Brand", b =>
                {
                    b.Navigation("Perfumes");
                });

            modelBuilder.Entity("PerfumeShop.Domain.Entities.Category", b =>
                {
                    b.Navigation("Perfumes");
                });

            modelBuilder.Entity("PerfumeShop.Domain.Entities.Milliliter", b =>
                {
                    b.Navigation("PerfumeMilliliters");
                });

            modelBuilder.Entity("PerfumeShop.Domain.Entities.Perfume", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("PerfumeMilliliters");

                    b.Navigation("PerfumeProductTypes");
                });

            modelBuilder.Entity("PerfumeShop.Domain.Entities.ProductType", b =>
                {
                    b.Navigation("PerfumeProductTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
