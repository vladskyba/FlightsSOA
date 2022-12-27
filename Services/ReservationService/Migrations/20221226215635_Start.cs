using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationService.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "airport_address",
                columns: table => new
                {
                    airport_address_id = table.Column<long>(type: "bigint", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    airport_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "flight",
                columns: table => new
                {
                    flight_id = table.Column<long>(type: "bigint", nullable: false),
                    departure_airport_id = table.Column<long>(type: "bigint", nullable: false),
                    ArrivalAirportId = table.Column<long>(type: "bigint", nullable: false),
                    departure_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    arrival_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    airplane_id = table.Column<long>(type: "bigint", nullable: false),
                    cost = table.Column<decimal>(type: "decimal", nullable: false)
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
                        column: x => x.departure_airport_id,
                        principalTable: "airport",
                        principalColumn: "airport_id");
                });

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    reservation_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reservation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => x.reservation_id);
                    table.ForeignKey(
                        name: "FK_reservation_flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "flight",
                        principalColumn: "flight_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    reservation_ticket_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document_identifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    person_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    person_surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    person_last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    person_birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Seat = table.Column<short>(type: "smallint", nullable: false),
                    Line = table.Column<short>(type: "smallint", nullable: false),
                    ReservationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x.reservation_ticket_id);
                    table.ForeignKey(
                        name: "fk_reservation_id",
                        column: x => x.ReservationId,
                        principalTable: "reservation",
                        principalColumn: "reservation_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_airport_airport_address_id",
                table: "airport",
                column: "airport_address_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_flight_ArrivalAirportId",
                table: "flight",
                column: "ArrivalAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_flight_departure_airport_id",
                table: "flight",
                column: "departure_airport_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_FlightId",
                table: "reservation",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_ReservationId",
                table: "ticket",
                column: "ReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ticket");

            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "flight");

            migrationBuilder.DropTable(
                name: "airport");

            migrationBuilder.DropTable(
                name: "airport_address");
        }
    }
}
