using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VentCalc.Migrations
{
    public partial class SeedRoomType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO RoomTypes(Exhaust,HumidityFrom,HumidityRelative,HumidityTo,Inflow,IsForPeople,RoomTypeName,TempIn,Unit) VALUES (11.2,10.3,14.8,15.9,18.3,20.1,'Тепловой пункт',25.6,'ед.')");
            migrationBuilder.Sql("INSERT INTO RoomTypes(Exhaust,HumidityFrom,HumidityRelative,HumidityTo,Inflow,IsForPeople,RoomTypeName,TempIn,Unit) VALUES (10.2,17.3,1.8,5.9,8.3,0.1,'Техническое помещение',2.6,'ед.')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Regions WHERE RoomTypeName IN ('Тепловой пункт', 'Техническое помещение')");
        }
    }
}
