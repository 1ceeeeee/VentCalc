using Microsoft.EntityFrameworkCore.Migrations;

namespace VentCalc.Migrations
{
    public partial class AddRoomTempToRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "RoomTemp",
                table: "Rooms",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomTemp",
                table: "Rooms");
        }
    }
}
