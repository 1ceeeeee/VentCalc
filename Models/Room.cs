using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentCalc.Persistence;

namespace VentCalc.Models
{
    [Table("Rooms")]
    [Description("Помещения")]
    public class Room : CrudBase
    {     
        [Required]
        [Description("ИД типа помещения")]
        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }
        [Description("ИД проекта")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        [Description("Номер помещения")]
        public int? RoomNumber { get; set; }
        [Required]
        [StringLength(255)]
        [Description("Помещение")]
        public string RoomName { get; set; }
        [Description("Длина")]
        public double? Length { get; set; }
        [Description("Ширина")]
        public double? Width { get; set; }
        [Description("Площадь")]
        public double? Area { get; set; }
        [Description("Высота")]
        public double? Height { get; set; }
        [Description("Этаж")]
        public int? Floor { get; set; }
        [Description("Кол-во людей")]
        public int? PeopleAmount { get; set; }
        [Description("Объем")]
        public double? Volume { get; set; }
        [Description("Приток (расчёт)")]
        public double? InflowCalc { get; set; }
        [Description("ExhaustCalc")]
        public double? ExhaustCalc { get; set; }
        [StringLength(255)]
        [Description("Приточная система")]
        public string InflowSystem { get; set; }
        [StringLength(255)]
        [Description("Вытяжная система")]
        public string ExhaustSystem { get; set; }

        public Room(int createUserId): base(createUserId)
        {
            
        }

        public Room()
        {
            
        }
    }

}