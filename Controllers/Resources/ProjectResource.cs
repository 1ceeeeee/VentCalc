using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VentCalc.Controllers.Resources
{
    public class ProjectResource
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }    
        public int? CityId { get; set; }   
        public DateTime? CreateDate { get; set; } 
        public string CreateUserId { get; set; }
    }
}