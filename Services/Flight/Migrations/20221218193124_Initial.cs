using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flight.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "airport_address",
                columns: table => new
                {
                    airportaddress_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirportId = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airport_address", x => x.airportaddress_id);
                });

            migrationBuilder.CreateTable(
                name: "airport",
                columns: table => new
                {
                    airport_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirportAddressId = table.Column<long>(type: "bigint", nullable: false),
                    ExternalId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airport", x => x.airport_id);
                    table.ForeignKey(
                        name: "FK_airport_airport_address_AirportAddressId",
                        column: x => x.AirportAddressId,
                        principalTable: "airport_address",
                        principalColumn: "airportaddress_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "flight",
                columns: table => new
                {
                    flight_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureAirportId = table.Column<long>(type: "bigint", nullable: false),
                    ArrivalAirportId = table.Column<long>(type: "bigint", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AirplaneId = table.Column<long>(type: "bigint", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flight", x => x.flight_id);
                    table.ForeignKey(
                        name: "fk_arrival_airport",
                        column: x => x.ArrivalAirportId,
                        principalTable: "airport",
                        principalColumn: "airport_id");
                    table.ForeignKey(
                        name: "fk_departure_airport",
                        column: x => x.DepartureAirportId,
                        principalTable: "airport",
                        principalColumn: "airport_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_airport_AirportAddressId",
                table: "airport",
                column: "AirportAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_flight_ArrivalAirportId",
                table: "flight",
                column: "ArrivalAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_flight_DepartureAirportId",
                table: "flight",
                column: "DepartureAirportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "flight");

            migrationBuilder.DropTable(
                name: "airport");

            migrationBuilder.DropTable(
                name: "airport_address");
        }
    }
}
