using JPAR.Infrastructure.Context;
using JPAR.Infrastructure.Enums;
using JPAR.Infrastructure.IRepository;
using Microsoft.AspNetCore.Identity;

namespace JPAR.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDBContext _context;
        public UserRepository(UserManager<User> userManager, ApplicationDBContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IdentityResult> Register(User user, UserType userType)
        {
            try
            {
                var password = user.PasswordHash;
                user.PasswordHash = null;
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, userType.ToString());
                    //_context.UserRoles.Add(new IdentityUserRole<string>() { RoleId = userType.ToString(), UserId = user.Id });
                }
                await _context.SaveChangesAsync();

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
