using JPAR.Infrastructure.Enums;
using JPAR.Service.DTOs;
using JPAR.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace JPAR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobPostService;

        public JobController(IJobService jobPostService)
        {
            _jobPostService = jobPostService;
        }

        [HttpPost("Add")]
        public IActionResult Add(AddJobDTO addJobPostDTO)
        {
            var userId = "";
            return Ok(_jobPostService.Add(addJobPostDTO, userId));
        }

        [HttpPut("ChangeStstus")]
        public IActionResult ChangeStstus(int jobPostId, JobStatus jobPostStatus)
        {
            return Ok(_jobPostService.ChangeStatus(jobPostId, jobPostStatus));
        }

        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId()
        {
            var userId = "";
            return Ok(_jobPostService.GetByUserId(userId));
        } 

        [HttpPost("GetApplicantJobs")]
        public IActionResult GetApplicantJobs(ApplicantJobFilterDTO filter)
        {
            var userId = "";
            return Ok(_jobPostService.GetApplicantMatchedJobs(filter, userId));
        }

        
    }
}