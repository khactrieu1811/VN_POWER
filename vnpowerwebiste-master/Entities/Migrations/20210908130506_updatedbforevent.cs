using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class updatedbforevent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Scholarships",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeEvent",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "Scholarships");

            migrationBuilder.DropColumn(
                name: "TimeEvent",
                table: "Posts");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
