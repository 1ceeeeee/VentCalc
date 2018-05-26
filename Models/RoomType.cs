using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentCalc.Models
{
    [Table("RoomTypes")]
    [Description("Помещения")]
    public class RoomType
    {
        [Required]
        [Description("ИД типа помещения")]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Description("Тип помещения")]
        public string RoomTypeName { get; set; }
        [Required]
        [Description("Температура внутреннего воздуха")]
        public double TempIn { get; set; }        
        [Required]
        [Description("Влажность от")]
        public double HumidityFrom { get; set; }   
        [Required]
        [Description("Влажность до")]
        public double HumidityTo { get; set; }  
        [Required]
        [Description("Относительная влажность")]
        public double HumidityRelative { get; set; } 
        [Description("Приток")]
        public double Inflow { get; set; } 
        [Description("Вытяжка")]
        public double Exhaust { get; set; } 
        [StringLength(255)]
        [Description("Тип помещения")]
        public string Unit { get; set; }
        [Description("Для людей")]
        public bool IsForPeople { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public RoomType()
        {
            Rooms = new Collection<Room>(); 
        }
        [Required]
        [Description("ИД типа здания")]
        public int BuildingTypeId { get; set; }
        public BuildingType BuildingType { get; set; }
    }
}