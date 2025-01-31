using JPAR.Service.DTOs;
using JPAR.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JPAR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Applicant")]
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
            var userId = HttpContext.User.Claims.FirstOrDefault(x=> x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            return Ok(_applicantService.UpdateGenralInfo(userId, applicantGeneralInfo));
        }

        
        [HttpPut("UpdateCareerInterest")]
        public IActionResult UpdateCareerInterest(UpdateCareerInterestDTO careerInterestDTO)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            return Ok(_applicantService.UpdateCareerInterest(userId, careerInterestDTO));
        }

        
        [HttpPost("UpdateCv")]
        public IActionResult UpdateCv([FromForm] UpdateCvDTO updateCvDTO)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            return Ok(_applicantService.UpdateCv( userId, updateCvDTO));

        }

       
        [HttpPut("UpdateExperience")]
        public IActionResult UpdateExperience([FromBody] UpdateExperienceDTO updateExperience)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            return Ok(_applicantService.UpdateExperience(userId,updateExperience));
        }

      
        [HttpPut("UpdateSkills")]
        public IActionResult UpdateSkills([FromBody] UpdateSkillsDTO updateSkills)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            return Ok(_applicantService.UpdateSkills(userId, updateSkills));
        }

        
        [HttpPut("UpdateEducation")]
        public IActionResult UpdateEducation([FromBody]UpdateEducationDTO updateEducation)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            return Ok(_applicantService.UpdateEducation(userId, updateEducation));
        }

        
        [HttpPut("UpdateOnlinePresence")]
        public IActionResult UpdateOnlinePresence([FromBody] List<UpdateOnlinePresenceDTO> onlinePresences)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            return Ok(_applicantService.UpdateOnlinePresence(userId, onlinePresences));
        }

        
        [HttpPut("UpdateAchievements")]
        public IActionResult UpdateAchievements([FromBody] UpdateAchievementsDTO achievements)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            if (userId == null) return Unauthorized();
            return Ok(_applicantService.UpdateAchievements(userId,achievements));
        }
    }
}
