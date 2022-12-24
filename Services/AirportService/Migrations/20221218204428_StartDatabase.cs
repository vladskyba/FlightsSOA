using Microsoft.EntityFrameworkCore.Migrations;

namespace Airport.Migrations
{
    public partial class StartDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "airport_address",
                columns: table => new
                {
                    airport_address_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    zip = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    airport_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airport_address", x => x.airport_address_id);
                });

            migrationBuilder.CreateTable(
                name: "airport",
                columns: table => new
                {
                    airport_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    airport_address_id = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airport", x => x.airport_id);
                    table.ForeignKey(
                        name: "FK_airport_airport_address_airport_address_id",
                        column: x => x.airport_address_id,
                        principalTable: "airport_address",
                        principalColumn: "airport_address_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_airport_airport_address_id",
                table: "airport",
                column: "airport_address_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_airport_address_city",
                table: "airport_address",
                column: "city",
                unique: true,
                filter: "[city] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_airport_address_country",
                table: "airport_address",
                column: "country",
                unique: true,
                filter: "[country] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_airport_address_zip",
                table: "airport_address",
                column: "zip",
                unique: true,
                filter: "[zip] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "airport");

            migrationBuilder.DropTable(
                name: "airport_address");
        }
    }
}
