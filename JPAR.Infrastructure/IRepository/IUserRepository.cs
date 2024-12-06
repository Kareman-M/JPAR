using JPAR.Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;

namespace JPAR.Infrastructure.IRepository
{
    public interface IUserRepository
    {
        Task<IdentityResult> Register(User user,UserType userType);
    }
}
