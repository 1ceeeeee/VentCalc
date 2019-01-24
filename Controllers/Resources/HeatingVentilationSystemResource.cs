using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VentCalc.Models;

namespace VentCalc.Controllers.Resources
{
    public class HeatingVentilationSystemResource
    {
        public int Id { get; set; }

        [Required]
        [Description("ИД проекта")]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        [StringLength(255)]
        [Description("Система")]
        public string SystemName { get; set; }

        [Description("Количество систем")]
        public int? SystemAmount { get; set; }

        [StringLength(4000)]
        [Description("Наименование обслуживаемого помещения")]
        public string RoomName { get; set; }

        [StringLength(512)]
        [Description("Тип установки")]
        public string InstallTypeName { get; set; }

        [StringLength(512)]
        [Description("Вентилятор. Тип исполнения")]
        public string FanTypeName { get; set; }

        [Description("Вентилятор. Расход воздуха, м3/ч")]
        public double? FanAirConsumption { get; set; }

        [Description("Вентилятор. Напор, Па")]
        public double? FanHead { get; set; }

        [Description("Вентилятор. Скорость, об/мин")]
        public double? FanSpeed { get; set; }

        [StringLength(512)]
        [Description("Вентилятор. Электродвигатель. Тип")]
        public string FanMotorTypeName { get; set; }

        [Description("Вентилятор. Электродвигатель. Мощность, кВт")]
        public double? FanMotorPower { get; set; }
        
        [Description("Вентилятор. Электродвигатель. Скорость, об/мин")]
        public double? FanMotorSpeed { get; set; }

        [StringLength(512)]
        [Description("Воздухонагреватель. Тип")]
        public string AirHeaterTypeName { get; set; }

        [Description("Воздухонагреватель. Количество")]
        public int? AirHeaterAmount { get; set; }

        [Description("Воздухонагреватель. Температура нагрева, C. От")]
        public double? AirHeaterHeatingTempFrom { get; set; }

        [Description("Воздухонагреватель. Температура нагрева, C. До")]
        public double? AirHeaterHeatingTempTo { get; set; }

        [Description("Воздухонагреватель. Расход теплоты, кВт")]
        public double? AirHeaterPowerConsumption { get; set; }

        [Description("Воздухонагреватель. Сопротивление, Па. По воздуху")]
        public double? AirHeaterResistanceAir { get; set; }

        [Description("Воздухонагреватель. Сопротивление, Па. По воде")]
        public double? AirHeaterResistanceWater { get; set; }

        [StringLength(512)]
        [Description("Рекуператор. Тип")]
        public string RecuperatorTypeName { get; set; }

        [Description("Рекуператор. Количество")]
        public int? RecuperatorAmount { get; set; }

        [Description("Рекуператор. Расход воздуха, м3/ч. Греющий")]
        public double? RecuperatorAirConsumptionHeating { get; set; }

        [Description("Рекуператор. Расход воздуха, м3/ч. Нагреваемый")]
        public double? RecuperatorAirConsumptionHeated { get; set; }

        [Description("Рекуператор. Температура нагрева, C. От")]
        public double? RecuperatorHeatingTempFrom { get; set; }

        [Description("Рекуператор. Температура нагрева, C. До")]
        public double? RecuperatorHeatingTempTo { get; set; }

        [Description("Рекуператор. Расход теплоты, кВт")]
        public double? RecuperatorPowerConsumption { get; set; }

        [Description("Рекуператор. КПД, %")]
        public double? RecuperatorEfficiency { get; set; }

        [Description("Воздухонагреватель. Сопротивление, Па. Греющий")]
        public double? RecuperatorResistanceHeating { get; set; }

        [Description("Воздухонагреватель. Сопротивление, Па. Нагреваемый")]
        public double? RecuperatorResistanceHeated { get; set; }

        [StringLength(512)]
        [Description("Фильтр. Тип")]
        public string FilterTypeName { get; set; }

        [Description("Фильтр. Количество")]
        public int? FilterAmount { get; set; }

        [Description("Фильтр. Сопротивление, Па")]
        public double? FilterResistance { get; set; }

        [StringLength(512)]
        [Description("Воздухоохладитель. Тип")]
        public string AirCoolerTypeName { get; set; }

        [Description("Воздухоохладитель. Количество")]
        public int? AirCoolerAmount { get; set; }

        [Description("Воздухоохладитель. Температура охлаждения, C. От")]
        public double? AirCoolerCoolingTempFrom { get; set; }

        [Description("Воздухоохладитель. Температура охлаждения, C. До")]
        public double? AirCoolerCoolingTempTo { get; set; }

        [Description("Воздухоохладитель. Расход холода, кВт")]
        public double? AirCoolerColdConsumption { get; set; }

        [Description("Воздухоохладитель. Сопротивление, Па")]
        public double? AirCoolerResistance { get; set; }
        
        [StringLength(1000)]
        [Description("Примечания")]
        public string Comment { get; set; }
    }
}