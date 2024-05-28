using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FoodStuff.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brand_name",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__brand_na__3214EC27B54F785E", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "brand_owner",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__brand_ow__3214EC27E4688E04", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "food_category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__food_cat__3214EC2758EFC520", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "food",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    fdc_id = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    brand_name_id = table.Column<int>(type: "integer", nullable: true),
                    brand_owner_id = table.Column<int>(type: "integer", nullable: true),
                    food_category_id = table.Column<int>(type: "integer", nullable: true),
                    ingredients = table.Column<string>(type: "character varying(511)", maxLength: 511, nullable: true),
                    serving_size = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    serving_size_unit = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    update_year = table.Column<short>(type: "smallint", nullable: true),
                    sugars_amount = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    sugars_unit = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    fatty_acids_amount = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    fatty_acids_unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    cholesterol_amount = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    cholesterol_unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    vitamin_c_amount = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    vitamin_c_unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    vitamin_d_amount = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    vitamin_d_unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    vitamin_a_amount = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    vitamin_a_unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    sodium_amount = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    sodium_unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    potassium_amount = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    potassium_unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    iron_amount = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    iron_unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    calcium_amount = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    calcium_unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    fiber_amount = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    fiber_unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    energy_amount = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    energy_unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    carb_amount = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    carb_unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    fat_amount = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    fat_unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    protein_amount = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    protein_unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_food", x => x.ID);
                    table.ForeignKey(
                        name: "FK_food_brand_name",
                        column: x => x.brand_name_id,
                        principalTable: "brand_name",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_food_brand_owner",
                        column: x => x.brand_owner_id,
                        principalTable: "brand_owner",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_food_food_category",
                        column: x => x.food_category_id,
                        principalTable: "food_category",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_food_brand_name_id",
                table: "food",
                column: "brand_name_id");

            migrationBuilder.CreateIndex(
                name: "IX_food_brand_owner_id",
                table: "food",
                column: "brand_owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_food_food_category_id",
                table: "food",
                column: "food_category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "food");

            migrationBuilder.DropTable(
                name: "brand_name");

            migrationBuilder.DropTable(
                name: "brand_owner");

            migrationBuilder.DropTable(
                name: "food_category");
        }
    }
}
