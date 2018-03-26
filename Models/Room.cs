using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace VentCalc.Models
{
    [Table("Rooms")]
    [Description("Помещения")]
    public class Room
    {
        [Required]
        [Description("ИД помещения")]
        public int Id { get; set; }
        [Required]
        [Description("ИД города")]
        public int CityId { get; set; }
        public City City { get; set; }
        [Required]
        [Description("ИД типа здания")]
        public int BuildingTypeId { get; set; }
        public BuildingType BuildingType { get; set; }
        [Required]
        [Description("ИД типа помещения")]
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        [Description("Номер помещения")]
        public int RoomNumber { get; set; }
        [Required]
        [StringLength(255)]
        [Description("Наименование")]
        public string RoomName { get; set; }
        [Description("Длина")]
        public double Length { get; set; }
        [Description("Ширина")]
        public double Width { get; set; }
        [Description("Площадь")]
        public double Area { get; set; }
        [Description("Высота")]
        public double Height { get; set; }
        [Description("Этаж")]
        public int Floor { get; set; }
        [Description("Кол-во людей")]
        public int PeopleAmount { get; set; }
        [Description("ИД пользователя")]
        public int UserId { get; set; }
       
    }

}