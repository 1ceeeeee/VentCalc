namespace VentCalc.Controllers.Resources
{
    public class RoomTypeResource
    {
        public int Id { get; set; }
        public string RoomTypeName { get; set; }        
        public int BuildingTypeId { get; set; }
        public string RoomTypeBuildingTypeName { get; set; }

    }
}