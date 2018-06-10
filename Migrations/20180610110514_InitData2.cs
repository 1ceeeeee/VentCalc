using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VentCalc.Migrations
{
    public partial class InitData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[NormativeDocumentRoomTypeLinks] ON"); 
            migrationBuilder.Sql("INSERT [dbo].[NormativeDocumentRoomTypeLinks] ([Id], [NormativeDocumentId], [RoomTypeId]) VALUES (1, 12, 5)");
            migrationBuilder.Sql("INSERT [dbo].[NormativeDocumentRoomTypeLinks] ([Id], [NormativeDocumentId], [RoomTypeId]) VALUES (4, 12, 6)");
            migrationBuilder.Sql("INSERT [dbo].[NormativeDocumentRoomTypeLinks] ([Id], [NormativeDocumentId], [RoomTypeId]) VALUES (5, 12, 7)");
            migrationBuilder.Sql("INSERT [dbo].[NormativeDocumentRoomTypeLinks] ([Id], [NormativeDocumentId], [RoomTypeId]) VALUES (6, 12, 8)");
            migrationBuilder.Sql("INSERT [dbo].[NormativeDocumentRoomTypeLinks] ([Id], [NormativeDocumentId], [RoomTypeId]) VALUES (7, 12, 9)");
            migrationBuilder.Sql("INSERT [dbo].[NormativeDocumentRoomTypeLinks] ([Id], [NormativeDocumentId], [RoomTypeId]) VALUES (8, 12, 10)");
            migrationBuilder.Sql("INSERT [dbo].[NormativeDocumentRoomTypeLinks] ([Id], [NormativeDocumentId], [RoomTypeId]) VALUES (12, 12, 11)");
            migrationBuilder.Sql("INSERT [dbo].[NormativeDocumentRoomTypeLinks] ([Id], [NormativeDocumentId], [RoomTypeId]) VALUES (14, 12, 12)");
            migrationBuilder.Sql("INSERT [dbo].[NormativeDocumentRoomTypeLinks] ([Id], [NormativeDocumentId], [RoomTypeId]) VALUES (15, 12, 13)");
            migrationBuilder.Sql("INSERT [dbo].[NormativeDocumentRoomTypeLinks] ([Id], [NormativeDocumentId], [RoomTypeId]) VALUES (16, 12, 14)");
            migrationBuilder.Sql("INSERT [dbo].[NormativeDocumentRoomTypeLinks] ([Id], [NormativeDocumentId], [RoomTypeId]) VALUES (17, 12, 15)");
            migrationBuilder.Sql("INSERT [dbo].[NormativeDocumentRoomTypeLinks] ([Id], [NormativeDocumentId], [RoomTypeId]) VALUES (18, 12, 16)");
            migrationBuilder.Sql("INSERT [dbo].[NormativeDocumentRoomTypeLinks] ([Id], [NormativeDocumentId], [RoomTypeId]) VALUES (19, 12, 17)");
            migrationBuilder.Sql("INSERT [dbo].[NormativeDocumentRoomTypeLinks] ([Id], [NormativeDocumentId], [RoomTypeId]) VALUES (20, 12, 18)");
            migrationBuilder.Sql("INSERT [dbo].[NormativeDocumentRoomTypeLinks] ([Id], [NormativeDocumentId], [RoomTypeId]) VALUES (21, 12, 19)");
            migrationBuilder.Sql("INSERT [dbo].[NormativeDocumentRoomTypeLinks] ([Id], [NormativeDocumentId], [RoomTypeId]) VALUES (22, 12, 20)");
            migrationBuilder.Sql("INSERT [dbo].[NormativeDocumentRoomTypeLinks] ([Id], [NormativeDocumentId], [RoomTypeId]) VALUES (23, 12, 21)");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[NormativeDocumentRoomTypeLinks] OFF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
