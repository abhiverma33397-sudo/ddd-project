using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services.TokenServices
{
    public class TokenGenerate : ITokenGenerate
    {
        private readonly IConfiguration _configuration;
        public TokenGenerate(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string role, int userId)
        {
            var key = _configuration["JWTSettings:SecretKey"];
            var issuer = _configuration["JWTSettings:Issuer"];
            var audience = _configuration["JWTSettings:Audience"];

            var secretKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key));

            var claims = new[]
            {
                new Claim(ClaimTypes.Role, role),

              //new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
              new Claim("UserId", userId.ToString())

            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: new SigningCredentials(
                    secretKey,
                    SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
