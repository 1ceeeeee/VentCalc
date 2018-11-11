using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentCalc.Persistence;

namespace VentCalc.Models
{
    [Table("RoomTypeValueConditions")]
    [Description("Дополнительное условие")]
    public class RoomTypeValueCondition : CrudBase
    {
        [Required]
        [StringLength(1000)]
        [Description("Дополнительное условие")]
        public string RoomTypeValueConditionName { get; set; }
        // public ICollection<RoomTypeValue> RoomTypeValues { get; set; }
        // public RoomTypeValueCondition()
        // {
        //     RoomTypeValues = new Collection<RoomTypeValue>(); 
        // }

    }
}