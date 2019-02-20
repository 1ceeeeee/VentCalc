using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VentCalc.Models;
using VentCalc.Repositories;

namespace VentCalc.Auth {
    public interface IJwtFactory {
        // Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        //Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity, UserManager<AppUser> userManager);
        Task<string> GenerateEncodedToken(string login, ClaimsIdentity identity, IUnitOfWork uow);
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
    }
}