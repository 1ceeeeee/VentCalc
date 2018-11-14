namespace VentCalc.Controllers.Resources
{
    public class AirExchangeRoomResource
    {
        public int Id { get; set; }
        public int? RoomNumber { get; set; }
        public string RoomName { get; set; }
        public double? TempIn { get; set; }  
        public double? Area { get; set; }
        public double? Volume { get; set; }
        public int? PeopleAmount { get; set; }
        public double? InflowMultiply { get; set; } 
        public double? ExhaustMultiply { get; set; } 
        public double? InflowCalc { get; set; } 
        public double? ExhaustCalc { get; set; } 
        public string InflowSystem { get; set; }
        public string ExhaustSystem { get; set; }
    }
}