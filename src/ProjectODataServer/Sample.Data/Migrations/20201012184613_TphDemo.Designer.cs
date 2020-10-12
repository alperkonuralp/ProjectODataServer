﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sample.Data.DbContexts;

namespace Sample.Data.Migrations
{
    [DbContext(typeof(SampleDataDbContext))]
    [Migration("20201012184613_TphDemo")]
    partial class TphDemo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("Sample.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Yiyecek"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Kırtasiye"
                        });
                });

            modelBuilder.Entity("Sample.Data.Entities.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(32);

                    b.Property<DateTime>("OperationDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("OperationType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Operation");

                    b.HasDiscriminator<string>("OperationType").HasValue("Operation");
                });

            modelBuilder.Entity("Sample.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "Hamburger"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "Kuru Fasülye"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Name = "Kalem"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Name = "Silgi"
                        });
                });

            modelBuilder.Entity("Sample.Data.Entities.AccidentOperation", b =>
                {
                    b.HasBaseType("Sample.Data.Entities.Operation");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnName("Type")
                        .HasColumnType("TEXT")
                        .HasMaxLength(32);

                    b.HasDiscriminator().HasValue("AccidentOperation");
                });

            modelBuilder.Entity("Sample.Data.Entities.TireOperation", b =>
                {
                    b.HasBaseType("Sample.Data.Entities.Operation");

                    b.HasDiscriminator().HasValue("TireOperation");
                });

            modelBuilder.Entity("Sample.Data.Entities.TollOperation", b =>
                {
                    b.HasBaseType("Sample.Data.Entities.Operation");

                    b.Property<double>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("REAL");

                    b.HasDiscriminator().HasValue("TollOperation");
                });

            modelBuilder.Entity("Sample.Data.Entities.TrafficPenaltyOperation", b =>
                {
                    b.HasBaseType("Sample.Data.Entities.Operation");

                    b.Property<double>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnName("Type")
                        .HasColumnType("TEXT")
                        .HasMaxLength(32);

                    b.HasDiscriminator().HasValue("TrafficPenaltyOperation");
                });

            modelBuilder.Entity("Sample.Data.Entities.WinterTireOperation", b =>
                {
                    b.HasBaseType("Sample.Data.Entities.Operation");

                    b.Property<string>("DepotLocation")
                        .IsRequired()
                        .HasColumnName("DepotLocation")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("WinterTireOperation");
                });

            modelBuilder.Entity("Sample.Data.Entities.Product", b =>
                {
                    b.HasOne("Sample.Data.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
