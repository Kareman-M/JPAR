using JPAR.Infrastructure.Context;
using JPAR.Infrastructure.IRepository;

namespace JPAR.Infrastructure.Repository
{
    public class RecruiterRepository : IRecruiterRepository
    {
        private readonly ApplicationDBContext _context;

        public RecruiterRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool Add(string userId)
        {
            var recruiter = new Recruiter();
            recruiter.UserId = userId;
            recruiter.CreatedBy = userId;
            recruiter.CreatedAt = DateTime.Now;
            _context.Recruiters.Add(recruiter);
            return _context.SaveChanges() > 0;
        }

        public Recruiter GetByUserId(string userId)
        {
            return _context.Recruiters.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
