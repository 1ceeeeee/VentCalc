using System.Collections.Generic;
using VentCalc.Persistence;

namespace VentCalc.Models
{
    public class AppUserRights : CrudBase
    {
        public int AppUserId { get; set; }
        public AppUser AppUsers { get; set; }
        public int RightId { get; set; }
        public Rights Rights { get; set; }

    }
}