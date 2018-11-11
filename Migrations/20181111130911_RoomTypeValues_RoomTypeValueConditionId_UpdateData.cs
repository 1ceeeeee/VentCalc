using Microsoft.EntityFrameworkCore.Migrations;

namespace VentCalc.Migrations
{
    public partial class RoomTypeValues_RoomTypeValueConditionId_UpdateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE [dbo].[RoomTypeValues] SET [RoomTypeValueConditionId] = 1 WHERE [Id] = 6	");
            migrationBuilder.Sql("UPDATE [dbo].[RoomTypeValues] SET [RoomTypeValueConditionId] = 1 WHERE [Id] = 8	");
            migrationBuilder.Sql("UPDATE [dbo].[RoomTypeValues] SET [RoomTypeValueConditionId] = 1 WHERE [Id] = 15	");
            migrationBuilder.Sql("UPDATE [dbo].[RoomTypeValues] SET [RoomTypeValueConditionId] = 1 WHERE [Id] = 21	");
            migrationBuilder.Sql("UPDATE [dbo].[RoomTypeValues] SET [RoomTypeValueConditionId] = 2 WHERE [Id] = 5	");
            migrationBuilder.Sql("UPDATE [dbo].[RoomTypeValues] SET [RoomTypeValueConditionId] = 2 WHERE [Id] = 7	");
            migrationBuilder.Sql("UPDATE [dbo].[RoomTypeValues] SET [RoomTypeValueConditionId] = 2 WHERE [Id] = 14	");
            migrationBuilder.Sql("UPDATE [dbo].[RoomTypeValues] SET [RoomTypeValueConditionId] = 2 WHERE [Id] = 20	");
            migrationBuilder.Sql("UPDATE [dbo].[RoomTypeValues] SET [RoomTypeValueConditionId] = 3 WHERE [Id] = 17	");
            migrationBuilder.Sql("UPDATE [dbo].[RoomTypeValues] SET [RoomTypeValueConditionId] = 3 WHERE [Id] = 18	");
            migrationBuilder.Sql("UPDATE [dbo].[RoomTypeValues] SET [RoomTypeValueConditionId] = 6 WHERE [Id] = 12	");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
