using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentCalc.Persistence;

namespace VentCalc.Models
{
    [Table("BuildingPurposes")]
    [Description("Назначения зданий")]
    public class BuildingPurpose : BaseEntity
    {
        [Required]
        [Description("Назначение здания")]
        [StringLength(255)]
        public string BuildingPurposeName { get; set; }
        public BuildingKind BuildingKind { get; set; }
        [Required]
        [Description("ИД вида здания")]
        public int BuildingKindId { get; set; }
        public ICollection<BuildingType> BuildingTypes { get; set; }
        public BuildingPurpose()
        {
            BuildingTypes = new Collection<BuildingType>(); 
        }
    }
}