using VentCalc.Persistence;
using System.Security.Cryptography;
using System.Text;
using System;

namespace VentCalc.Models {
    public class User : CrudBase {
        public User(int createUserId) : base(createUserId) { }

        public User() {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
        public string Password { get; protected set; }
        public string Email { get; set; }

        public string PasswordMd5Hash() {
            return GenerateMd5Hash(Password);
        }

        public static string GenerateMd5Hash(string password) {
            using(var md5 = MD5.Create()) {
                var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
                var passwordHash = BitConverter.ToString(hash);
                return passwordHash.Replace("-", "");
            }
        }

        public void SetPasswordHash(string password) {
            Password = GenerateMd5Hash(password);
        }
    }
}