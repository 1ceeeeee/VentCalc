using Microsoft.AspNetCore.Identity;
using VentCalc.Persistence;

namespace VentCalc.Models {
    public class PortalUser : BaseEntity {

        public string IdentityId { get; set; }
        public virtual AppUser Identity { get; set; }
    }
}