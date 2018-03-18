using System.Collections.Generic;
using System.Collections.ObjectModel;
using VentCalc.Models;

namespace VentCalc.Controllers.Resources
{
    public class RegionResource
    {
        public int Id { get; set; }
        public string RegionName { get; set; }
        public ICollection<CityResource> Cities { get; set; }
        public RegionResource()
        {
            Cities = new Collection<CityResource>(); 
        }
    }
}