using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentCalc.Models
{
    [Table("NormativeDocumentTypes")]
    [Description("Типы нормативных документов")]
    public class NormativeDocumentType
    {
        [Required]
        [Description("ИД типа нормативного документа")]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Description("Тип нормативного документа")]        
        public string Name { get; set; }
        public ICollection<NormativeDocument> NormativeDocuments { get; set; }
        public NormativeDocumentType()
        {
            NormativeDocuments = new Collection<NormativeDocument>(); 
        }        
    }
}