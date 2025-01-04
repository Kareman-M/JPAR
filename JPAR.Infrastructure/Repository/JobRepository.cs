using JPAR.Infrastructure.Context;
using JPAR.Infrastructure.Enums;
using JPAR.Infrastructure.IRepository;
using JPAR.Infrastructure.Models;

namespace JPAR.Infrastructure.Repository
{
    public class JobRepository : IJobRepository
    {

        public ApplicationDBContext _context;

        public JobRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool Add(Job jobPost)
        {
            _context.JobPosts.Add(jobPost);
            return _context.SaveChanges() > 0;
        }

        public bool ChangeStatus(int jobPostId, JobStatus jobPostStatus)
        {
            var jobPost = _context.JobPosts.FirstOrDefault(x => x.Id == jobPostId);
            if(jobPost is null) return false;
            jobPost.Status = jobPostStatus;
            return _context.SaveChanges() >0;
        }

        public IQueryable<Job> GetAll()
        {
            return _context.JobPosts.AsQueryable();
        }

        public List<Job> GetByUserId(string userId)
        {
            var recruiterId = _context.Recruiters.FirstOrDefault(x => x.UserId == userId)?.Id;
            return _context.JobPosts.Where(x => x.RecruiterId == recruiterId).ToList();
        }
    }
}
