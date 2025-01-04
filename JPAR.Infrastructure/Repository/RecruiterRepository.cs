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

        public Recruiter GetByUserId(string userId)
        {
            return _context.Recruiters.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
