using Microsoft.EntityFrameworkCore.Migrations;

namespace VentCalc.Migrations
{
    public partial class CrudBaseDeleteDateChangeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateDelete",
                table: "RoomTypeValues",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DateDelete",
                table: "RoomTypes",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DateDelete",
                table: "Rooms",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DateDelete",
                table: "Rights",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DateDelete",
                table: "Regions",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DateDelete",
                table: "Projects",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DateDelete",
                table: "NormativeDocumentTypes",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DateDelete",
                table: "NormativeDocuments",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DateDelete",
                table: "NormativeDocumentRoomTypeLinks",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DateDelete",
                table: "Cities",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DateDelete",
                table: "BuildingTypes",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DateDelete",
                table: "BuildingPurposes",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DateDelete",
                table: "BuildingKinds",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DateDelete",
                table: "AppUserRights",
                newName: "DeleteDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "RoomTypeValues",
                newName: "DateDelete");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "RoomTypes",
                newName: "DateDelete");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "Rooms",
                newName: "DateDelete");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "Rights",
                newName: "DateDelete");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "Regions",
                newName: "DateDelete");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "Projects",
                newName: "DateDelete");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "NormativeDocumentTypes",
                newName: "DateDelete");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "NormativeDocuments",
                newName: "DateDelete");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "NormativeDocumentRoomTypeLinks",
                newName: "DateDelete");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "Cities",
                newName: "DateDelete");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "BuildingTypes",
                newName: "DateDelete");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "BuildingPurposes",
                newName: "DateDelete");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "BuildingKinds",
                newName: "DateDelete");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "AppUserRights",
                newName: "DateDelete");
        }
    }
}
