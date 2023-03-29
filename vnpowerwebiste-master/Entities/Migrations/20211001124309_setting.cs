using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class setting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PageImageUrl = table.Column<string>(nullable: true),
                    PageDescription = table.Column<string>(nullable: true),
                    PageTitle = table.Column<string>(nullable: true),
                    MetaDesc = table.Column<string>(nullable: true),
                    FacebookLink = table.Column<string>(nullable: true),
                    LinkedInLink = table.Column<string>(nullable: true),
                    YoutubeLink = table.Column<string>(nullable: true),
                    InstagramLink = table.Column<string>(nullable: true),
                    FacebookScript = table.Column<string>(nullable: true),
                    GoogleScript = table.Column<string>(nullable: true),
                    TermsAndConditions = table.Column<string>(nullable: true),
                    DefaultLanguage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            var sql = @$"Insert into Settings(Id, PageImageUrl,PageDescription, PageTitle, MetaDesc,FacebookLink,LinkedInLink,
                         YoutubeLink, InstagramLink, DefaultLanguage) 
                        values(newid(),'https://admin.tnrservices.co.uk/UploadFiles/Images/202110014bd55a6b-9c4b-4ee4-8879-7c937608dd7a_Image_720_480.png', 'One-stop education services for international students in the UK', 'TNR Services Ltd',
                         'education services,TNR Services ', 'https://www.facebook.com/tnrservices.admin', 'https://www.linkedin.com/company/76495789/admin/',
                         'https://www.youtube.com/results?search_query=TNR+Servics', 'https://l.facebook.com/l.php?u=https%3A%2F%2Finstagram.com%2Ftnr.services%3Futm_medium%3Dcopy_link%26fbclid%3DIwAR3anJKnBuV0hYIuO3W_plBApZ46hxiaLisrhEJixMJf0rnHVwCZDaG3W5Q&h=AT175hSwuXR2cIXCShK4_un3awM79Y9QRS6szM_gxOMpwgBV9QcrijPZtihW35MN_e96hS9ZZos5Nowaza_5yUwJm6lNveWXp6QHjBB0ZKHvNwR5TL0FbyB43rSx0ld2ZuVYpAfGgug',
                         'EN')";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
