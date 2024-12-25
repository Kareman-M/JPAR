using JPAR.Infrastructure.Enums;
using JPAR.Service.DTOs;
using JPAR.Service.Models;
using Microsoft.AspNetCore.Identity;

namespace JPAR.Service.IServices
{
    public interface IUserService
    {
        Task<AuthenticatedUserModel> Login(UserLoginDTO userLogin);
        Task<IdentityResult> Register(UserRegistrationDTO userModel, UserType userType);
    }
}
