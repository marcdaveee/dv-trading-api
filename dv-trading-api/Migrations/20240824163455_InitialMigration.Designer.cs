﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dv_trading_api.Data;

#nullable disable

namespace dv_trading_api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240824163455_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
#pragma warning restore 612, 618
        }
    }
}
