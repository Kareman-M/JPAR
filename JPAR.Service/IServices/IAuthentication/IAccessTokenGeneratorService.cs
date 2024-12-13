using JPAR.Service.Models;
using System.Security.Claims;

namespace JPAR.Service.IServices.IAuthentication
{
    public interface IAccessTokenGeneratorService
    {
        AccessTokenModel GenerateToken(User user, List<Claim> permissionsClaims);

    }
}
