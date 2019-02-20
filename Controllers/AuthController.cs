using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using VentCalc.Auth;
using VentCalc.Controllers.Resources;
using VentCalc.Models;
using VentCalc.Repositories;

namespace VentCalc.Controllers {
    [Route("api/[controller]")]
    public class AuthController : Controller {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(UserManager<AppUser> userManager, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions, IUnitOfWork uow, IHttpContextAccessor httpContextAccessor) {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
            _unitOfWork = uow;

            _serializerSettings = new JsonSerializerSettings {
                Formatting = Formatting.Indented
            };
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] CredentialsResource credentials) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var identity = await GetClaimsIdentity(credentials.UserName, credentials.Password);
            if (identity == null) {
                return BadRequest(("login_failure", "Не верное имя пользователя или пароль.", ModelState));
            }

            var authCredentials = new CredentialsResource();
            authCredentials.Auth_token = await _jwtFactory.GenerateEncodedToken(credentials.UserName, identity, _unitOfWork);
            authCredentials.Expires_in = (int) _jwtOptions.ValidFor.TotalSeconds;
            authCredentials.Id = identity.Claims.Single(c => c.Type == "id").Value;
            
            return Ok(new {
                auth_token = authCredentials.Auth_token,
                expires_in = authCredentials.Expires_in,
                userName = credentials.UserName,
                id = authCredentials.Id
            });
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string login, string password) {

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            var passwordHash = VentCalc.Models.User.GenerateMd5Hash(password);
            var userToVerify = await _unitOfWork.Repository<User>()
                .GetSingleIcludeMultipleAsync(x => x.Login == login &&
                    x.Password == passwordHash);

            if (userToVerify == null) 
                return await Task.FromResult<ClaimsIdentity>(null);

            if (CheckPasswordAsync(userToVerify, passwordHash)) 
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(login, userToVerify.Id.ToString()));            

            return await Task.FromResult<ClaimsIdentity>(null);

        }

        private bool CheckPasswordAsync(User user, string passwordHash) {
            return user.Password.Equals(passwordHash);
        }

    }
}