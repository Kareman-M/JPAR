using JPAR.Infrastructure.Enums;
using JPAR.Service.DTOs;
using JPAR.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace JPAR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostController : ControllerBase
    {
        private readonly IJobPostService _jobPostService;

        public JobPostController(IJobPostService jobPostService)
        {
            _jobPostService = jobPostService;
        }

        public IActionResult Add(AddJobPostDTO addJobPostDTO)
        {
            var userId = "";
            return Ok(_jobPostService.Add(addJobPostDTO, userId));
        }

        [HttpPut("ChangeStstus")]
        public IActionResult ChangeStstus(int jobPostId, JobPostStatus jobPostStatus)
        {
            return Ok(_jobPostService.ChangeStatus(jobPostId, jobPostStatus));
        }

        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId()
        {
            var userId = "";
            return Ok(_jobPostService.GetByUserId(userId));
        }
    }
}