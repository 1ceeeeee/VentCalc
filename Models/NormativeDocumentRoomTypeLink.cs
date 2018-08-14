using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentCalc.Persistence;

namespace VentCalc.Models
{
    [Table("NormativeDocumentRoomTypeLinks")]
    [Description("Связи норм. документов и типов помещений")]
    public class NormativeDocumentRoomTypeLink : CrudBase
    {
        [Required]
        [Description("ИД нормативного документа")]
        public int NormativeDocumentId { get; set; }
        public NormativeDocument NormativeDocument { get; set; }
        [Required]
        [Description("ИД типа помещения")]
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
    }
}