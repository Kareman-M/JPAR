using JPAR.Service.DTOs;
using JPAR.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JPAR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantJobController : ControllerBase
    {
        private readonly IApplicantJobService _jobService;

        public ApplicantJobController(IApplicantJobService jobService)
        {
            _jobService = jobService;
        }

        
        [Authorize(Roles = "Applicant"), HttpPost("Applay/{jobId}")]
        public IActionResult Applay(int jobId)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            return _jobService.Applay(jobId, userId) ? Ok(true): BadRequest();
        }

        
        [Authorize(Roles = "Applicant"), HttpGet("GetByApplicantId")]
        public IActionResult GetByApplicantId()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            return Ok(_jobService.GetByApplicantId(userId));
        }

        
        [Authorize(Roles = "Recruiter"), HttpPut("UpdateApplicantStatus")]
        public IActionResult UpdateApplicantStatus(UpdateApplicationStatusDTO updateStatus)
        {
            return Ok(_jobService.UpdateStatus(updateStatus));
        }

        
        [Authorize(Roles = "Recruiter"), HttpGet("GetByJobId/{jobId}")]
        public IActionResult GetByJobId(int jobId)
        {
            return Ok(_jobService.GetApplicationsByJobId(jobId));
        }

        [Authorize(Roles = "Recruiter"), HttpGet("GetApplicantDataById/{applicantId}")]
        public IActionResult GetApplicantDataById(int applicantId)
        {
            ApplicantDTO applicant= _jobService.GetApplicantDataById(applicantId);
            return Ok(applicant);
        }
    }
}
