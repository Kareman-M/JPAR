using JPAR.Infrastructure.Enums;
using JPAR.Infrastructure.Models;

namespace JPAR.Infrastructure.IRepository
{
    public interface IApplicantJobRepository
    {
        bool Applay(int jobId, string userId);
        bool UpdateStatus(int jobId, int applicantId, ApplicationStatus newStatus, string comment);
        List<ApplicantJob> GetByApplicantId(string userId);
        List<ApplicantJob> GetByJobId(int jobId);
        bool CanApplicantApplay(string userId, int jobId);
    }
}