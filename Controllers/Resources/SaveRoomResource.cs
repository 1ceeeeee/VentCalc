namespace VentCalc.Controllers.Resources
{
    public class SaveRoomResource
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int BuildingTypeId { get; set; }
        public int RoomTypeId { get; set; }
        public int? RoomNumber { get; set; }
        public string RoomName { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public double? Area { get; set; }
        public double? Height { get; set; }
        public int? Floor { get; set; }
        public int? PeopleAmount { get; set; }
        public int? UserId { get; set; }
        public int ProjectId { get; set; }

    }
}