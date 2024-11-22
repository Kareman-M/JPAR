using JPAR.Infrastructure.IRepository;
using JPAR.Service.DTOs;
using JPAR.Service.IServices;

namespace JPAR.Service.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;

        public ApplicantService(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        public bool Add(AddApplicantDTO applicant)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicantDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(UpdateApplicantDTO applicant)
        {
            throw new NotImplementedException();
        }
    }
}
