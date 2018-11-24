using Microsoft.EntityFrameworkCore.Migrations;

namespace VentCalc.Migrations
{
    public partial class CityIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AddColumn<int>(
            //     name: "CityId",
            //     table: "Projects",
            //     nullable: true);

            // migrationBuilder.CreateIndex(
            //     name: "IX_Projects_CityId",
            //     table: "Projects",
            //     column: "CityId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Projects_Cities_CityId",
            //     table: "Projects",
            //     column: "CityId",
            //     principalTable: "Cities",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Projects_Cities_CityId",
            //     table: "Projects");

            // migrationBuilder.DropIndex(
            //     name: "IX_Projects_CityId",
            //     table: "Projects");

            // migrationBuilder.DropColumn(
            //     name: "CityId",
            //     table: "Projects");
        }
    }
}
