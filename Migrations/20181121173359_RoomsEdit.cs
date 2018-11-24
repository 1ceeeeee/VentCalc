using Microsoft.EntityFrameworkCore.Migrations;

namespace VentCalc.Migrations
{
    public partial class RoomsEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Rooms_Cities_CityId",
            //     table: "Rooms");

            // migrationBuilder.DropIndex(
            //     name: "IX_Rooms_CityId",
            //     table: "Rooms");

            // migrationBuilder.DropColumn(
            //     name: "CityId",
            //     table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rooms");

            migrationBuilder.AddColumn<double>(
                name: "ExhaustCalc",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "InflowCalc",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Volume",
                table: "Rooms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExhaustCalc",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "InflowCalc",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Rooms",
                nullable: true);

            // migrationBuilder.CreateIndex(
            //     name: "IX_Rooms_CityId",
            //     table: "Rooms",
            //     column: "CityId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Rooms_Cities_CityId",
            //     table: "Rooms",
            //     column: "CityId",
            //     principalTable: "Cities",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }
    }
}
