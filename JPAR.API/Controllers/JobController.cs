using JPAR.Infrastructure.Enums;
using JPAR.Service.DTOs;
using JPAR.Service.IServices;
using Microsoft.AspNetCore.Authorization;
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


        [Authorize(Roles = "Recruiter"),HttpPost("Add")]
        public IActionResult Add(AddJobDTO addJobPostDTO)
        {
            var userId = "";
            return Ok(_jobPostService.Add(addJobPostDTO, userId));
        }


        [Authorize(Roles = "Recruiter"),HttpPut("ChangeStstus")]
        public IActionResult ChangeStstus(int jobPostId, JobStatus jobPostStatus)
        {
            return Ok(_jobPostService.ChangeStatus(jobPostId, jobPostStatus));
        }


        [Authorize(Roles = "Recruiter"), HttpGet("GetByUserId")]
        public IActionResult GetByUserId()
        {
            var userId = "";
            return Ok(_jobPostService.GetByUserId(userId));
        } 


        [Authorize(Roles = "Applicant"), HttpPost("GetApplicantJobs")]
        public IActionResult GetApplicantJobs(ApplicantJobFilterDTO filter)
        {
            var userId = "";
            return Ok(_jobPostService.GetApplicantMatchedJobs(filter, userId));
        }
    }
}