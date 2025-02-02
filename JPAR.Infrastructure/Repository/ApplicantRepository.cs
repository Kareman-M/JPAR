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
            return _context.Applicants
                .Include(x=> x.User)
                .Include(x=> x.IndustryCategories)
                .Include(x=> x.OnlinePresences)
                .Include(x=> x.Skills)
                .Include(x=> x.UniversityDegrees)
                .Include(x=> x.Experiences)
                .Include(x=> x.WorkPlace)
                .Include(x=> x.JobTitles)
                .Include(x=> x.JobType)
                .FirstOrDefault(x => x.UserId == userId);
        }

        public Applicant Update(Applicant applicant)
        {
            var _applicant  = _context.Applicants.Update(applicant);
            _context.SaveChanges();
            return _applicant.Entity;
        }
    }
}
