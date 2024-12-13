using System.Security.Claims;

namespace JPAR.Service.IServices.IAuthentication
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(string secritKey, string issuer, string audience, DateTime expirationDate, IEnumerable<Claim> claims = null);
    }
}
