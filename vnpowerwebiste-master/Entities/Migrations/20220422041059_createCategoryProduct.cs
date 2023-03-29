using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class createCategoryProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsLocked = table.Column<bool>(nullable: false),
                    OrderDisplay = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    PageTitle = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    ExtendedDataString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryProducts_CategoryProducts_ParentId",
                        column: x => x.ParentId,
                        principalTable: "CategoryProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProducts_ParentId",
                table: "CategoryProducts",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProducts");
        }
    }
}
