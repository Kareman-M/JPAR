using JPAR.Service.Models;
using System.Security.Claims;

namespace JPAR.Service.IServices.IAuthentication
{
    public interface IAuthenticatorService
    {
       Task<AuthenticatedUserModel> Authenticate(User user, List<Claim> claims);
    }
}
