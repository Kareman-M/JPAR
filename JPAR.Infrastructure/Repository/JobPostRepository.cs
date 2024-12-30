using JPAR.Infrastructure.Context;
using JPAR.Infrastructure.Enums;
using JPAR.Infrastructure.IRepository;
using JPAR.Infrastructure.Models;

namespace JPAR.Infrastructure.Repository
{
    public class JobPostRepository : IJobPostRepository
    {

        public ApplicationDBContext _context;

        public JobPostRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool Add(JobPost jobPost)
        {
            _context.JobPosts.Add(jobPost);
            return _context.SaveChanges() > 0;
        }

        public bool ChangeStatus(int jobPostId, JobPostStatus jobPostStatus)
        {
            var jobPost = _context.JobPosts.FirstOrDefault(x => x.Id == jobPostId);
            if(jobPost is null) return false;
            jobPost.Status = jobPostStatus;
            return _context.SaveChanges() >0;
        }

        public List<JobPost> GetByUserId(string userId)
        {
            var recruiterId = _context.Recruiters.FirstOrDefault(x => x.UserId == userId)?.Id;
            return _context.JobPosts.Where(x => x.RecruiterId == recruiterId).ToList();
        }
    }
}
