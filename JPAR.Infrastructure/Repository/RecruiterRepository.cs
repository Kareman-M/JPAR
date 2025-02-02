using JPAR.Infrastructure.Context;
using JPAR.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace JPAR.Infrastructure.Repository
{
    public class RecruiterRepository : IRecruiterRepository
    {
        private readonly ApplicationDBContext _context;

        public RecruiterRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool Add(string userId, string companyName, string jobTitle)
        {
            var recruiter = new Recruiter();
            recruiter.UserId = userId;
            recruiter.CreatedBy = userId;
            recruiter.CreatedAt = DateTime.Now;
            recruiter.CompanyName = companyName;
            recruiter.JobTitle = jobTitle;
            _context.Recruiters.Add(recruiter);
            return _context.SaveChanges() > 0;
        }

        public Recruiter GetByUserId(string userId)
        {
            return _context.Recruiters.FirstOrDefault(x => x.UserId == userId);
        }

    }
}
