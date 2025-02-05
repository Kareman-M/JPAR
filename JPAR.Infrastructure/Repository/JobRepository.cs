using JPAR.Infrastructure.Context;
using JPAR.Infrastructure.Enums;
using JPAR.Infrastructure.IRepository;
using JPAR.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

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

        public bool Delete(int jobId)
        {
            var job = _context.JobPosts.FirstOrDefault(x=> x.Id == jobId);
            if (job is null) return false;
            _context.JobPosts.Remove(job);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Job> GetAll()
        {
            return _context.JobPosts.Include(x=> x.JobTypes).Include(x=> x.JobTypes).Include(x=> x.Recruiter);
        }

        public Job GetById(int jobPostId)
        {
            return _context.JobPosts.Include(x=> x.Recruiter).Include(x => x.JobTypes).Include(x => x.JobTypes).FirstOrDefault(x => x.Id == jobPostId);
        }

        public List<Job> GetByUserId(string userId)
        {
            var recruiterId = _context.Recruiters.FirstOrDefault(x => x.UserId == userId)?.Id;
            return _context.JobPosts.Where(x => x.RecruiterId == recruiterId).ToList();
        }

        public List<Job> GetDetailedJobsByUserId(string userId)
        {
            return _context.JobPosts
                 .Include(x => x.Recruiter)
                 .Include(x => x.JobTypes)
                 .Include(x => x.JobTypes)
                 .Include(x => x.ApplicantJobs).ThenInclude(x => x.Applicant).ThenInclude(x=> x.User)
                 .Include(x => x.ApplicantJobs).ThenInclude(x => x.ApplicationStages)
                 .Where(x => x.Recruiter.UserId == userId).ToList();
        }

        public Job Update(Job job)
        {
            var jobUpdated = _context.JobPosts.Update(job);
            _context.SaveChanges();
            return jobUpdated.Entity;

        }
    }
}
