using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentCalc.Persistence;

namespace VentCalc.Models
{
    [Table("NormativeDocuments")]
    [Description("Нормативные документы")]
    public class NormativeDocument : CrudBase
    {
        [Required]
        [Description("ИД типа нормативного документа")]
        public int NormativeDocumentTypeId { get; set; }
        public NormativeDocumentType NormativeDocumentTypes { get; set; }
        [Required]
        [StringLength(1000)]
        [Description("Нормативный документ")]
        public string NormativeDocumentName { get; set; }
    }
}