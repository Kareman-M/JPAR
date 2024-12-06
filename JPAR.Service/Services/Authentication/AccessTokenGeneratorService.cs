using JPAR.Service.IServices.IAuthentication;
using JPAR.Service.Models;
using System.Security.Claims;

namespace JPAR.Service.Services.Authentication
{
    public class AccessTokenGeneratorService : IAccessTokenGeneratorService
    {
        private readonly JwtConfigurationModel _jwtConfiguration;
        private readonly ITokenGeneratorService _tokenGenerator;

        public AccessTokenGeneratorService(JwtConfigurationModel jwtConfiguration, ITokenGeneratorService tokenGenerator)
        {
            _jwtConfiguration = jwtConfiguration;
            _tokenGenerator = tokenGenerator;
        }

        public AccessTokenModel GenerateToken(User user, List<Claim> permissionsClaims)
        {
            List<Claim> claims = new()
        {
            new ("id", user.Id.ToString()),
            new (ClaimTypes.Email, user?.Email??""),
            new (ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
        };
            claims.AddRange(permissionsClaims);

            DateTime expirationTime = DateTime.Now.AddMinutes(_jwtConfiguration.AccessTokenExpirationDurationMinutes);
            string value = _tokenGenerator.GenerateToken(
                _jwtConfiguration.AccessTokenSecret,
                _jwtConfiguration.Issuer,
                _jwtConfiguration.Audience,
                expirationTime,
                claims);

            return new()
            {
                Value = value,
                ExpirationDate = expirationTime
            };
        }
    }
}
