using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace VentCalc.Controllers.Resources
{
    public class PortalUserWithRolesResource
    {
        public string IdentityId { get; set; }

        public IList<string> AllRoles { get; set; }

        public IList<string> UserRoles { get; set; }
    }
}