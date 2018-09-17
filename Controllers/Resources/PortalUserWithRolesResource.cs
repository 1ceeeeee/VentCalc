using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using VentCalc.Models;

namespace VentCalc.Controllers.Resources {
    public class PortalUserWithRolesResource {
        public string IdentityId { get; set; }
        public IList<string> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public string FirsName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
    }
}