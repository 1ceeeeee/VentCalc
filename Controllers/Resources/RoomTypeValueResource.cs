namespace VentCalc.Controllers.Resources
{
    public class RoomTypeValueResource
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }     
        public double? TempIn { get; set; }        
        public double? HumidityFrom { get; set; }   
        public double? HumidityTo { get; set; }  
        public double? HumidityRelative { get; set; } 
        public double? Inflow { get; set; } 
        public double? InflowArea { get; set; } 
        public double? InflowPeople { get; set; } 
        public double? InflowMultiply { get; set; } 
        public double? Exhaust { get; set; } 
        public double? ExhaustArea { get; set; } 
        public double? ExhaustPeople { get; set; } 
        public double? ExhaustMultiply { get; set; } 
        public string Comment { get; set; }
    }
}