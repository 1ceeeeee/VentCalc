using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VentCalc.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string RegionName { get; set; }
        public ICollection<City> Cities { get; set; }
        public Region()
        {
            Cities = new Collection<City>(); 
        }
    }
}