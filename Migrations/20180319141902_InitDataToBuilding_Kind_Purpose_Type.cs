using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VentCalc.Migrations
{
    public partial class InitDataToBuilding_Kind_Purpose_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Виды зданий
            migrationBuilder.Sql("INSERT INTO BuildingKinds (BuildingKindName) VALUES('Гражданские здания')");
            migrationBuilder.Sql("INSERT INTO BuildingKinds (BuildingKindName) VALUES('Промышленные здания')");
            migrationBuilder.Sql("INSERT INTO BuildingKinds (BuildingKindName) VALUES('Сельскохозяйственные здания')");

            //Назначения зданий
            migrationBuilder.Sql("INSERT INTO BuildingPurposes (BuildingKindId, BuildingPurposeName) VALUES((SELECT Id FROM BuildingKinds WHERE BuildingKindName = 'Гражданские здания'),'Жилые')");
            migrationBuilder.Sql("INSERT INTO BuildingPurposes (BuildingKindId, BuildingPurposeName) VALUES((SELECT Id FROM BuildingKinds WHERE BuildingKindName = 'Гражданские здания'),'Общественные')");
            
            migrationBuilder.Sql("INSERT INTO BuildingPurposes (BuildingKindId, BuildingPurposeName) VALUES((SELECT Id FROM BuildingKinds WHERE BuildingKindName = 'Промышленные здания'),'Производственные')");
            migrationBuilder.Sql("INSERT INTO BuildingPurposes (BuildingKindId, BuildingPurposeName) VALUES((SELECT Id FROM BuildingKinds WHERE BuildingKindName = 'Промышленные здания'),'Энергитическое хозяйство')");
            migrationBuilder.Sql("INSERT INTO BuildingPurposes (BuildingKindId, BuildingPurposeName) VALUES((SELECT Id FROM BuildingKinds WHERE BuildingKindName = 'Промышленные здания'),'Транспортно-складского хозяйства')");
            migrationBuilder.Sql("INSERT INTO BuildingPurposes (BuildingKindId, BuildingPurposeName) VALUES((SELECT Id FROM BuildingKinds WHERE BuildingKindName = 'Промышленные здания'),'Подсобные и вспомогательные')");

            migrationBuilder.Sql("INSERT INTO BuildingPurposes (BuildingKindId, BuildingPurposeName) VALUES((SELECT Id FROM BuildingKinds WHERE BuildingKindName = 'Сельскохозяйственные здания'),'Животноводческие')");
            migrationBuilder.Sql("INSERT INTO BuildingPurposes (BuildingKindId, BuildingPurposeName) VALUES((SELECT Id FROM BuildingKinds WHERE BuildingKindName = 'Сельскохозяйственные здания'),'Птицеводческие')");
            migrationBuilder.Sql("INSERT INTO BuildingPurposes (BuildingKindId, BuildingPurposeName) VALUES((SELECT Id FROM BuildingKinds WHERE BuildingKindName = 'Сельскохозяйственные здания'),'Культивационные')");
        
            //Типы зданий
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Жилые'),'Жилые дома')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Жилые'),'Общежития')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Жилые'),'Гостиницы')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Жилые'),'Дома отдыха')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Жилые'),'Интернаты')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Жилые'),'Дома для престарелых')");

            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Общественные'),'Учебные заведения (Школы, инстутиты)')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Общественные'),'Административные (Бизнес центы, офисы)')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Общественные'),'Здравохранения и отдыха')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Общественные'),'Спортивные (Физкультурно оздоровительные комплексы \"ФОК\", Стадионы и т.п)')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Общественные'),'Зрелищные (театры, кинотеатры и т.п)')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Общественные'),'Торговли, общественного питания и бытового обслуживания (Торговые центры, магазины, столовые и т.п)')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Общественные'),'Траспортные (Аэропорты, ЖД)')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Общественные'),'Коммунального хозяйства (Ремонт одежды и т.п)')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Общественные'),'Многофункциональныя здания и комплексы')");

            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Производственные'),'Производственные здания')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Производственные'),'Сборочные цеха заводов')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Производственные'),'Фабрики')");

            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Энергитическое хозяйство'),'Здания ТЭЦ')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Энергитическое хозяйство'),'Котельные')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Энергитическое хозяйство'),'Компрессорные')");

            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Транспортно-складского хозяйства'),'Склады')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Транспортно-складского хозяйства'),'Гаражи')");
            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Транспортно-складского хозяйства'),'Депо')");

            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Подсобные и вспомогательные'),'Административные, бытовые и т.п')");

            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Животноводческие'),'Разведения животных: свиней, коров, лошадей и т.п.')");

            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Птицеводческие'),'разведения птиц')");

            migrationBuilder.Sql("INSERT INTO BuildingTypes (BuildingPurposeId, BuildingTypeName) VALUES((SELECT Id FROM BuildingPurposes WHERE BuildingPurposeName = 'Культивационные'),'Выращивания овощей, цветов и т.п.')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM BuildingKinds WHERE BuildingKindName IN ('Гражданские здания', 'Промышленные здания', 'Сельскохозяйственные здания')");
        }   
    }
}
