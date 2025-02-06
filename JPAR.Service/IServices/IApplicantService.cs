using JPAR.Service.DTOs;
using Microsoft.AspNetCore.Http;

namespace JPAR.Service.IServices
{
    public interface IApplicantService
    {
        ApplicantDTO GetByUserId(string userId);

        (UpdateApplicantGeneralInfoDTO Data, int ApplicantId) UpdateGenralInfo(string userId, UpdateApplicantGeneralInfoDTO applicant);

        (UpdateCareerInterestDTO Data, int ApplicantId) UpdateCareerInterest(string userId, UpdateCareerInterestDTO updateCareerInterest);

        (string FileName, string FilePath, int ApplicantId) UpdateCv(string userId, IFormFile updateCv, string webRootPath);

        (UpdateExperienceDTO Data, int ApplicantId) UpdateExperience(string userId, UpdateExperienceDTO updateExperience);

        (UpdateSkillsDTO Data, int ApplicantId) UpdateSkills(string userId, UpdateSkillsDTO updateSkills);

        (UpdateEducationDTO Data, int ApplicantId) UpdateEducation(string userId, UpdateEducationDTO updateEducation);

        (List<UpdateOnlinePresenceDTO> Data, int ApplicantId) UpdateOnlinePresence(string userId, List<UpdateOnlinePresenceDTO> onlinePresences);

        (UpdateAchievementsDTO Data, int ApplicantId) UpdateAchievements(string userId, UpdateAchievementsDTO achievements);

        bool Delete(int id);
        byte[] DownloadCV(string userId, string contentRootPath);
        bool  DeleteCV(string userId, string contentRootPath);
    }
}
