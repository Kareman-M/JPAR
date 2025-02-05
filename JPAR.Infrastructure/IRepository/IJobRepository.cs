using JPAR.Infrastructure.Enums;
using JPAR.Infrastructure.Models;

namespace JPAR.Infrastructure.IRepository
{
    public interface IJobRepository
    {
        bool Add(Job jobPost);
        bool ChangeStatus(int jobPostId, JobStatus jobPostStatus);
        List<Job> GetByUserId(string userId);
        Job GetById(int jobPostId);
        IEnumerable<Job> GetAll();
        List<Job> GetDetailedJobsByUserId(string userId);
        bool Delete(int jobId);
        Job Update(Job job);
    }
}