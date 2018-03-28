using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VentCalc.Controllers.Resources
{
    public class ProjectResource
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }        
        public ICollection<RoomResource> Rooms { get; set; }
        public ProjectResource()
        {
            Rooms = new Collection<RoomResource>(); 
        }
    }
}