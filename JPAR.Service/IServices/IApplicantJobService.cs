using JPAR.Infrastructure.Enums;
using JPAR.Infrastructure.Models;
using JPAR.Service.DTOs;

namespace JPAR.Service.IServices
{
    public interface IApplicantJobService
    {
        bool Applay(int jobId, string userId);
        bool UpdateStatus(UpdateApplicationStatusDTO updateStatus);
        List<ApplicantJobDTO> GetByApplicantId(string userId);
        List<ApplicationDTO> GetApplicationsByJobId(int jobId);
        ApplicantDTO GetApplicantDataById(int applicantId);
    }
}
