using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VentCalc.Controllers.Resources
{
    public class SaveProjectResource
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }        
        public ICollection<RoomResource> Rooms { get; set; }
        public SaveProjectResource()
        {
            Rooms = new Collection<RoomResource>(); 
        }
    }
}