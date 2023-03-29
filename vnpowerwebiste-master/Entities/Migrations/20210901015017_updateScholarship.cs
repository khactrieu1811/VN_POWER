using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class updateScholarship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HISCode",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AspNetNavigationMenu",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    NameEN = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionEN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScholarshipTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    NameEN = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionEN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScholarshipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scholarships",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsLocked = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    IsEnglish = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    PostType = table.Column<int>(nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    PostContent = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    ExternalLink = table.Column<string>(nullable: true),
                    ScholarshipTypeId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scholarships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scholarships_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scholarships_ScholarshipTypes_ScholarshipTypeId",
                        column: x => x.ScholarshipTypeId,
                        principalTable: "ScholarshipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scholarships_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScholarshipTags",
                columns: table => new
                {
                    ScholarshipId = table.Column<Guid>(nullable: false),
                    TagId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScholarshipTags", x => new { x.ScholarshipId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ScholarshipTags_Scholarships_ScholarshipId",
                        column: x => x.ScholarshipId,
                        principalTable: "Scholarships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScholarshipTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scholarships_RegionId",
                table: "Scholarships",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Scholarships_ScholarshipTypeId",
                table: "Scholarships",
                column: "ScholarshipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Scholarships_UserId",
                table: "Scholarships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipTags_TagId",
                table: "ScholarshipTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScholarshipTags");

            migrationBuilder.DropTable(
                name: "Scholarships");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "ScholarshipTypes");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AspNetNavigationMenu");

            migrationBuilder.AddColumn<string>(
                name: "HISCode",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }
    }
}
