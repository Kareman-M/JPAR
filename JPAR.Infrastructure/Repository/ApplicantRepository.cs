using JPAR.Infrastructure.Context;
using JPAR.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

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
            applicant.CreatedBy = userId;
            applicant.CreatedAt = DateTime.Now;
            _context.Applicants.Add(applicant);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
           _context.Applicants.Remove(GetById(id));
           return _context.SaveChanges() > 0;
        }

        public Applicant GetById(int id)
        {
            return _context.Applicants.FirstOrDefault(x => x.Id == id);
        }

        public Applicant GetByUserId(string userId)
        {
            return _context.Applicants.Include(x=> x.User).FirstOrDefault(x => x.UserId == userId);
        }

        public bool Update(Applicant applicant)
        {
            _context.Applicants.Update(applicant);
           return _context.SaveChanges()> 0;
        }
    }
}
