﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantAPI.Entities;

#nullable disable

namespace RestaurantAPI.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20220425074722_addressColumnAdjustment")]
    partial class addressColumnAdjustment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RestaurantAPI.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            City = "Karków",
                            PostalCode = "30-001",
                            Street = "Miejska 10"
                        },
                        new
                        {
                            Id = 1,
                            City = "Kraków",
                            PostalCode = "30-001",
                            Street = "Długa 10"
                        });
                });

            modelBuilder.Entity("RestaurantAPI.Entities.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "",
                            Name = "burger",
                            Price = 8.30m,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "",
                            Name = "Cheeseburger",
                            Price = 10.30m,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "",
                            Name = "Chiken Nuggets",
                            Price = 12.50m,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "",
                            Name = "salad",
                            Price = 11.30m,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 5,
                            Description = "",
                            Name = "BigBurger",
                            Price = 10.30m,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 6,
                            Description = "",
                            Name = "Chiken Nuggets",
                            Price = 13.50m,
                            RestaurantId = 2
                        });
                });

            modelBuilder.Entity("RestaurantAPI.Entities.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasDelivery")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            Category = "fast food",
                            ContactEmail = "kfc@gmail.com",
                            ContactNumber = "222333444",
                            Description = "KFC american fast food restaurant",
                            HasDelivery = true,
                            Name = "KFC"
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            Category = "fast food",
                            ContactEmail = "mcdonald@gmail.com",
                            ContactNumber = "555333444",
                            Description = "McDonald american fast food restaurant",
                            HasDelivery = false,
                            Name = "McDonald"
                        });
                });

            modelBuilder.Entity("RestaurantAPI.Entities.Dish", b =>
                {
                    b.HasOne("RestaurantAPI.Entities.Restaurant", "Restaurant")
                        .WithMany("Dishes")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantAPI.Entities.Restaurant", b =>
                {
                    b.HasOne("RestaurantAPI.Entities.Address", "Address")
                        .WithOne("Restaurant")
                        .HasForeignKey("RestaurantAPI.Entities.Restaurant", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("RestaurantAPI.Entities.Address", b =>
                {
                    b.Navigation("Restaurant")
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantAPI.Entities.Restaurant", b =>
                {
                    b.Navigation("Dishes");
                });
#pragma warning restore 612, 618
        }
    }
}
