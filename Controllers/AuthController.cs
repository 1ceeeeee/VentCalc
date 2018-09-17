using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using VentCalc.Auth;
using VentCalc.Controllers.Resources;
using VentCalc.Models;

namespace VentCalc.Controllers {
    [Route("api/[controller]")]
    public class AuthController : Controller {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly JwtIssuerOptions _jwtOptions;

        public AuthController(UserManager<AppUser> userManager, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions) {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;

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
            
            // Serialize and return the response
            // var response = new {
            //     id = identity.Claims.Single(c => c.Type == "id").Value,
            //     auth_token = await _jwtFactory.GenerateEncodedToken(credentials.UserName, identity),
            //     expires_in = (int) _jwtOptions.ValidFor.TotalSeconds
            // };

            // var json = JsonConvert.SerializeObject(response, _serializerSettings);          

            credentials.Auth_token = await _jwtFactory.GenerateEncodedToken(credentials.UserName, identity, _userManager);
            credentials.Expires_in = (int) _jwtOptions.ValidFor.TotalSeconds;
            credentials.Id = identity.Claims.Single(c => c.Type == "id").Value;            

            return Ok(credentials);
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password) {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password)) {
                // get the user to verifty
                var userToVerify = await _userManager.FindByNameAsync(userName);

                if (userToVerify != null) {
                    // check the credentials  
                    if (await _userManager.CheckPasswordAsync(userToVerify, password)) {
                        return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id));
                    }
                }
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }

    }
}