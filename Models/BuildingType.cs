using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentCalc.Persistence;

namespace VentCalc.Models
{
    [Table("BuildingTypes")]
    [Description("Типы зданий")]
    public class BuildingType : CrudBase
    {
        [Required]
        [StringLength(255)]
        [Description("Тип здания")]
        public string BuildingTypeName { get; set; }
        [Required]
        [Description("ИД назначения здания")]
        public int BuildingPurposeId { get; set; }
        public virtual BuildingPurpose BuildingPurpose { get; set; }
        public ICollection<RoomType> RoomTypes { get; set; }
        public BuildingType()
        {
            RoomTypes = new Collection<RoomType>(); 
        }        
    }
}