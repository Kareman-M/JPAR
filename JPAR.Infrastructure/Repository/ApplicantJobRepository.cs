using JPAR.Infrastructure.Context;
using JPAR.Infrastructure.Enums;
using JPAR.Infrastructure.IRepository;
using JPAR.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JPAR.Infrastructure.Repository
{
    public class ApplicantJobRepository : IApplicantJobRepository
    {
        private readonly ApplicationDBContext _context;

        public ApplicantJobRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool Applay(int jobId, int applicantId)
        {
            var job = _context.JobPosts.FirstOrDefault(p => p.Id == jobId);
            if(job is null) return false;
            _context.ApplicantJob.Add(new Models.ApplicantJob
            {
                ApplicantId = applicantId,
                JobId = jobId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Status = Enums.ApplicationStatus.Applied,
            });
            return _context.SaveChanges() > 0;
        }

        public List<ApplicantJob> GetByApplicantId(int applicantId)
        {
            return _context.ApplicantJob
                .Where(x => x.ApplicantId == applicantId)
                .Include(x => x.Job).ThenInclude(x=> x.Recruiter)
                .ToList();
        }

        public List<ApplicantJob> GetByJobId(int jobId)
        {
            return _context.ApplicantJob
              .Where(x => x.JobId == jobId)
              .Include(x => x.Applicant).ThenInclude(x=> x.User)
              .ToList();
        }

        public bool UpdateStatus(int jobId, int applicantId, ApplicationStatus newStatus, string comment)
        {
            var app = _context.ApplicantJob.FirstOrDefault(p => p.Id == jobId && p.ApplicantId == applicantId);
            if(app is null) return false;
            app.Status = newStatus;
            app.UpdatedAt = DateTime.Now;
            app.Comment = comment;
           return _context.SaveChanges() > 0;
        }
    }
}