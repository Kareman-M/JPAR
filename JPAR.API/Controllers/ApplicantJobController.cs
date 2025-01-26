using JPAR.Service.DTOs;
using JPAR.Service.IServices;
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

        [HttpPost("Applay")]
        public IActionResult Applay(int jobId)
        {
            var userId = 0;
            return Ok(_jobService.Applay(jobId, userId));
        }

        [HttpGet("GetByApplicantId")]
        public IActionResult GetByApplicantId()
        {
            var applicantId = 0;
            return Ok(_jobService.GetByApplicantId(applicantId));
        }

        [HttpPut("UpdateApplicantStatus")]
        public IActionResult UpdateApplicantStatus(UpdateApplicationStatusDTO updateStatus)
        {
            return Ok(_jobService.UpdateStatus(updateStatus));
        }

        [HttpGet("GetByJobId/{jobId}")]
        public IActionResult GetByJobId(int jobId)
        {
            return Ok(_jobService.GetApplicationsByJobId(jobId));
        }
    }
}
