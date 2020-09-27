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
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 1, "Yiyecek" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 2, "Kırtasiye" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "Name" },
                values: new object[] { 1, 1, "Hamburger" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "Name" },
                values: new object[] { 2, 1, "Kuru Fasülye" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "Name" },
                values: new object[] { 3, 2, "Kalem" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "Name" },
                values: new object[] { 4, 2, "Silgi" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
