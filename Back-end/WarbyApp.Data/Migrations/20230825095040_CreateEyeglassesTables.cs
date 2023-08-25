using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarbyApp.Data.Migrations
{
    public partial class CreateEyeglassesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BridgeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BridgeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColorCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColorImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorImages", x => x.Id);
                });

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
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenCategory = table.Column<bool>(type: "bit", nullable: false),
                    WomenCategory = table.Column<bool>(type: "bit", nullable: false),
                    AllCategory = table.Column<bool>(type: "bit", nullable: false),
                    NewarrivalsCategory = table.Column<bool>(type: "bit", nullable: false),
                    BestsellersCategory = table.Column<bool>(type: "bit", nullable: false),
                    ClassicmetalsCategory = table.Column<bool>(type: "bit", nullable: false),
                    AutumnaltonesCategory = table.Column<bool>(type: "bit", nullable: false),
                    BoldshapesCategory = table.Column<bool>(type: "bit", nullable: false),
                    Description1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eyeglasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeaturesCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturesCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShapeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShapeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WidthCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidthCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EyeglassesBridgeCategories",
                columns: table => new
                {
                    EyeglassesId = table.Column<int>(type: "int", nullable: false),
                    BridgeCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyeglassesBridgeCategories", x => new { x.EyeglassesId, x.BridgeCategoryId });
                    table.ForeignKey(
                        name: "FK_EyeglassesBridgeCategories_BridgeCategories_BridgeCategoryId",
                        column: x => x.BridgeCategoryId,
                        principalTable: "BridgeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EyeglassesBridgeCategories_Eyeglasses_EyeglassesId",
                        column: x => x.EyeglassesId,
                        principalTable: "Eyeglasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EyeglassesColorCategories",
                columns: table => new
                {
                    EyeglassesId = table.Column<int>(type: "int", nullable: false),
                    ColorCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyeglassesColorCategories", x => new { x.EyeglassesId, x.ColorCategoryId });
                    table.ForeignKey(
                        name: "FK_EyeglassesColorCategories_ColorCategories_ColorCategoryId",
                        column: x => x.ColorCategoryId,
                        principalTable: "ColorCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EyeglassesColorCategories_Eyeglasses_EyeglassesId",
                        column: x => x.EyeglassesId,
                        principalTable: "Eyeglasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EyeglassesImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorImageId = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EyeglassesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyeglassesImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EyeglassesImages_ColorImages_ColorImageId",
                        column: x => x.ColorImageId,
                        principalTable: "ColorImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EyeglassesImages_Eyeglasses_EyeglassesId",
                        column: x => x.EyeglassesId,
                        principalTable: "Eyeglasses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EyeglassesFeaturesCategories",
                columns: table => new
                {
                    EyeglassesId = table.Column<int>(type: "int", nullable: false),
                    FeaturesCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyeglassesFeaturesCategories", x => new { x.EyeglassesId, x.FeaturesCategoryId });
                    table.ForeignKey(
                        name: "FK_EyeglassesFeaturesCategories_Eyeglasses_EyeglassesId",
                        column: x => x.EyeglassesId,
                        principalTable: "Eyeglasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EyeglassesFeaturesCategories_FeaturesCategories_FeaturesCategoryId",
                        column: x => x.FeaturesCategoryId,
                        principalTable: "FeaturesCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EyeglassesMaterialCategories",
                columns: table => new
                {
                    EyeglassesId = table.Column<int>(type: "int", nullable: false),
                    MaterialCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyeglassesMaterialCategories", x => new { x.EyeglassesId, x.MaterialCategoryId });
                    table.ForeignKey(
                        name: "FK_EyeglassesMaterialCategories_Eyeglasses_EyeglassesId",
                        column: x => x.EyeglassesId,
                        principalTable: "Eyeglasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EyeglassesMaterialCategories_MaterialCategories_MaterialCategoryId",
                        column: x => x.MaterialCategoryId,
                        principalTable: "MaterialCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EyeglassesPrescriptionCategories",
                columns: table => new
                {
                    EyeglassesId = table.Column<int>(type: "int", nullable: false),
                    PrescriptionCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyeglassesPrescriptionCategories", x => new { x.EyeglassesId, x.PrescriptionCategoryId });
                    table.ForeignKey(
                        name: "FK_EyeglassesPrescriptionCategories_Eyeglasses_EyeglassesId",
                        column: x => x.EyeglassesId,
                        principalTable: "Eyeglasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EyeglassesPrescriptionCategories_PrescriptionCategories_PrescriptionCategoryId",
                        column: x => x.PrescriptionCategoryId,
                        principalTable: "PrescriptionCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EyeglassesPriceCategories",
                columns: table => new
                {
                    EyeglassesId = table.Column<int>(type: "int", nullable: false),
                    PriceCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyeglassesPriceCategories", x => new { x.EyeglassesId, x.PriceCategoryId });
                    table.ForeignKey(
                        name: "FK_EyeglassesPriceCategories_Eyeglasses_EyeglassesId",
                        column: x => x.EyeglassesId,
                        principalTable: "Eyeglasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EyeglassesPriceCategories_PriceCategories_PriceCategoryId",
                        column: x => x.PriceCategoryId,
                        principalTable: "PriceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EyeglassesShapeCategories",
                columns: table => new
                {
                    EyeglassesId = table.Column<int>(type: "int", nullable: false),
                    ShapeCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyeglassesShapeCategories", x => new { x.EyeglassesId, x.ShapeCategoryId });
                    table.ForeignKey(
                        name: "FK_EyeglassesShapeCategories_Eyeglasses_EyeglassesId",
                        column: x => x.EyeglassesId,
                        principalTable: "Eyeglasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EyeglassesShapeCategories_ShapeCategories_ShapeCategoryId",
                        column: x => x.ShapeCategoryId,
                        principalTable: "ShapeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EyeglassesWidthCategories",
                columns: table => new
                {
                    EyeglassesId = table.Column<int>(type: "int", nullable: false),
                    WidthCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyeglassesWidthCategories", x => new { x.EyeglassesId, x.WidthCategoryId });
                    table.ForeignKey(
                        name: "FK_EyeglassesWidthCategories_Eyeglasses_EyeglassesId",
                        column: x => x.EyeglassesId,
                        principalTable: "Eyeglasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EyeglassesWidthCategories_WidthCategories_WidthCategoryId",
                        column: x => x.WidthCategoryId,
                        principalTable: "WidthCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EyeglassesBridgeCategories_BridgeCategoryId",
                table: "EyeglassesBridgeCategories",
                column: "BridgeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EyeglassesColorCategories_ColorCategoryId",
                table: "EyeglassesColorCategories",
                column: "ColorCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EyeglassesFeaturesCategories_FeaturesCategoryId",
                table: "EyeglassesFeaturesCategories",
                column: "FeaturesCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EyeglassesImages_ColorImageId",
                table: "EyeglassesImages",
                column: "ColorImageId");

            migrationBuilder.CreateIndex(
                name: "IX_EyeglassesImages_EyeglassesId",
                table: "EyeglassesImages",
                column: "EyeglassesId");

            migrationBuilder.CreateIndex(
                name: "IX_EyeglassesMaterialCategories_MaterialCategoryId",
                table: "EyeglassesMaterialCategories",
                column: "MaterialCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EyeglassesPrescriptionCategories_PrescriptionCategoryId",
                table: "EyeglassesPrescriptionCategories",
                column: "PrescriptionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EyeglassesPriceCategories_PriceCategoryId",
                table: "EyeglassesPriceCategories",
                column: "PriceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EyeglassesShapeCategories_ShapeCategoryId",
                table: "EyeglassesShapeCategories",
                column: "ShapeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EyeglassesWidthCategories_WidthCategoryId",
                table: "EyeglassesWidthCategories",
                column: "WidthCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EyeglassesBridgeCategories");

            migrationBuilder.DropTable(
                name: "EyeglassesColorCategories");

            migrationBuilder.DropTable(
                name: "EyeglassesFeaturesCategories");

            migrationBuilder.DropTable(
                name: "EyeglassesImages");

            migrationBuilder.DropTable(
                name: "EyeglassesMaterialCategories");

            migrationBuilder.DropTable(
                name: "EyeglassesPrescriptionCategories");

            migrationBuilder.DropTable(
                name: "EyeglassesPriceCategories");

            migrationBuilder.DropTable(
                name: "EyeglassesShapeCategories");

            migrationBuilder.DropTable(
                name: "EyeglassesWidthCategories");

            migrationBuilder.DropTable(
                name: "BridgeCategories");

            migrationBuilder.DropTable(
                name: "ColorCategories");

            migrationBuilder.DropTable(
                name: "FeaturesCategories");

            migrationBuilder.DropTable(
                name: "ColorImages");

            migrationBuilder.DropTable(
                name: "MaterialCategories");

            migrationBuilder.DropTable(
                name: "PrescriptionCategories");

            migrationBuilder.DropTable(
                name: "PriceCategories");

            migrationBuilder.DropTable(
                name: "ShapeCategories");

            migrationBuilder.DropTable(
                name: "Eyeglasses");

            migrationBuilder.DropTable(
                name: "WidthCategories");
        }
    }
}
