using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class updateSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyInfo",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyInfo",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Settings");
        }
    }
}
