using Microsoft.EntityFrameworkCore.Migrations;

namespace VentCalc.Migrations
{
    public partial class RoomTypeValueConditionInitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[RoomTypeValueConditions] ON");
            migrationBuilder.Sql("INSERT INTO [dbo].[RoomTypeValueConditions] ([Id], [RoomTypeValueConditionName]) VALUES (1, N'При общей площади квартиры на одного человека БОЛЕЕ 20 м2')");
            migrationBuilder.Sql("INSERT INTO [dbo].[RoomTypeValueConditions] ([Id], [RoomTypeValueConditionName]) VALUES (2, N'При общей площади квартиры на одного человека МЕНЕЕ 20 м2')");
            migrationBuilder.Sql("INSERT INTO [dbo].[RoomTypeValueConditions] ([Id], [RoomTypeValueConditionName]) VALUES (3, N'При установке газовой шахты воздухообмен следует увеличить на 100 м2/ч')");
            migrationBuilder.Sql("INSERT INTO [dbo].[RoomTypeValueConditions] ([Id], [RoomTypeValueConditionName]) VALUES (4, N'По расчету')");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[RoomTypeValueConditions] OFF");   
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[RoomTypeValueConditions] ON");
            migrationBuilder.Sql("DELETE FROM [dbo].[RoomTypeValueConditionName] WHERE [Id] = 1");
            migrationBuilder.Sql("DELETE FROM [dbo].[RoomTypeValueConditionName] WHERE [Id] = 2");
            migrationBuilder.Sql("DELETE FROM [dbo].[RoomTypeValueConditionName] WHERE [Id] = 3");
            migrationBuilder.Sql("DELETE FROM [dbo].[RoomTypeValueConditionName] WHERE [Id] = 4");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[RoomTypeValueConditions] OFF");   
        }
    }
}
