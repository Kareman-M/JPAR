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
            return Ok(_applicantService.UpdateGenralInfo(applicantGeneralInfo));
        }

        [HttpPut("UpdateCareerInterest")]
        public IActionResult UpdateCareerInterest(UpdateCareerInterestDTO careerInterestDTO)
        {
            return Ok(_applicantService.UpdateCareerInterest(careerInterestDTO));
        }

        [HttpPost("UpdateCv")]
        public IActionResult UpdateCv([FromForm] UpdateCvDTO updateCvDTO)
        {
            return Ok(_applicantService.UpdateCv(updateCvDTO));

        }

        [HttpPut("UpdateExperience")]
        public IActionResult UpdateExperience([FromBody] UpdateExperienceDTO updateExperience)
        {
            return Ok(_applicantService.UpdateExperience(updateExperience));
        }

        [HttpPut("UpdateSkills")]
        public IActionResult UpdateSkills([FromBody] UpdateSkillsDTO updateSkills)
        {
            return Ok(_applicantService.UpdateSkills(updateSkills));
        }

        [HttpPut("UpdateEducation")]
        public IActionResult UpdateEducation(
    [FromBody] List<UpdateUniversityDegreeDTO> universityDegrees,
    [FromBody] List<UpdateCertificationDTO> certifications,
    [FromQuery] string userId)
        {
            return Ok(_applicantService.UpdateEducation(universityDegrees, certifications, userId));
        }

        [HttpPut("UpdateOnlinePresence")]
        public IActionResult UpdateOnlinePresence([FromBody] List<UpdateOnlinePresenceDTO> onlinePresences, [FromQuery] string userId)
        {
            return Ok(_applicantService.UpdateOnlinePresence(userId, onlinePresences));
        }

        [HttpPut("UpdateAchievements")]
        public IActionResult UpdateAchievements([FromBody] UpdateAchievementsDTO achievements)
        {
            if (string.IsNullOrEmpty(achievements.UserId))
                return BadRequest("User ID is required.");

            return Ok(_applicantService.UpdateAchievements(achievements));
        }


    }
}
