using JPAR.Service.DTOs;

namespace JPAR.Service.IServices
{
    public interface IApplicantService
    {
        ApplicantDTO GetById(int id);
        bool UpdateGenralInfo(UpdateApplicantGeneralInfoDTO applicant);
        bool UpdateCareerInterest(UpdateCareerInterestDTO updateCareerInterest);
        bool Delete(int id);
    }
}
