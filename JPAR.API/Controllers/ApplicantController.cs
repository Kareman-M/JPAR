using JPAR.Service.DTOs;
using JPAR.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace JPAR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpPut("UpdateGeneralInfo")]
        public IActionResult UpdateGeneralInfo(UpdateApplicantGeneralInfoDTO applicantGeneralInfo)
        {

            return Ok();
        }
    }
}
