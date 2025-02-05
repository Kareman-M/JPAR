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
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            return Ok(_jobPostService.Add(addJobPostDTO, userId));
        }

     
        [Authorize(Roles ="Recruiter"),HttpPut("ChangeStstus")]
        public IActionResult ChangeStstus(int jobPostId, JobStatus jobPostStatus)
        {
            return Ok(_jobPostService.ChangeStatus(jobPostId, jobPostStatus));
        }


        [Authorize(Roles ="Recruiter"), HttpGet("GetByUserId")]
        public IActionResult GetByUserId()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            return Ok(_jobPostService.GetByUserId(userId));
        }


        [Authorize(Roles = "Applicant"), HttpPost("GetApplicantJobs")]
        public IActionResult GetApplicantJobs(ApplicantJobFilterDTO filter)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            return Ok(_jobPostService.GetApplicantMatchedJobs(filter, userId));
        }


        [Authorize(Roles = "Applicant"), HttpGet("GetJobDetails/{jobId}")]
        public IActionResult GetJobDetails(int jobId)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            var result = _jobPostService.GetById(jobId, userId);
            return Ok(new { data = result.Job, result.CanApply });
        }


        [Authorize(Roles = "Recruiter"), HttpGet("GetRecruiterJobsApplications")]
        public IActionResult GetRecruiterJobsApplications()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            return Ok(_jobPostService.GetRecruiterJobsApplications(userId));
        }


        [Authorize(Roles = "Recruiter"), HttpDelete("Delete/{jobId}")]
        public IActionResult Delete(int jobId)
        {
            try
            {

               return _jobPostService.Delete(jobId) ? Ok("Deleted Successfully"): NotFound("Job Not Found");
            }
            catch(Exception ex)
            {
                return BadRequest("Can't Delete or Edit This Job");
            }
        }

        [Authorize(Roles = "Recruiter"), HttpPut("Edit")]
        public IActionResult Edit(EditJobDTO dto)
        {
            JobDTO job = _jobPostService.Edit(dto);
            return  Ok();
        }
    }
}