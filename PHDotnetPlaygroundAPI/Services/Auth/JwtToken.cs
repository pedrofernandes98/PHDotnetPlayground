using Microsoft.IdentityModel.Tokens;
using PHDotnetPlaygroundAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PHDotnetPlaygroundAPI.Services.Auth
{
    public class JwtToken : IJwtToken
    {
        private readonly IConfiguration Configuration;
        public JwtToken(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private byte[] GetKey() => Encoding.ASCII.GetBytes(Configuration.GetValue<string>("JwtToken:Key"));

        private string GetIssuer() => Configuration.GetValue<string>("JwtToken:Issuer");

        private int GetExpires() => Convert.ToInt32(Configuration.GetValue<string>("JwtToken:Expires"));

        public string GenerateToken(IAuthEntity authEntity)
        {
            var key = GetKey();
            var issuer = GetIssuer();
            var expires = GetExpires();

            var tokenHandler = new JwtSecurityTokenHandler();

            var appClaims = new Claim[]
            {
                new Claim(ClaimTypes.Name, authEntity.User),
                new Claim(ClaimTypes.Role, authEntity.Role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(appClaims),
                Expires = DateTime.UtcNow.AddHours(expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}