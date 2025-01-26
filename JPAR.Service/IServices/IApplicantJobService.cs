using JPAR.Infrastructure.Enums;
using JPAR.Infrastructure.Models;
using JPAR.Service.DTOs;

namespace JPAR.Service.IServices
{
    public interface IApplicantJobService
    {
        bool Applay(int jobId, int applicantId);
        bool UpdateStatus(UpdateApplicationStatusDTO updateStatus);
        List<ApplicantJobDTO> GetByApplicantId(int applicantId);
        List<ApplicationDTO> GetApplicationsByJobId(int jobId);
    }
}
