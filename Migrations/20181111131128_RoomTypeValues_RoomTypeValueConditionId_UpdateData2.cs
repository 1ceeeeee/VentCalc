using Microsoft.EntityFrameworkCore.Migrations;

namespace VentCalc.Migrations
{
    public partial class RoomTypeValues_RoomTypeValueConditionId_UpdateData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE [dbo].[RoomTypeValues] SET [RoomTypeValueConditionId] = 4 WHERE [Id] = 12	");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
