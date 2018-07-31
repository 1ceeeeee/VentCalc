using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentCalc.Persistence;

namespace VentCalc.Models
{
    [Table("Cities")]
    public class City : BaseEntity
    {
        // [Description("ИД города")]
        // public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string CityName { get; set; }
        public double TempOutWinter { get; set; }
        public double TempOutSummer { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }

    }
}