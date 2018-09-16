using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pickles.Data.Migrations
{
    public partial class AddPickleStyle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PickleStyleId",
                table: "Votes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PickleStyles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickleStyles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_PickleStyleId",
                table: "Votes",
                column: "PickleStyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_PickleStyles_PickleStyleId",
                table: "Votes",
                column: "PickleStyleId",
                principalTable: "PickleStyles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_PickleStyles_PickleStyleId",
                table: "Votes");

            migrationBuilder.DropTable(
                name: "PickleStyles");

            migrationBuilder.DropIndex(
                name: "IX_Votes_PickleStyleId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "PickleStyleId",
                table: "Votes");
        }
    }
}
