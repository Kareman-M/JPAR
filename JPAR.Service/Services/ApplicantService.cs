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

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicantDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCareerInterest(UpdateCareerInterestDTO updateCareerInterest)
        {
            var applicant = _applicantRepository.GetByUserId(updateCareerInterest.UserId);
           
            applicant.Level = updateCareerInterest.Level;
            applicant.JobType = updateCareerInterest.JobType;
            applicant.WorkPlace = updateCareerInterest.WorkPlace;
            
            return _applicantRepository.Update(applicant);

        }

        public bool UpdateGenralInfo(UpdateApplicantGeneralInfoDTO applicantDto)
        {
            var applicant = _applicantRepository.GetByUserId(applicantDto.UserId);
            applicant = UpdateInfo(applicant, applicantDto);
            return _applicantRepository.Update(applicant);
        }

        private Applicant UpdateInfo(Applicant applicant,UpdateApplicantGeneralInfoDTO applicantDto)
        {

            applicant.FirstName = applicantDto.FirstName;
            applicant.LastName = applicantDto.LastName;
            applicant.Birthdate = applicantDto.Birthdate;
            applicant.Area = applicantDto.Area;
            applicant.Gender = applicantDto.Gender;

            return applicant;
        }
    }

}
