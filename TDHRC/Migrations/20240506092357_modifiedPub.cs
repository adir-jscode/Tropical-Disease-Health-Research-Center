using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDHRC.Migrations
{
    public partial class modifiedPub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JournalLink",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JournalLink",
                table: "Publications");
        }
    }
}
