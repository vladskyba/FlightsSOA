using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceRegistry.Migrations
{
    public partial class Host : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Host",
                table: "ServiceSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Host",
                table: "ServiceSettings");
        }
    }
}
