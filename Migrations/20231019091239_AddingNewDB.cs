using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcurementProcess.Net6.Migrations
{
    public partial class AddingNewDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FinanceDirector",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LineManager",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagingDirector",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequesterName",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinanceDirector",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "LineManager",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ManagingDirector",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequesterName",
                table: "Requests");
        }
    }
}
