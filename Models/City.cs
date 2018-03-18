using System.ComponentModel;

namespace VentCalc.Models
{
    public class City
    {
        [Description("ИД города")]
        public int Id { get; set; }
        public string CityName { get; set; }
        public double TempOutWinter { get; set; }
        public double TempOutSummer { get; set; }
        public Region Region { get; set; }
        public int RegionId { get; set; }

    }
}