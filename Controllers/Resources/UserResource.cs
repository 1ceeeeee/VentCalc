using System.ComponentModel.DataAnnotations;

namespace VentCalc.Controllers.Resources {
    public class UserResource : BaseM {
        [Required]
        [MinLength(3, ErrorMessage = "Неверный логин.")]
        public string Login { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Пароль неверный.")]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }        
        
    }
}