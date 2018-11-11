using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentCalc.Persistence;

namespace VentCalc.Models
{
    [Table("RoomTypeValues")]
    [Description("Показатели типа помещения")]
    public class RoomTypeValue : CrudBase
    {
        [Required]
        [Description("ИД типа помещения")]
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }        
        [Description("Температура внутреннего воздуха")]
        public double? TempIn { get; set; }        
        [Description("Влажность от")]
        public double? HumidityFrom { get; set; }   
        [Description("Влажность до")]
        public double? HumidityTo { get; set; }  
        [Description("Относительная влажность")]
        public double? HumidityRelative { get; set; } 
        [Description("Приток")]
        public double? Inflow { get; set; } 
        [Description("Приток по жилой площади, м2")]
        public double? InflowArea { get; set; } 
        [Description("Приток по людям, м3/ч на 1 человека")]
        public double? InflowPeople { get; set; } 
        [Description("Приток по кратности, 1/ч")]
        public double? InflowMultiply { get; set; } 
        [Description("Вытяжка")]
        public double? Exhaust { get; set; } 
        [Description("Вытяжка по жилой площади, м2")]
        public double? ExhaustArea { get; set; } 
        [Description("Вытяжка по людям, м3/ч на 1 человека")]
        public double? ExhaustPeople { get; set; } 
        [Description("Вытяжка по кратности, 1/ч")]
        public double? ExhaustMultiply { get; set; } 
        [StringLength(255)]
        [Description("Примечание")]
        public string Comment { get; set; }
        [Description("ИД дополнительного условия")]
        public int RoomTypeValueConditionId { get; set; }
        //public RoomTypeValueCondition RoomTypeValueCondition { get; set; } 
    }
}