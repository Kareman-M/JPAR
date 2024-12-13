using JPAR.Infrastructure.Enums;
using JPAR.Infrastructure.IRepository;
using JPAR.Service.DTOs;
using JPAR.Service.IServices;
using JPAR.Service.IServices.IAuthentication;
using JPAR.Service.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Transactions;

namespace JPAR.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IApplicantRepository _applicantRepository;
        private readonly IAuthenticatorService _authenticator;
        private readonly UserManager<User> _userManager;


        public UserService(IUserRepository userRepository, IApplicantRepository applicantRepository, UserManager<User> userManager, IAuthenticatorService authenticator)
        {
            _userRepository = userRepository;
            _applicantRepository = applicantRepository;
            _userManager = userManager;
            _authenticator = authenticator;
        }

        public async Task<AuthenticatedUserModel> Login(UserLoginDTO userLogin)
        {
            var user = await _userManager.FindByEmailAsync(userLogin.Email);
            var isCorrectPassword = await _userManager.CheckPasswordAsync(user, userLogin.Password);
            if (!isCorrectPassword)
            {
                await _userManager.AccessFailedAsync(user);
                return null; 
            }

            await _userManager.UpdateSecurityStampAsync(user);
            await _userManager.ResetAccessFailedCountAsync(user);
            
            if (user is not null)
            {
                var claims = new List<Claim>{ new("role", (await _userManager.GetRolesAsync(user)).FirstOrDefault())};
                AuthenticatedUserModel response = await _authenticator.Authenticate(user, claims);

                return response;
            }
            
            else return null;
        }

        public async Task<IdentityResult> Register(UserRegistrationDTO userModel)
        {
            bool addApplicantResult;
            IdentityResult result;

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName, 
                PasswordHash = userModel.Password
            };
            using (var scpoe = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                result =  await _userRepository.Register(user, userModel.UserType);
                if (userModel.UserType == UserType.Applicant)  addApplicantResult = _applicantRepository.Add(user.Id);
            }
            return result;
        }
    }
}
