using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightService.Migrations
{
    public partial class AirplaneReplications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "airplane",
                columns: table => new
                {
                    airplane_id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airplane", x => x.airplane_id);
                });

            migrationBuilder.CreateTable(
                name: "airplane_seat",
                columns: table => new
                {
                    airplane_seat_id = table.Column<long>(type: "bigint", nullable: false),
                    Line = table.Column<short>(type: "smallint", nullable: false),
                    Seat = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PlaneId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airplane_seat", x => x.airplane_seat_id);
                    table.ForeignKey(
                        name: "FK_airplane_seat_airplane_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "airplane",
                        principalColumn: "airplane_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_airplane_seat_PlaneId",
                table: "airplane_seat",
                column: "PlaneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "airplane_seat");

            migrationBuilder.DropTable(
                name: "airplane");
        }
    }
}
