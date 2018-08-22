using Microsoft.EntityFrameworkCore.Migrations;

namespace Pickles.Data.Migrations
{
    public partial class AddPickleTypeSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PickleTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dill" },
                    { 2, "Sweet" },
                    { 3, "Bread and Butter" },
                    { 4, "Sour" },
                    { 5, "Other" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PickleTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PickleTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PickleTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PickleTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PickleTypes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
