using JPAR.Infrastructure.Enums;
using JPAR.Infrastructure.Models;

namespace JPAR.Infrastructure.IRepository
{
    public interface IApplicantJobRepository
    {
        bool Applay(int jobId, int applicantId);
        bool UpdateStatus(int jobId, int applicantId, ApplicationStatus newStatus, string comment);
        List<ApplicantJob> GetByApplicantId(int applicantId);
        List<ApplicantJob> GetByJobId(int jobId);
    }
}