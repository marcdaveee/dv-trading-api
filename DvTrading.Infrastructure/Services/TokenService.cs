using dv_trading_api.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace dv_trading_api.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public TokenService(IConfiguration configuration, UserManager<IdentityUser>userManager, RoleManager<IdentityRole> roleManager)
        {
            _config = configuration;
            _key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["JwtConfig:SigningKey"]));
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<string> GenerateToken(IdentityUser identityUser)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, identityUser.Email)                
            };

            var userRoles = await _userManager.GetRolesAsync(identityUser);

            foreach(var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            //var roleClaims = await _roleManager.GetClaimsAsync(identityUser);

            //foreach(var roleClaim in roleClaims)
            //{
            //    claims.Add(roleClaim);
            //}
            

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = creds,
                Issuer = _config["JwtConfig:Issuer"],
                Audience = _config["JwtConfig:Audience"],
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);

        }
    }
}
