using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sample.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0))),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0))),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    CategoryType = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    VendorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0))),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0))),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0))),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0))),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    VendorId = table.Column<int>(nullable: false),
                    ProductType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    LongDescription = table.Column<string>(maxLength: 2000, nullable: true),
                    UnitType = table.Column<byte>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    ShortDescription = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId1",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryType", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[] { 7, "Service", new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Cloud Services", null });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryType", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[] { 8, "Service", new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Guard Services", null });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryType", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[] { 1, "Shopping", new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Foods", null });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryType", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[] { 2, "Shopping", new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "TV", null });

            migrationBuilder.InsertData(
                table: "Vendor",
                columns: new[] { "VendorId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Microsoft" });

            migrationBuilder.InsertData(
                table: "Vendor",
                columns: new[] { "VendorId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Oracle" });

            migrationBuilder.InsertData(
                table: "Vendor",
                columns: new[] { "VendorId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Apple" });

            migrationBuilder.InsertData(
                table: "Vendor",
                columns: new[] { "VendorId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Mc Donalts" });

            migrationBuilder.InsertData(
                table: "Vendor",
                columns: new[] { "VendorId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[] { 5, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Migros" });

            migrationBuilder.InsertData(
                table: "Vendor",
                columns: new[] { "VendorId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[] { 6, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Sony" });

            migrationBuilder.InsertData(
                table: "Vendor",
                columns: new[] { "VendorId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[] { 7, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Lg" });

            migrationBuilder.InsertData(
                table: "Vendor",
                columns: new[] { "VendorId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[] { 8, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Sam Güvenlik" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryType", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[] { 9, "Service", new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Virtual Machine", 7 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryType", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[] { 10, "Service", new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Body Guard", 8 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryType", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[] { 3, "Shopping", new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Fast Food", 1 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryType", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[] { 4, "Shopping", new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Vegitables", 1 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryType", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[] { 5, "Shopping", new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Oled TV", 2 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryType", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[] { 6, "Shopping", new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Led TV", 2 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "ProductType", "UnitPrice", "VendorId", "CategoryId", "Description", "LongDescription", "UnitType" },
                values: new object[] { 5, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Azure E03 Virtual Machine", 2, 0.90000000000000002, 1, 9, "4VCPU, 8GB Ram Description", "4VCPU, 8GB Ram Long Description", (byte)20 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "ProductType", "UnitPrice", "VendorId", "CategoryId", "Description", "LongDescription", "UnitType" },
                values: new object[] { 6, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Oracle Cloud V05 Virtual Machine", 2, 0.84999999999999998, 2, 9, "4VCPU, 8GB Ram Description", "4VCPU, 8GB Ram Long Description", (byte)20 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "ProductType", "UnitPrice", "VendorId", "CategoryId", "Description", "LongDescription", "UnitType" },
                values: new object[] { 7, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Body Guard Service", 2, 150.0, 8, 10, "Body Guard Service Description", "Body Guard Service Long Description", (byte)20 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "ProductType", "UnitPrice", "VendorId", "CategoryId", "Description", "ShortDescription", "UnitType" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Hamburger", 1, 15.5, 4, 3, "Hamburger Description", "Hamburger Short Description", (byte)0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "ProductType", "UnitPrice", "VendorId", "CategoryId", "Description", "ShortDescription", "UnitType" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "Potatos", 1, 10.0, 5, 4, "Potatos Description", "Potatos Short Description", (byte)10 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "ProductType", "UnitPrice", "VendorId", "CategoryId", "Description", "ShortDescription", "UnitType" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "SONY 48A9 49'' 121 CM 4K UHD", 1, 15.5, 6, 5, "SONY 48A9 49'' 121 CM 4K UHD OLED ANDROID SMART TV,DAHİLİ UYDU ALICI Description", "SONY 48A9 49'' 121 CM 4K UHD OLED ANDROID SMART TV,DAHİLİ UYDU ALICI Short Description", (byte)0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "ProductType", "UnitPrice", "VendorId", "CategoryId", "Description", "ShortDescription", "UnitType" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, new DateTimeOffset(new DateTime(2020, 10, 18, 13, 36, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), -1, "LG 24TL510S 24'' 60 CM HD SMART TV,HDMI,USB,DAHİLİ UYDU ALICI,SİYAH", 1, 10.0, 7, 6, "LG 24TL510S 24'' 60 CM HD SMART TV,HDMI,USB,DAHİLİ UYDU ALICI,SİYAH Description", "LG 24TL510S 24'' 60 CM HD SMART TV,HDMI,USB,DAHİLİ UYDU ALICI,SİYAH Short Description", (byte)10 });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                table: "Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_VendorId",
                table: "Product",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId1",
                table: "Product",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
