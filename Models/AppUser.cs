using Microsoft.AspNetCore.Identity;

namespace VentCalc.Models {
    public class AppUser : IdentityUser {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
    }
}