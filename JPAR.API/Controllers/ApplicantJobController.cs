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

        
        [Authorize(Roles = "Applicant"), HttpPost("Applay")]
        public IActionResult Applay(int jobId)
        {
            var userId = 0;
            return Ok(_jobService.Applay(jobId, userId));
        }

        
        [Authorize(Roles = "Applicant"), HttpGet("GetByApplicantId")]
        public IActionResult GetByApplicantId()
        {
            var applicantId = 0;
            return Ok(_jobService.GetByApplicantId(applicantId));
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
    }
}
