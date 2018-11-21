using VentCalc.Models;

namespace VentCalc.Controllers.Resources
{
    public class RoomResource
    {
        public int RoomTypeId { get; set; }
        public int ProjectId { get; set; }
        public int? RoomNumber { get; set; }
        public string RoomName { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public double? Area { get; set; }
        public double? Height { get; set; }
        public int? Floor { get; set; }
        public int? PeopleAmount { get; set; }
        public double? Volume { get; set; }
        public double? InflowCalc { get; set; }
        public double? ExhaustCalc { get; set; }
        public string InflowSystem { get; set; }
        public string ExhaustSystem { get; set; }
    }
}