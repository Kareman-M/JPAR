using JPAR.Service.DTOs;
using JPAR.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace JPAR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("ApplicantRegister")]
        public async Task<IActionResult> RegisterAsync(ApplicantRegistrationDTO userDto)
        {
            return Ok(await _userService.Register(userDto, Infrastructure.Enums.UserType.Applicant));
        }

        [HttpPost("RecruiterRegister")]
        public async Task<IActionResult> RecruiterRegisterAsync(ApplicantRegistrationDTO userDto )
        {
            return Ok(await _userService.Register(userDto, Infrastructure.Enums.UserType.Recruiter));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(UserLoginDTO userLogin)
        {
            var result = await _userService.Login(userLogin);
            return result is not null ? Ok(result): BadRequest("Email Or Password Is Not Correct");
        }
    }
}