using JPAR.Infrastructure.Enums;
using JPAR.Infrastructure.IRepository;
using JPAR.Service.DTOs;
using JPAR.Service.IServices;
using JPAR.Service.IServices.IAuthentication;
using JPAR.Service.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace JPAR.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IApplicantRepository _applicantRepository;
        private readonly IRecruiterRepository _recruiterRepository;
        private readonly IAuthenticatorService _authenticator;
        private readonly UserManager<User> _userManager;


        public UserService(IUserRepository userRepository, IApplicantRepository applicantRepository, UserManager<User> userManager, IAuthenticatorService authenticator, IRecruiterRepository recruiterRepository)
        {
            _userRepository = userRepository;
            _applicantRepository = applicantRepository;
            _userManager = userManager;
            _authenticator = authenticator;
            _recruiterRepository = recruiterRepository;
        }

        public async Task<AuthenticatedUserModel> Login(UserLoginDTO userLogin)
        {
            var user = _userManager.FindByEmailAsync(userLogin.Email).Result;
            var isCorrectPassword = _userManager.CheckPasswordAsync(user, userLogin.Password).Result;
            if (!isCorrectPassword)
            {
                await _userManager.AccessFailedAsync(user);
                return null;
            }

            _ = _userManager.UpdateSecurityStampAsync(user).Result;

            _ = _userManager.ResetAccessFailedCountAsync(user).Result;

            if (user is not null)
            {
                var claims = new List<Claim> { new("role", (_userManager.GetRolesAsync(user))?.Result?.FirstOrDefault()) };
                AuthenticatedUserModel response = await _authenticator.Authenticate(user, claims);

                return response;
            }

            else return null;
        }

        public async Task<IdentityResult> ApplicantRegister(ApplicantRegistrationDTO userModel)
        {
            bool addApplicantResult;
            IdentityResult result;

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                UserName = Guid.NewGuid().ToString(),
                UserType = UserType.Applicant,
            };
            result = _userManager.CreateAsync(user, userModel.Password).Result;
            if (result.Succeeded)
            {
                 _ = _userManager.AddToRoleAsync(user, UserType.Applicant.ToString()).Result;
                 addApplicantResult = _applicantRepository.Add(user.Id);
            }
            return result;
        }

        public async Task<IdentityResult> RecruiterRegister(RecruiterRegistrationDTO userModel)
        {
            bool addrecruiterResult;
            IdentityResult result;

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                UserName = Guid.NewGuid().ToString(),
                UserType = UserType.Recruiter,
            };

            result = _userManager.CreateAsync(user, userModel.Password).Result;

            if (result.Succeeded)
            {
                _ =_userManager.AddToRoleAsync(user, UserType.Recruiter.ToString()).Result;
                addrecruiterResult = _recruiterRepository.Add(user.Id,userModel.CompanyName, userModel.JobTitle );
            }

            return result;
        }
    }
}