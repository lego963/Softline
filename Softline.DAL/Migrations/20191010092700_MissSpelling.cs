using Microsoft.EntityFrameworkCore.Migrations;

namespace Softline.DAL.Migrations
{
    public partial class MissSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReuestAction",
                table: "Requests");

            migrationBuilder.AddColumn<string>(
                name: "RequestAction",
                table: "Requests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestAction",
                table: "Requests");

            migrationBuilder.AddColumn<string>(
                name: "ReuestAction",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
