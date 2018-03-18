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
        [Description("Тип здания")]
        [StringLength(255)]
        public string BuildingTypeName { get; set; }
        public BuildingPurpose BuildingPurpose { get; set; }
        [Required]
        [Description("ИД назначения здания")]
        public int BuildingPurposeId { get; set; }
    }
}