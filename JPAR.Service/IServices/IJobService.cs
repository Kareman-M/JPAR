using JPAR.Infrastructure.Enums;
using JPAR.Service.DTOs;

namespace JPAR.Service.IServices
{
    public interface IJobService
    {
        bool Add(AddJobDTO addJobPostDTO, string userId);
        bool ChangeStatus(int jobPostId, JobStatus jobPostStatus);
        List<JobDTO> GetByUserId(string userId);
        (JobDTO Job, bool CanApply) GetById(int jobPostId, string userId);
        List<JobDTO> GetApplicantMatchedJobs(ApplicantJobFilterDTO filter, string applicantUserId);
        List<JobApplications> GetRecruiterJobsApplications(string userId);
    }
}
