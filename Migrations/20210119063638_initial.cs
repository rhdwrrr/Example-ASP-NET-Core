using Microsoft.EntityFrameworkCore.Migrations;

namespace OrigamiEdu.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAllowedToPost",
                table: "kelas",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAllowedToPost",
                table: "kelas");
        }
    }
}
