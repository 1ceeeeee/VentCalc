using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentCalc.Persistence;

namespace VentCalc.Models
{
    [Table("RoomTypes")]
    [Description("Помещения")]
    public class RoomType : CrudBase
    {
        [Required]
        [Description("ИД типа здания")]
        public int BuildingTypeId { get; set; }
        public BuildingType BuildingType { get; set; }        
        [Required]
        [StringLength(255)]
        [Description("Тип помещения")]
        public string RoomTypeName { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<RoomTypeValue> RoomTypeValues { get; set; }
        public RoomType()
        {
            Rooms = new Collection<Room>(); 
            RoomTypeValues = new Collection<RoomTypeValue>(); 
        }
    }
}