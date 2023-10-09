﻿// <auto-generated />
using System;
using CarRental.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRental.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230919050755_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarRental.Shared.Entity.Car", b =>
                {
                    b.Property<Guid>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Maker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RentalPricePerDay")
                        .HasColumnType("float");

                    b.HasKey("CarId");

                    b.ToTable("car");
                });

            modelBuilder.Entity("CarRental.Shared.Entity.RentalAgreement", b =>
                {
                    b.Property<Guid>("RentalAgreementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RequestForReturn")
                        .HasColumnType("bit");

                    b.Property<bool>("ReturnRequestAccepted")
                        .HasColumnType("bit");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalCost")
                        .HasColumnType("float");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RentalAgreementId");

                    b.ToTable("rentalagreement");
                });

            modelBuilder.Entity("CarRental.Shared.Entity.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("user");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("ebb78241-6990-4ee9-8c2b-968bd3e400c3"),
                            Email = "admin@test.com",
                            IsAdmin = true,
                            Name = "Admin",
                            Password = "admin123",
                            PhoneNo = "9990724214"
                        },
                        new
                        {
                            UserId = new Guid("2d8382a4-1c87-45e7-86e1-b2fcfa0741aa"),
                            Email = "gulshan@test.com",
                            IsAdmin = false,
                            Name = "Gulshan",
                            Password = "gulshan123",
                            PhoneNo = "7011856425"
                        },
                        new
                        {
                            UserId = new Guid("fac2a973-aaea-4108-a31d-1cad2f662fad"),
                            Email = "dubey@test.com",
                            IsAdmin = false,
                            Name = "Dubey",
                            Password = "dubey123",
                            PhoneNo = "8198093390"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
