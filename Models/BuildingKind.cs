using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentCalc.Models
{
    [Table("BuildingKinds")]
    [Description("Виды зданий")]
    public class BuildingKind
    {
        [Required]
        [Description("ИД вида здания")]
        public int Id { get; set; }
        [Required]
        [Description("Вид здания")]
        [StringLength(255)]
        public string BuildingKindName { get; set; }
        public ICollection<BuildingPurpose> BuildingPurposes { get; set; }
        public BuildingKind()
        {
            BuildingPurposes = new Collection<BuildingPurpose>(); 
        }
    }
}