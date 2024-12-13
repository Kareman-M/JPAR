using JPAR.Service.IServices.IAuthentication;
using JPAR.Service.Models;

namespace JPAR.Service.Services.Authentication
{
    public class RefreshTokenGeneratorService : IRefreshTokenGeneratorService
    {
        private readonly JwtConfigurationModel _configuration;
        private readonly ITokenGeneratorService _tokenGenerator;

        public RefreshTokenGeneratorService(JwtConfigurationModel configuration, ITokenGeneratorService tokenGenerator)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
        }

        public string GenerateToken()
        {
            DateTime expirationTime = DateTime.UtcNow.AddMinutes(_configuration.RefreshTokenExpirationDurationMinutes);

            return _tokenGenerator.GenerateToken(
                _configuration.RefreshTokenSecret,
                _configuration.Issuer,
                _configuration.Audience,
                expirationTime);
        }
    }
}
