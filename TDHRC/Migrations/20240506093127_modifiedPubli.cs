using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDHRC.Migrations
{
    public partial class modifiedPubli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Publications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
