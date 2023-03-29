using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class createProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    MetaTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    PromotionPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Detail = table.Column<string>(nullable: true),
                    Warranty = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsLocked = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    IsHotPost = table.Column<bool>(nullable: false),
                    PromotionStartDate = table.Column<DateTime>(nullable: true),
                    PromotionEndDate = table.Column<DateTime>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    MetaKeyword = table.Column<string>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ApplicationUserId",
                table: "Products",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
