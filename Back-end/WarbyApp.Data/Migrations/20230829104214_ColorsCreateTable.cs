using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarbyApp.Data.Migrations
{
    public partial class ColorsCreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ColorImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EyeglassesColors",
                columns: table => new
                {
                    EyeglassesId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyeglassesColors", x => new { x.EyeglassesId, x.ColorId });
                    table.ForeignKey(
                        name: "FK_EyeglassesColors_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EyeglassesColors_Eyeglasses_EyeglassesId",
                        column: x => x.EyeglassesId,
                        principalTable: "Eyeglasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SunglassesColors",
                columns: table => new
                {
                    SunglassesId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SunglassesColors", x => new { x.SunglassesId, x.ColorId });
                    table.ForeignKey(
                        name: "FK_SunglassesColors_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SunglassesColors_Sunglasses_SunglassesId",
                        column: x => x.SunglassesId,
                        principalTable: "Sunglasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EyeglassesColors_ColorId",
                table: "EyeglassesColors",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_SunglassesColors_ColorId",
                table: "SunglassesColors",
                column: "ColorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EyeglassesColors");

            migrationBuilder.DropTable(
                name: "SunglassesColors");

            migrationBuilder.DropTable(
                name: "Colors");
        }
    }
}
