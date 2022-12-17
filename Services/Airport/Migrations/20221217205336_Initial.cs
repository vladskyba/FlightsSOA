using Microsoft.EntityFrameworkCore.Migrations;

namespace Airport.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "airport_address",
                columns: table => new
                {
                    AirportModelsAirportAddress_id = table.Column<long>(name: "Airport.Models.AirportAddress_id", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airport_address", x => x.AirportModelsAirportAddress_id);
                });

            migrationBuilder.CreateTable(
                name: "airport",
                columns: table => new
                {
                    AirportModelsAirportEntity_id = table.Column<long>(name: "Airport.Models.AirportEntity_id", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirportAddressId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airport", x => x.AirportModelsAirportEntity_id);
                    table.ForeignKey(
                        name: "FK_airport_airport_address_AirportAddressId",
                        column: x => x.AirportAddressId,
                        principalTable: "airport_address",
                        principalColumn: "Airport.Models.AirportAddress_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_airport_AirportAddressId",
                table: "airport",
                column: "AirportAddressId",
                unique: true);
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
