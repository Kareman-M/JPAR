using JPAR.Service.DTOs;
using JPAR.Service.IServices;
using JPAR.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JPAR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles= "Applicant")]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;
        private readonly IWebHostEnvironment env;

        public ApplicantController(IApplicantService applicantService, IWebHostEnvironment env)
        {
            _applicantService = applicantService;
            this.env = env;
        }


        [HttpGet("GetApplicantData")]  // baseurl/api/applicant/GetApplicantData
        public IActionResult GetApplicantData()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            return Ok(_applicantService.GetByUserId(userId));
        }

        [HttpPut("UpdateGeneralInfo")] //baseurl/api/applicant/UpdateGeneralInfo
        public IActionResult UpdateGeneralInfo(UpdateApplicantGeneralInfoDTO applicantGeneralInfo)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x=> x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            var data = _applicantService.UpdateGenralInfo(userId, applicantGeneralInfo);
            return Ok(new {data = data.Data , applicanId = data.ApplicantId });
        }

        
        [HttpPut("UpdateCareerInterest")] 
        public IActionResult UpdateCareerInterest(UpdateCareerInterestDTO careerInterestDTO)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            var data = _applicantService.UpdateCareerInterest(userId, careerInterestDTO);
            return Ok(new { data = data.Data, applicanId = data.ApplicantId });
        }

        
        [HttpPost("UpdateCv")]
        public IActionResult UpdateCv([FromForm] UpdateCvDTO updateCvDTO)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            var data = _applicantService.UpdateCv(userId, updateCvDTO);
            return Ok(new { FileName = data.FileName,FilePath = data.FilePath, applicanId = data.ApplicantId });

        }

       
        [HttpPut("UpdateExperience")]
        public IActionResult UpdateExperience([FromBody] UpdateExperienceDTO updateExperience)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            var data = _applicantService.UpdateExperience(userId, updateExperience);
            return Ok(new { data = data.Data, applicanId = data.ApplicantId });
        }

      
        [HttpPut("UpdateSkills")]
        public IActionResult UpdateSkills([FromBody] UpdateSkillsDTO updateSkills)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            var data = _applicantService.UpdateSkills(userId, updateSkills);
            return Ok(new { data = data.Data, applicanId = data.ApplicantId });
        }

        
        [HttpPut("UpdateEducation")]
        public IActionResult UpdateEducation([FromBody]UpdateEducationDTO updateEducation)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            var data = _applicantService.UpdateEducation(userId, updateEducation);
            return Ok(new { data = data.Data, applicanId = data.ApplicantId });
        }

        
        [HttpPut("UpdateOnlinePresence")]
        public IActionResult UpdateOnlinePresence([FromBody] List<UpdateOnlinePresenceDTO> onlinePresences)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            var data = _applicantService.UpdateOnlinePresence(userId, onlinePresences);
            return Ok(new { data = data.Data, applicanId = data.ApplicantId });
        }

        
        [HttpPut("UpdateAchievements")]
        public IActionResult UpdateAchievements([FromBody] UpdateAchievementsDTO achievements)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            var data = _applicantService.UpdateAchievements(userId,achievements);
            return Ok(new { data = data.Data, applicanId = data.ApplicantId });
        }

        [HttpGet("DownloadCV")]
        public IActionResult DownloadCV()
        {
            try
            {

                var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
                if (userId == null) return Unauthorized();
                byte[] stream = _applicantService.DownloadCV(userId, env.ContentRootPath);
                if (stream is null) return NotFound("File Not Found");
                return File(stream, "application/pdf");
            }
            catch(Exception ex)
            {
                return BadRequest("File Not Found");
            }
        }

        [HttpDelete("DeleteCV")]
        public IActionResult DeleteCV()
        {
            try
            {

                var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
                if (userId == null) return Unauthorized();
                bool result = _applicantService.DeleteCV(userId, env.ContentRootPath);
                if (!result) return NotFound("File Not Found");
                return Ok("Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("File Not Found");
            }
        }
    }
}
