using JPAR.Service.DTOs;

namespace JPAR.Service.IServices
{
    public interface IApplicantService
    {
        ApplicantDTO GetById(int id);
        bool Add(AddApplicantDTO applicant);
        bool Update(UpdateApplicantDTO applicant);
        bool Delete(int id);
    }
}
