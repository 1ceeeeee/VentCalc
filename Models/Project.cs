using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentCalc.Models
{
    [Table("Projects")]
    [Description("Проекты")]
    public class Project
    {
        [Required]
        [Description("ИД проекта")]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Description("Проект")]
        public string ProjectName { get; set; }        
        public ICollection<Room> Rooms { get; set; }
        public Project()
        {
            Rooms = new Collection<Room>(); 
        }
    }
}