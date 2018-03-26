namespace VentCalc.Controllers.Resources
{
    public class RoomTypeResource
    {
        public int Id { get; set; }
        public string RoomTypeName { get; set; }
        public double TempIn { get; set; }        
        public double HumidityFrom { get; set; }   
        public double HumidityTo { get; set; }  
        public double HumidityRelative { get; set; } 
        public double Inflow { get; set; } 
        public double Exhaust { get; set; } 
        public string Unit { get; set; }
        public bool IsForPeople { get; set; }

    }
}