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
    [Migration("20201018111049_Initial")]
    partial class Initial
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

                    b.Property<string>("CategoryType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("ModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)));

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasDiscriminator<string>("CategoryType").HasValue("Category");
                });

            modelBuilder.Entity("Sample.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("ModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)));

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(32);

                    b.Property<int>("ProductType")
                        .HasColumnType("INTEGER");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("REAL");

                    b.Property<int>("VendorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VendorId");

                    b.ToTable("Product");

                    b.HasDiscriminator<int>("ProductType");
                });

            modelBuilder.Entity("Sample.Data.Entities.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VendorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("ModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)));

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("Vendor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Microsoft"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Oracle"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Apple"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Mc Donalts"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Migros"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Sony"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Lg"
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Sam Güvenlik"
                        });
                });

            modelBuilder.Entity("Sample.Data.Entities.ServiceCategory", b =>
                {
                    b.HasBaseType("Sample.Data.Entities.Category");

                    b.Property<int?>("ParentId")
                        .HasColumnName("ParentId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("ParentId");

                    b.HasDiscriminator().HasValue("Service");

                    b.HasData(
                        new
                        {
                            Id = 7,
                            CategoryType = "Service",
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Cloud Services"
                        },
                        new
                        {
                            Id = 8,
                            CategoryType = "Service",
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Guard Services"
                        },
                        new
                        {
                            Id = 9,
                            CategoryType = "Service",
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Virtual Machine",
                            ParentId = 7
                        },
                        new
                        {
                            Id = 10,
                            CategoryType = "Service",
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Body Guard",
                            ParentId = 8
                        });
                });

            modelBuilder.Entity("Sample.Data.Entities.ShoppingCategory", b =>
                {
                    b.HasBaseType("Sample.Data.Entities.Category");

                    b.Property<int?>("ParentId")
                        .HasColumnName("ParentId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("ParentId");

                    b.HasDiscriminator().HasValue("Shopping");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryType = "Shopping",
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Foods"
                        },
                        new
                        {
                            Id = 2,
                            CategoryType = "Shopping",
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "TV"
                        },
                        new
                        {
                            Id = 3,
                            CategoryType = "Shopping",
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Fast Food",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 4,
                            CategoryType = "Shopping",
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Vegitables",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 5,
                            CategoryType = "Shopping",
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Oled TV",
                            ParentId = 2
                        },
                        new
                        {
                            Id = 6,
                            CategoryType = "Shopping",
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Led TV",
                            ParentId = 2
                        });
                });

            modelBuilder.Entity("Sample.Data.Entities.ServiceProduct", b =>
                {
                    b.HasBaseType("Sample.Data.Entities.Product");

                    b.Property<int>("CategoryId")
                        .HasColumnName("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.Property<string>("LongDescription")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.Property<byte>("UnitType")
                        .HasColumnName("UnitType")
                        .HasColumnType("INTEGER");

                    b.HasIndex("CategoryId");

                    b.HasDiscriminator().HasValue(2);

                    b.HasData(
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Azure E03 Virtual Machine",
                            ProductType = 2,
                            UnitPrice = 0.90000000000000002,
                            VendorId = 1,
                            CategoryId = 9,
                            Description = "4VCPU, 8GB Ram Description",
                            LongDescription = "4VCPU, 8GB Ram Long Description",
                            UnitType = (byte)20
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Oracle Cloud V05 Virtual Machine",
                            ProductType = 2,
                            UnitPrice = 0.84999999999999998,
                            VendorId = 2,
                            CategoryId = 9,
                            Description = "4VCPU, 8GB Ram Description",
                            LongDescription = "4VCPU, 8GB Ram Long Description",
                            UnitType = (byte)20
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Body Guard Service",
                            ProductType = 2,
                            UnitPrice = 150.0,
                            VendorId = 8,
                            CategoryId = 10,
                            Description = "Body Guard Service Description",
                            LongDescription = "Body Guard Service Long Description",
                            UnitType = (byte)20
                        });
                });

            modelBuilder.Entity("Sample.Data.Entities.ShoppingProduct", b =>
                {
                    b.HasBaseType("Sample.Data.Entities.Product");

                    b.Property<int>("CategoryId")
                        .HasColumnName("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.Property<byte>("UnitType")
                        .HasColumnName("UnitType")
                        .HasColumnType("INTEGER");

                    b.HasIndex("CategoryId")
                        .HasName("IX_Product_CategoryId1");

                    b.HasDiscriminator().HasValue(1);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Hamburger",
                            ProductType = 1,
                            UnitPrice = 15.5,
                            VendorId = 4,
                            CategoryId = 3,
                            Description = "Hamburger Description",
                            ShortDescription = "Hamburger Short Description",
                            UnitType = (byte)0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "Potatos",
                            ProductType = 1,
                            UnitPrice = 10.0,
                            VendorId = 5,
                            CategoryId = 4,
                            Description = "Potatos Description",
                            ShortDescription = "Potatos Short Description",
                            UnitType = (byte)10
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "SONY 48A9 49'' 121 CM 4K UHD",
                            ProductType = 1,
                            UnitPrice = 15.5,
                            VendorId = 6,
                            CategoryId = 5,
                            Description = "SONY 48A9 49'' 121 CM 4K UHD OLED ANDROID SMART TV,DAHİLİ UYDU ALICI Description",
                            ShortDescription = "SONY 48A9 49'' 121 CM 4K UHD OLED ANDROID SMART TV,DAHİLİ UYDU ALICI Short Description",
                            UnitType = (byte)0
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedBy = -1,
                            ModifiedAt = new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            ModifiedBy = -1,
                            Name = "LG 24TL510S 24'' 60 CM HD SMART TV,HDMI,USB,DAHİLİ UYDU ALICI,SİYAH",
                            ProductType = 1,
                            UnitPrice = 10.0,
                            VendorId = 7,
                            CategoryId = 6,
                            Description = "LG 24TL510S 24'' 60 CM HD SMART TV,HDMI,USB,DAHİLİ UYDU ALICI,SİYAH Description",
                            ShortDescription = "LG 24TL510S 24'' 60 CM HD SMART TV,HDMI,USB,DAHİLİ UYDU ALICI,SİYAH Short Description",
                            UnitType = (byte)10
                        });
                });

            modelBuilder.Entity("Sample.Data.Entities.Product", b =>
                {
                    b.HasOne("Sample.Data.Entities.Vendor", "Vendor")
                        .WithMany("Products")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sample.Data.Entities.ServiceCategory", b =>
                {
                    b.HasOne("Sample.Data.Entities.ServiceCategory", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Sample.Data.Entities.ShoppingCategory", b =>
                {
                    b.HasOne("Sample.Data.Entities.ShoppingCategory", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Sample.Data.Entities.ServiceProduct", b =>
                {
                    b.HasOne("Sample.Data.Entities.ServiceCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sample.Data.Entities.ShoppingProduct", b =>
                {
                    b.HasOne("Sample.Data.Entities.ShoppingCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Product_Category_CategoryId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
