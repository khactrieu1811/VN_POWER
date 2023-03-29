using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class DisplayOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Scholarships",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Scholarships");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Posts");
        }
    }
}
