using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VentCalc.Models;

namespace VentCalc.Controllers.Resources {
    public class SaveProjectResource : BaseM {
        // public int Id { get; set; }
        public string ProjectName { get; set; }
        public int? CityId { get; set; }
        public DateTime? CreateDate { get; set; } 
        // public ICollection<Room> Rooms { get; set; }
        // public string CreateUserId { get; set; }
        
        // public SaveProjectResource() {
        //     Rooms = new Collection<Room>();
        // }
    }
}