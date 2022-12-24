using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceRegistry.Migrations
{
    public partial class AddMigrationStart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceSettings",
                columns: table => new
                {
                    Port = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service = table.Column<int>(type: "int", nullable: false),
                    Entered = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSettings", x => x.Port);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceSettings");
        }
    }
}
