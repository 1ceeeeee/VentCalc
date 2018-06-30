using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentCalc.Models
{
    [Table("NormativeDocumentRoomTypeLinks")]
    [Description("Связи норм. документов и типов помещений")]
    public class NormativeDocumentRoomTypeLink
    {
        [Required]
        [Description("ИД связи норм. док. и типа помещения")]
        public int Id { get; set; }
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