using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarbyApp.Data.Migrations
{
    public partial class CategoryTableCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EyeglassesCategories",
                columns: table => new
                {
                    EyeglassesId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyeglassesCategories", x => new { x.EyeglassesId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_EyeglassesCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EyeglassesCategories_Eyeglasses_EyeglassesId",
                        column: x => x.EyeglassesId,
                        principalTable: "Eyeglasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SunglassesCategories",
                columns: table => new
                {
                    SunglassesId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SunglassesCategories", x => new { x.SunglassesId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_SunglassesCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SunglassesCategories_Sunglasses_SunglassesId",
                        column: x => x.SunglassesId,
                        principalTable: "Sunglasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EyeglassesCategories_CategoryId",
                table: "EyeglassesCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SunglassesCategories_CategoryId",
                table: "SunglassesCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EyeglassesCategories");

            migrationBuilder.DropTable(
                name: "SunglassesCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
