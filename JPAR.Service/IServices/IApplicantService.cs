using JPAR.Service.DTOs;

namespace JPAR.Service.IServices
{
    public interface IApplicantService
    {
        ApplicantDTO GetById(int id);

        (UpdateApplicantGeneralInfoDTO, int ApplicantId) UpdateGenralInfo(string userId, UpdateApplicantGeneralInfoDTO applicant);

        (UpdateCareerInterestDTO, int ApplicantId) UpdateCareerInterest(string userId, UpdateCareerInterestDTO updateCareerInterest);

        (string FileName, string FilePath, int ApplicantId) UpdateCv(string userId, UpdateCvDTO updateCv);

        (UpdateExperienceDTO, int ApplicantId) UpdateExperience(string userId, UpdateExperienceDTO updateExperience);

        (UpdateSkillsDTO, int ApplicantId) UpdateSkills(string userId, UpdateSkillsDTO updateSkills);

        (UpdateEducationDTO, int ApplicantId) UpdateEducation(string userId, UpdateEducationDTO updateEducation);

        (List<UpdateOnlinePresenceDTO>, int ApplicantId) UpdateOnlinePresence(string userId, List<UpdateOnlinePresenceDTO> onlinePresences);

        (UpdateAchievementsDTO, int ApplicantId) UpdateAchievements(string userId, UpdateAchievementsDTO achievements);

        bool Delete(int id);
    }
}
