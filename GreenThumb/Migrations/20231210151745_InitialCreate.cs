using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreenThumb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Garden",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    garden_id = table.Column<int>(type: "int", nullable: false),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garden", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Garden_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    botanical_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GardenModelUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.id);
                    table.ForeignKey(
                        name: "FK_Plants_Garden_GardenModelUserId",
                        column: x => x.GardenModelUserId,
                        principalTable: "Garden",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    instruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    plant_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Instructions_Plants_plant_id",
                        column: x => x.plant_id,
                        principalTable: "Plants",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "id", "botanical_name", "description", "GardenModelUserId", "name" },
                values: new object[,]
                {
                    { 1, "Anemone nemorosa", "En blomma som blir 10-20 cm hög, med vita blad", null, "Vitsippa" },
                    { 2, "Helianthus annuus", "En blomma som kan bli 3 m hög, med stora gula blad", null, "Solros" },
                    { 3, "Helicodiceros muscivorus", "En illaluktande planta som sägs likna ändan på ett dött djur", null, "Fläckig drakkalla" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "password", "username" },
                values: new object[,]
                {
                    { 1, "123", "Emma" },
                    { 2, "STEFANÄRBÄST", "Stefan" }
                });

            migrationBuilder.InsertData(
                table: "Garden",
                columns: new[] { "UserId", "adress", "garden_id" },
                values: new object[,]
                {
                    { 1, "Stengatan 12, Malmö", 1 },
                    { 2, "Kärleksgatan 72C, Lund", 2 }
                });

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "id", "instruction", "plant_id" },
                values: new object[,]
                {
                    { 1, "Vattna varannan dag", 1 },
                    { 2, "Vattna varannan dag", 2 },
                    { 3, "Vattna varannan dag", 3 },
                    { 4, "Stäng näsan", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_plant_id",
                table: "Instructions",
                column: "plant_id");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_GardenModelUserId",
                table: "Plants",
                column: "GardenModelUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Garden");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
