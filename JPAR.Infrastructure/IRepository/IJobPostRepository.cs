using JPAR.Infrastructure.Enums;
using JPAR.Infrastructure.Models;

namespace JPAR.Infrastructure.IRepository
{
    public interface IJobPostRepository
    {
        bool Add(JobPost jobPost);
        bool ChangeStatus(int jobPostId, JobPostStatus jobPostStatus);
        List<JobPost> GetByUserId(string userId);
    }
}