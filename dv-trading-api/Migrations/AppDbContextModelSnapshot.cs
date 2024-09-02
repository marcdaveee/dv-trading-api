﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dv_trading_api.Data;

#nullable disable

namespace dv_trading_api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("dv_trading_api.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Tayabas",
                            ContactNo = "09231412823",
                            Email = "entom@gmail.com",
                            Name = "ENTOM"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Lucena",
                            ContactNo = "09441416123",
                            Email = "global.ph@gmail.com",
                            Name = "Global"
                        });
                });

            modelBuilder.Entity("dv_trading_api.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Bagong Niing",
                            ContactNo = "09231412823",
                            Email = "",
                            FirstName = "Ka",
                            LastName = "Rudy"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Rosario",
                            ContactNo = "09223412823",
                            Email = "abling@gmail.com",
                            FirstName = "Ka",
                            LastName = "Abling"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Blessed",
                            ContactNo = "+63 9223252823",
                            Email = "cordova123@gmail.com",
                            FirstName = "Alvin",
                            LastName = "Cordova"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Rosario",
                            ContactNo = "09223252823",
                            Email = "",
                            FirstName = "Richard",
                            LastName = "D."
                        });
                });

            modelBuilder.Entity("dv_trading_api.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<decimal>("Expenses")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MeterKgs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Moisture")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetResecada")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetWeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NoOfSacks")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PricePerKg")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 27995m,
                            Expenses = 500m,
                            MeterKgs = 70m,
                            Moisture = 7m,
                            NetResecada = 927m,
                            NetWeight = 1001m,
                            NoOfSacks = 24m,
                            PricePerKg = 30.2m,
                            SupplierId = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Amount = 25066m,
                            Expenses = 500m,
                            MeterKgs = 67m,
                            Moisture = 7.5m,
                            NetResecada = 830m,
                            NetWeight = 900m,
                            NoOfSacks = 21m,
                            PricePerKg = 30.2m,
                            SupplierId = 2,
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            Amount = 194807m,
                            CustomerId = 1,
                            Expenses = 500m,
                            MeterKgs = 246m,
                            Moisture = 4m,
                            NetResecada = 5904m,
                            NetWeight = 6150m,
                            NoOfSacks = 149m,
                            PricePerKg = 33m,
                            Type = 1
                        });
                });

            modelBuilder.Entity("dv_trading_api.Models.Transaction", b =>
                {
                    b.HasOne("dv_trading_api.Models.Customer", "Customer")
                        .WithMany("Transactions")
                        .HasForeignKey("CustomerId");

                    b.HasOne("dv_trading_api.Models.Supplier", "Supplier")
                        .WithMany("Transactions")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Customer");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("dv_trading_api.Models.Customer", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("dv_trading_api.Models.Supplier", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
