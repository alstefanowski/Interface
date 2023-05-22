using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leap_Year.Data.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "LeapYear",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdAddress",
                table: "LeapYear",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "LeapYear");

            migrationBuilder.DropColumn(
                name: "IdAddress",
                table: "LeapYear");
        }
    }
}
