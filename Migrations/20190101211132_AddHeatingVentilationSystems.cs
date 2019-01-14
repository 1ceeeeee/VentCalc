using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VentCalc.Migrations
{
    public partial class AddHeatingVentilationSystems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeatingVentilationSystems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUserId = table.Column<int>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    DeleteUsertId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    SystemName = table.Column<string>(maxLength: 255, nullable: true),
                    SystemAmount = table.Column<int>(nullable: true),
                    RoomName = table.Column<string>(maxLength: 4000, nullable: true),
                    InstallTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    FanTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    FanAirConsumption = table.Column<double>(nullable: true),
                    FanHead = table.Column<double>(nullable: true),
                    FanSpeed = table.Column<double>(nullable: true),
                    FanMotorTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    FanMotorPower = table.Column<double>(nullable: true),
                    FanMotorSpeed = table.Column<double>(nullable: true),
                    AirHeaterTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    AirHeaterAmount = table.Column<int>(nullable: true),
                    AirHeaterHeatingTempFrom = table.Column<double>(nullable: true),
                    AirHeaterHeatingTempTo = table.Column<double>(nullable: true),
                    AirHeaterPowerConsumption = table.Column<double>(nullable: true),
                    AirHeaterResistanceAir = table.Column<double>(nullable: true),
                    AirHeaterResistanceWater = table.Column<double>(nullable: true),
                    RecuperatorTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    RecuperatorAmount = table.Column<int>(nullable: true),
                    RecuperatorAirConsumptionHeating = table.Column<double>(nullable: true),
                    RecuperatorAirConsumptionHeated = table.Column<double>(nullable: true),
                    RecuperatorHeatingTempFrom = table.Column<double>(nullable: true),
                    RecuperatorHeatingTempTo = table.Column<double>(nullable: true),
                    RecuperatorPowerConsumption = table.Column<double>(nullable: true),
                    RecuperatorEfficiency = table.Column<double>(nullable: true),
                    RecuperatorResistanceHeating = table.Column<double>(nullable: true),
                    RecuperatorResistanceHeated = table.Column<double>(nullable: true),
                    FilterTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    FilterAmount = table.Column<int>(nullable: true),
                    FilterResistance = table.Column<double>(nullable: true),
                    AirCoolerTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    AirCoolerAmount = table.Column<int>(nullable: true),
                    AirCoolerCoolingTempFrom = table.Column<double>(nullable: true),
                    AirCoolerCoolingTempTo = table.Column<double>(nullable: true),
                    AirCoolerColdConsumption = table.Column<double>(nullable: true),
                    AirCoolerResistance = table.Column<double>(nullable: true),
                    Comment = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeatingVentilationSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeatingVentilationSystems_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeatingVentilationSystems_ProjectId",
                table: "HeatingVentilationSystems",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeatingVentilationSystems");
        }
    }
}
