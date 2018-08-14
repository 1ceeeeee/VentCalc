using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VentCalc.Migrations
{
    public partial class CrudBaseAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "RoomTypeValues",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "RoomTypeValues",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelete",
                table: "RoomTypeValues",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteUsertId",
                table: "RoomTypeValues",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "RoomTypeValues",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "RoomTypeValues",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "RoomTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "RoomTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelete",
                table: "RoomTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteUsertId",
                table: "RoomTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "RoomTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "RoomTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Rooms",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelete",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteUsertId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExhaustSystem",
                table: "Rooms",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InflowSystem",
                table: "Rooms",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Regions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "Regions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelete",
                table: "Regions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteUsertId",
                table: "Regions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Regions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "Regions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Projects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelete",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteUsertId",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "NormativeDocumentTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "NormativeDocumentTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelete",
                table: "NormativeDocumentTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteUsertId",
                table: "NormativeDocumentTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "NormativeDocumentTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "NormativeDocumentTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "NormativeDocuments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "NormativeDocuments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelete",
                table: "NormativeDocuments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteUsertId",
                table: "NormativeDocuments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "NormativeDocuments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "NormativeDocuments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "NormativeDocumentRoomTypeLinks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "NormativeDocumentRoomTypeLinks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelete",
                table: "NormativeDocumentRoomTypeLinks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteUsertId",
                table: "NormativeDocumentRoomTypeLinks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "NormativeDocumentRoomTypeLinks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "NormativeDocumentRoomTypeLinks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Cities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "Cities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelete",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteUsertId",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "BuildingTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "BuildingTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelete",
                table: "BuildingTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteUsertId",
                table: "BuildingTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "BuildingTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "BuildingTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "BuildingPurposes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "BuildingPurposes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelete",
                table: "BuildingPurposes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteUsertId",
                table: "BuildingPurposes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "BuildingPurposes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "BuildingPurposes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "BuildingKinds",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "BuildingKinds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelete",
                table: "BuildingKinds",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteUsertId",
                table: "BuildingKinds",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "BuildingKinds",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "BuildingKinds",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "RoomTypeValues");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "RoomTypeValues");

            migrationBuilder.DropColumn(
                name: "DateDelete",
                table: "RoomTypeValues");

            migrationBuilder.DropColumn(
                name: "DeleteUsertId",
                table: "RoomTypeValues");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "RoomTypeValues");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "RoomTypeValues");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "DateDelete",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "DeleteUsertId",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DateDelete",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DeleteUsertId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ExhaustSystem",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "InflowSystem",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "DateDelete",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "DeleteUsertId",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DateDelete",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DeleteUsertId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "NormativeDocumentTypes");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "NormativeDocumentTypes");

            migrationBuilder.DropColumn(
                name: "DateDelete",
                table: "NormativeDocumentTypes");

            migrationBuilder.DropColumn(
                name: "DeleteUsertId",
                table: "NormativeDocumentTypes");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "NormativeDocumentTypes");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "NormativeDocumentTypes");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "NormativeDocuments");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "NormativeDocuments");

            migrationBuilder.DropColumn(
                name: "DateDelete",
                table: "NormativeDocuments");

            migrationBuilder.DropColumn(
                name: "DeleteUsertId",
                table: "NormativeDocuments");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "NormativeDocuments");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "NormativeDocuments");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "NormativeDocumentRoomTypeLinks");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "NormativeDocumentRoomTypeLinks");

            migrationBuilder.DropColumn(
                name: "DateDelete",
                table: "NormativeDocumentRoomTypeLinks");

            migrationBuilder.DropColumn(
                name: "DeleteUsertId",
                table: "NormativeDocumentRoomTypeLinks");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "NormativeDocumentRoomTypeLinks");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "NormativeDocumentRoomTypeLinks");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "DateDelete",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "DeleteUsertId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "BuildingTypes");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "BuildingTypes");

            migrationBuilder.DropColumn(
                name: "DateDelete",
                table: "BuildingTypes");

            migrationBuilder.DropColumn(
                name: "DeleteUsertId",
                table: "BuildingTypes");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "BuildingTypes");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "BuildingTypes");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "BuildingPurposes");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "BuildingPurposes");

            migrationBuilder.DropColumn(
                name: "DateDelete",
                table: "BuildingPurposes");

            migrationBuilder.DropColumn(
                name: "DeleteUsertId",
                table: "BuildingPurposes");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "BuildingPurposes");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "BuildingPurposes");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "BuildingKinds");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "BuildingKinds");

            migrationBuilder.DropColumn(
                name: "DateDelete",
                table: "BuildingKinds");

            migrationBuilder.DropColumn(
                name: "DeleteUsertId",
                table: "BuildingKinds");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "BuildingKinds");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "BuildingKinds");
        }
    }
}
