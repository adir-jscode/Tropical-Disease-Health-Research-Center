using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDHRC.Migrations
{
    public partial class PubTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Publications");
        }
    }
}
