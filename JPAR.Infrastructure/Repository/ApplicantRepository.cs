using JPAR.Infrastructure.Context;
using JPAR.Infrastructure.IRepository;

namespace JPAR.Infrastructure.Repository
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly ApplicationDBContext _context;

        public ApplicantRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool Add(string userId)
        {
            var applicant = new Applicant();
            applicant.UserId = userId;
            _context.Applicants.Add(applicant);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Applicant GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Applicant applicant)
        {
            throw new NotImplementedException();
        }
    }
}
