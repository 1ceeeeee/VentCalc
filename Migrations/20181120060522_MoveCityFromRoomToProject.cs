using Microsoft.EntityFrameworkCore.Migrations;

namespace VentCalc.Migrations
{
    public partial class MoveCityFromRoomToProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM dbo.Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Cities_CityId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CityId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CityId",
                table: "Projects",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Cities_CityId",
                table: "Projects",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Cities_CityId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CityId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CityId",
                table: "Rooms",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Cities_CityId",
                table: "Rooms",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
