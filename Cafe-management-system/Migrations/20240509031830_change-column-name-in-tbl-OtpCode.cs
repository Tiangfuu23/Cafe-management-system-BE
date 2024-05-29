using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cafe_management_system.Migrations
{
    public partial class changecolumnnameintblOtpCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "OtpCodes",
                newName: "Used");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Used",
                table: "OtpCodes",
                newName: "Active");
        }
    }
}
