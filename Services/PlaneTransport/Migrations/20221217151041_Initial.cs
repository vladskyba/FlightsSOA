using Microsoft.EntityFrameworkCore.Migrations;

namespace PlaneTransport.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "plane",
                columns: table => new
                {
                    PlaneTransportModelsPlane_id = table.Column<long>(name: "PlaneTransport.Models.Plane_id", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaneType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plane", x => x.PlaneTransportModelsPlane_id);
                });

            migrationBuilder.CreateTable(
                name: "plane_seat",
                columns: table => new
                {
                    PlaneTransportModelsPlaneSeat_id = table.Column<long>(name: "PlaneTransport.Models.PlaneSeat_id", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Line = table.Column<short>(type: "smallint", nullable: false),
                    Seat = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PlaneId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plane_seat", x => x.PlaneTransportModelsPlaneSeat_id);
                    table.ForeignKey(
                        name: "FK_plane_seat_plane_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "plane",
                        principalColumn: "PlaneTransport.Models.Plane_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_plane_seat_PlaneId",
                table: "plane_seat",
                column: "PlaneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plane_seat");

            migrationBuilder.DropTable(
                name: "plane");
        }
    }
}
