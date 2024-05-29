using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cafe_management_system.Migrations
{
    public partial class addcolumnactiveintblotpCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "OtpCodes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "OtpCodes");
        }
    }
}
