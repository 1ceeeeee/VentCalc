using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VentCalc.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Regions (RegionName) VALUES('Москва')");
            migrationBuilder.Sql("INSERT INTO Regions (RegionName) VALUES('Ленинградская область')");

            migrationBuilder.Sql("INSERT INTO Cities (CityName, RegionId, TempOutSummer, TempOutWinter) VALUES('Москва',(SELECT Id FROM Regions WHERE RegionName = 'Москва'), 22.6, -28)");

            migrationBuilder.Sql("INSERT INTO Cities (CityName, RegionId, TempOutSummer, TempOutWinter) VALUES('Санкт-Петербург',(SELECT Id FROM Regions WHERE RegionName = 'Ленинградская область'), 20.5, -30)");
            migrationBuilder.Sql("INSERT INTO Cities (CityName, RegionId, TempOutSummer, TempOutWinter) VALUES('Выборг',(SELECT Id FROM Regions WHERE RegionName = 'Ленинградская область'), 21.2, -29)");     
            migrationBuilder.Sql("INSERT INTO Cities (CityName, RegionId, TempOutSummer, TempOutWinter) VALUES('Кировск',(SELECT Id FROM Regions WHERE RegionName = 'Ленинградская область'), 19.8, -30)");       
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Regions WHERE RegionName IN ('Москва', 'Ленинградская область')");
        }
    }
}
