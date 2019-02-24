using System;

namespace VentCalc.Controllers.Resources
{
    public class ProjectResource : BaseM
    {        
        public string ProjectName { get; set; }    
        public int? CityId { get; set; }                  
    }
}