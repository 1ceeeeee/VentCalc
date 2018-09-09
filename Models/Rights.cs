using System.Collections.Generic;
using VentCalc.Persistence;

namespace VentCalc.Models
{
    public class Rights : CrudBase
    {
        public string Name { get; set; }

        public IList<AppUserRights> Users { get; set; }
        
    }
}