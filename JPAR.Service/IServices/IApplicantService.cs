using JPAR.Service.DTOs;

namespace JPAR.Service.IServices
{
    public interface IApplicantService
    {
        ApplicantDTO GetById(int id);
        bool UpdateGenralInfo(UpdateApplicantGeneralInfoDTO applicant);
        bool UpdateCareerInterest(UpdateCareerInterestDTO updateCareerInterest);
        bool UpdateCv(UpdateCvDTO updateCv);

        bool UpdateExperience(UpdateExperienceDTO updateExperience);

        bool UpdateSkills(UpdateSkillsDTO updateSkills);
        bool UpdateEducation(List<UpdateUniversityDegreeDTO> universityDegrees, List<UpdateCertificationDTO> certifications, string userId);

        bool UpdateOnlinePresence(string userId, List<UpdateOnlinePresenceDTO> onlinePresences);

        bool UpdateAchievements(UpdateAchievementsDTO achievements);


        bool Delete(int id);
    }
}
