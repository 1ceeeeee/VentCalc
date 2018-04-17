using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VentCalc.Controllers.Resources
{
    public class AirExchangeProjectResource
    {
        public int Id { get; set; }
        public double? InflowTotal { get; set; } 
        public double? ExhaustTotal { get; set; } 
        public List<AirExchangeRoomResource> AirExchangeRooms { get; set; }
        public AirExchangeProjectResource()
        {
            AirExchangeRooms = new List<AirExchangeRoomResource>(); 
        }
    }
}