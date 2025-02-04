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

        public bool Applay(int jobId, string userId)
        {
            var job = _context.JobPosts.FirstOrDefault(p => p.Id == jobId);
            var applicant = _context.Applicants.FirstOrDefault(x => x.UserId == userId);
            if(job is null || applicant is null) return false;
            _context.ApplicantJob.Add(new Models.ApplicantJob
            {
                ApplicantId = applicant.Id,
                JobId = jobId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Status = Enums.ApplicationStatus.Applied,
                Comment = "",
                CreatedBy = userId
            });
            return _context.SaveChanges() > 0;
        }

        public bool CanApplicantApplay(string userId , int jobId)
        {
            var applicantj = _context.ApplicantJob.FirstOrDefault(x => x.Applicant.UserId == userId && x.JobId == jobId);
            return applicantj == null ? true : false;
        }

        public List<ApplicantJob> GetByApplicantId(string userId)
        {
            return _context.ApplicantJob
                .Include(x=> x.Applicant)
                .Where(x => x.Applicant.UserId == userId)
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
            var app = _context.ApplicantJob.FirstOrDefault(p => p.JobId == jobId && p.ApplicantId == applicantId);
            if(app is null) return false;
            app.Status = newStatus;
            app.UpdatedAt = DateTime.Now;
            app.Comment = comment;
           return _context.SaveChanges() > 0;
        }
    }
}