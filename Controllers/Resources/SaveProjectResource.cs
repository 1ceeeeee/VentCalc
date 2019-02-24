using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VentCalc.Models;

namespace VentCalc.Controllers.Resources {
    public class SaveProjectResource : BaseM {        
        public string ProjectName { get; set; }
        public int? CityId { get; set; }       
    }
}