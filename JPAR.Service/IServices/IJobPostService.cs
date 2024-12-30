using JPAR.Infrastructure.Enums;
using JPAR.Service.DTOs;

namespace JPAR.Service.IServices
{
    public interface IJobPostService
    {
        bool Add(AddJobPostDTO addJobPostDTO, string userId);
        bool ChangeStatus(int jobPostId, JobPostStatus jobPostStatus);
        List<JobPostDTO> GetByUserId(string userId);
    }
}
