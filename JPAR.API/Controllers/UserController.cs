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

        [HttpPost("Register")]
        public IActionResult Register(UserRegistrationDTO userDto)
        {
            return Ok(_userService.Register(userDto));
        }


        [HttpPost("Login")]
        public IActionResult Login(UserLoginDTO userLogin)
        {
            var result = _userService.Login(userLogin);
            return result is not null ? Ok(result): BadRequest("Email Or Password Is Not Correct");
        }
    }
}
