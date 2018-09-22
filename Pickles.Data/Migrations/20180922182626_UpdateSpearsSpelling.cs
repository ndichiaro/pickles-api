using Microsoft.EntityFrameworkCore.Migrations;

namespace Pickles.Data.Migrations
{
    public partial class UpdateSpearsSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PickleStyles",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Spears");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PickleStyles",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Speats");
        }
    }
}
