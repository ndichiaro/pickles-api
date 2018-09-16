using Microsoft.EntityFrameworkCore.Migrations;

namespace Pickles.Data.Migrations
{
    public partial class AddNoneTypeOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PickleTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "None" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PickleTypes",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
