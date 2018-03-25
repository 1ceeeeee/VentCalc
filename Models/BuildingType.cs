using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentCalc.Models
{
    [Table("BuildingTypes")]
    [Description("Типы зданий")]
    public class BuildingType
    {
        [Required]
        [Description("ИД типа здания")]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Description("Тип здания")]
        public string BuildingTypeName { get; set; }
        public BuildingPurpose BuildingPurpose { get; set; }
        [Required]
        [Description("ИД назначения здания")]
        public int BuildingPurposeId { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public BuildingType()
        {
            Rooms = new Collection<Room>(); 
        }        
    }
}