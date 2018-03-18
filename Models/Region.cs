using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VentCalc.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<City> Citys { get; set; }
        public Region()
        {
            Citys = new Collection<City>(); 
        }
    }
}