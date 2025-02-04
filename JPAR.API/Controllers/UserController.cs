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
            return Ok(await _userService.ApplicantRegister(userDto));
        }

        
        [HttpPost("RecruiterRegister")]
        public async Task<IActionResult> RecruiterRegister(RecruiterRegistrationDTO userDto )
        {
            var result = await _userService.RecruiterRegister(userDto);
            return result.Succeeded?  Ok(result) : BadRequest();
        }

        
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(UserLoginDTO userLogin)
        {
            var result = await _userService.Login(userLogin);
            return result is not null ? Ok(result): BadRequest("Email Or Password Is Not Correct");
        }
    }
}