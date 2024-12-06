using JPAR.Service.IServices.IAuthentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JPAR.Service.Services.Authentication
{
    public class TokenGeneratorService : ITokenGeneratorService
    {
        public string GenerateToken(string secritKey, string issuer, string audience, DateTime expirationDate, IEnumerable<Claim>? claims = null)
        {
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secritKey));
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new(issuer, audience, claims, DateTime.Now, expirationDate, signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
