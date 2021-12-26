using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgramlama.Migrations
{
    public partial class biletedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "Biletler");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KullaniciId",
                table: "Biletler",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
