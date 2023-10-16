using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcurementProcess.Net6.Migrations
{
    public partial class UpdatedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VendorName",
                table: "Vendors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DepartmentName",
                table: "Departments",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Vendors");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Vendors",
                newName: "VendorName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Departments",
                newName: "DepartmentName");
        }
    }
}
