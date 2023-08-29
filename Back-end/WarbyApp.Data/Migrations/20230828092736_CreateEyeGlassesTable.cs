using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarbyApp.Data.Migrations
{
    public partial class CreateEyeGlassesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eyeglasses",
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eyeglasses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eyeglasses");
        }
    }
}
