using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using VentCalc.Models;
using VentCalc.Repositories;

namespace VentCalc.Auth {
    public class JwtFactory : IJwtFactory {

        private readonly JwtIssuerOptions _jwtOptions;

        private UserManager<AppUser> _userManager;

        public JwtFactory(IOptions<JwtIssuerOptions> jwtOptions) {
            _jwtOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_jwtOptions);            
        }

        public ClaimsIdentity GenerateClaimsIdentity(string userName, string id) {
            return new ClaimsIdentity(new GenericIdentity(userName, "Token"), new [] {
                new Claim("id", id),
                    new Claim("rol", "api_access")
            });
        }

        public async Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity, IUnitOfWork uow) {
            // var claims = new [] {
            //     new Claim(JwtRegisteredClaimNames.Sub, userName),
            //     new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
            //     new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
            //     identity.FindFirst("rol"),
            //     identity.FindFirst("id")
            // };
            //_userManager = userManager;
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                identity.FindFirst("rol"),
                identity.FindFirst("id")
            };

            var userId = identity.Claims.Single(c => c.Type == "id").Value;
            var user = await uow.Repository<User>().GetByIdAsync(Convert.ToInt32(userId)); //_userManager.FindByIdAsync(userId);

            // var roles = await _userManager.GetRolesAsync(user);
            // AddRolesToClaims(claims, roles);

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims.ToArray(),
                notBefore: _jwtOptions.NotBefore,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(600)), //_jwtOptions.Expiration,
                signingCredentials : _jwtOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        private void AddRolesToClaims(List<Claim> claims, IEnumerable<string> roles) {
            foreach (var role in roles) {
                var roleClaim = new Claim(ClaimTypes.Role, role);
                claims.Add(roleClaim);
            }
        }

        // private void AddRolesToClaims(Claim[] claims, IEnumerable<string> roles) {
        //     for (var i = 0; i <= claims.Length; i++) {
        //         var roleClaim = new Claim(ClaimTypes.Role, role);
        //         claims.Add(roleClaim);
        //     }
        //     foreach (var role in roles) {
        //         var roleClaim = new Claim(ClaimTypes.Role, role);
        //         claims.Add(roleClaim);
        //     }
        // }

        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private static long ToUnixEpochDate(DateTime date) =>(long) Math.Round((date.ToUniversalTime() -
                new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
            .TotalSeconds);

        private static void ThrowIfInvalidOptions(JwtIssuerOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero) {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }

            if (options.SigningCredentials == null) {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null) {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }
    }
}