using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentCalc.Controllers.Resources;
using VentCalc.Persistence;

namespace VentCalc.Models {
    [Table("Projects")]
    [Description("Проекты")]
    public class Project : CrudBase {
        [Required]
        [StringLength(255)]
        [Description("Проект")]
        public string ProjectName { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public Project() {
            Rooms = new Collection<Room>();
        }
    }
}