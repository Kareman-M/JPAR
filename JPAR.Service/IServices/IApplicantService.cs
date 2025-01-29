using JPAR.Service.DTOs;

namespace JPAR.Service.IServices
{
    public interface IApplicantService
    {
        ApplicantDTO GetById(int id);
        
        bool UpdateGenralInfo(string userId, UpdateApplicantGeneralInfoDTO applicant);
        
        bool UpdateCareerInterest(string userId, UpdateCareerInterestDTO updateCareerInterest);
        
        bool UpdateCv(string userId, UpdateCvDTO updateCv);

        bool UpdateExperience(string userId, UpdateExperienceDTO updateExperience);

        bool UpdateSkills( string userId, UpdateSkillsDTO updateSkills);
      
        bool UpdateEducation( string userId, UpdateEducationDTO updateEducation);

        bool UpdateOnlinePresence(string userId, List<UpdateOnlinePresenceDTO> onlinePresences);

        bool UpdateAchievements(string userId, UpdateAchievementsDTO achievements);

        bool Delete(int id);
    }
}
