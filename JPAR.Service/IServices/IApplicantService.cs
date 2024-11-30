using JPAR.Service.DTOs;

namespace JPAR.Service.IServices
{
    public interface IApplicantService
    {
        ApplicantDTO GetById(int id);
        bool Update(UpdateApplicantGeneralInfoDTO applicant);
        bool Delete(int id);
    }
}
