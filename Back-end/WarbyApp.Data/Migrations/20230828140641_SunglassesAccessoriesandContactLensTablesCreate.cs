using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarbyApp.Data.Migrations
{
    public partial class SunglassesAccessoriesandContactLensTablesCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactLens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AcuvueBrand = table.Column<bool>(type: "bit", nullable: false),
                    DailiesBrand = table.Column<bool>(type: "bit", nullable: false),
                    BiofinityBrand = table.Column<bool>(type: "bit", nullable: false),
                    AiroptikBrand = table.Column<bool>(type: "bit", nullable: false),
                    BiotrueBrand = table.Column<bool>(type: "bit", nullable: false),
                    PrecisionBrand = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactLens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sunglasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Material = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CostPrice = table.Column<decimal>(type: "money", nullable: false),
                    SalePrice = table.Column<decimal>(type: "money", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    AllCategory = table.Column<bool>(type: "bit", nullable: false),
                    NewarrivalsCategory = table.Column<bool>(type: "bit", nullable: false),
                    BestsellersCategory = table.Column<bool>(type: "bit", nullable: false),
                    ClassicmetalsCategory = table.Column<bool>(type: "bit", nullable: false),
                    AutumnaltonesCategory = table.Column<bool>(type: "bit", nullable: false),
                    BoldshapesCategory = table.Column<bool>(type: "bit", nullable: false),
                    Description1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sunglasses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "ContactLens");

            migrationBuilder.DropTable(
                name: "Sunglasses");
        }
    }
}
