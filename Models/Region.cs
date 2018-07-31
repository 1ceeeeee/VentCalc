using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentCalc.Persistence;

namespace VentCalc.Models
{
    [Table("Regions")]
    public class Region : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string RegionName { get; set; }
        public ICollection<City> Cities { get; set; }
        public Region()
        {
            Cities = new Collection<City>(); 
        }
    }
}