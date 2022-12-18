using Microsoft.EntityFrameworkCore.Migrations;

namespace Flight.Migrations
{
    public partial class NamingsUpdating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_airport_airport_address_AirportAddressId",
                table: "airport");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "airport_address");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "airport");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "flight",
                newName: "cost");

            migrationBuilder.RenameColumn(
                name: "DepartureTime",
                table: "flight",
                newName: "departure_time");

            migrationBuilder.RenameColumn(
                name: "DepartureAirportId",
                table: "flight",
                newName: "departure_airport_id");

            migrationBuilder.RenameColumn(
                name: "ArrivalTime",
                table: "flight",
                newName: "arrival_time");

            migrationBuilder.RenameColumn(
                name: "AirplaneId",
                table: "flight",
                newName: "airplane_id");

            migrationBuilder.RenameIndex(
                name: "IX_flight_DepartureAirportId",
                table: "flight",
                newName: "IX_flight_departure_airport_id");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "airport_address",
                newName: "zip");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "airport_address",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "airport_address",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "AirportId",
                table: "airport_address",
                newName: "airport_id");

            migrationBuilder.RenameColumn(
                name: "airportaddress_id",
                table: "airport_address",
                newName: "airport_address_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "airport",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "AirportAddressId",
                table: "airport",
                newName: "airport_address_id");

            migrationBuilder.RenameIndex(
                name: "IX_airport_AirportAddressId",
                table: "airport",
                newName: "IX_airport_airport_address_id");

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "airport",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_airport_airport_address_airport_address_id",
                table: "airport",
                column: "airport_address_id",
                principalTable: "airport_address",
                principalColumn: "airport_address_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_airport_airport_address_airport_address_id",
                table: "airport");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "airport");

            migrationBuilder.RenameColumn(
                name: "cost",
                table: "flight",
                newName: "Cost");

            migrationBuilder.RenameColumn(
                name: "departure_time",
                table: "flight",
                newName: "DepartureTime");

            migrationBuilder.RenameColumn(
                name: "departure_airport_id",
                table: "flight",
                newName: "DepartureAirportId");

            migrationBuilder.RenameColumn(
                name: "arrival_time",
                table: "flight",
                newName: "ArrivalTime");

            migrationBuilder.RenameColumn(
                name: "airplane_id",
                table: "flight",
                newName: "AirplaneId");

            migrationBuilder.RenameIndex(
                name: "IX_flight_departure_airport_id",
                table: "flight",
                newName: "IX_flight_DepartureAirportId");

            migrationBuilder.RenameColumn(
                name: "zip",
                table: "airport_address",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "airport_address",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "airport_address",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "airport_id",
                table: "airport_address",
                newName: "AirportId");

            migrationBuilder.RenameColumn(
                name: "airport_address_id",
                table: "airport_address",
                newName: "airportaddress_id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "airport",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "airport_address_id",
                table: "airport",
                newName: "AirportAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_airport_airport_address_id",
                table: "airport",
                newName: "IX_airport_AirportAddressId");

            migrationBuilder.AddColumn<long>(
                name: "ExternalId",
                table: "airport_address",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ExternalId",
                table: "airport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_airport_airport_address_AirportAddressId",
                table: "airport",
                column: "AirportAddressId",
                principalTable: "airport_address",
                principalColumn: "airportaddress_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
