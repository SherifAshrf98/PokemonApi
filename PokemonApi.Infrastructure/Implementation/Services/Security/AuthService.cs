using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PokemonApi.Presentation.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PokemonApi.Infrastructure.Implementation.Services.Security
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(IdentityUser user)
        {

            var jwtConfig = _configuration.GetSection("JwtConfig").Get<JwtConfig>();

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));

            var claims = new[] {

                new Claim(ClaimTypes.NameIdentifier,user.Id ),
                new Claim(ClaimTypes.Name,user.UserName ),
                new Claim(ClaimTypes.Email,user.Email )
            };

            var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer: jwtConfig.Issuer,
            audience: jwtConfig.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(jwtConfig.ExpirationInMinutes),
            signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
