using Microsoft.EntityFrameworkCore.Migrations;

namespace Pickles.Data.Migrations
{
    public partial class UpdateVoterColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Voters",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "Latitute",
                table: "Voters",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Voters",
                type: "int(5)",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Voters");

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Voters",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitute",
                table: "Voters",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
