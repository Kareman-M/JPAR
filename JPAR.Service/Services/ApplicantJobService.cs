using JPAR.Infrastructure.Repository;
using JPAR.Service.DTOs;
using JPAR.Service.IServices;

namespace JPAR.Service.Services
{
    public class ApplicantJobService : IApplicantJobService
    {
        private readonly ApplicantJobRepository _applicantJobRepository;

        public ApplicantJobService(ApplicantJobRepository applicantJobRepository)
        {
            _applicantJobRepository = applicantJobRepository;
        }

        public bool Applay(int jobId, int applicantId)
        {
            return _applicantJobRepository.Applay(jobId, applicantId);
        }

        public List<ApplicationDTO> GetApplicationsByJobId(int jobId)
        {
            return _applicantJobRepository.GetByJobId(jobId).Select(x=> new ApplicationDTO
            {
                ApplicantJobId = x.Id,
                Applicant = new ApplicantDTO 
                {
                    Achievements = x.Applicant?.Achievements,
                    Skills = x.Applicant?.Skills,
                    MaritalStatus = x.Applicant?.MaritalStatus.ToString(),
                    UniversityDegrees = x.Applicant?.UniversityDegrees,
                    AlternativeMobileNumber = x.Applicant?.AlternativeMobileNumber,
                    Area = x.Applicant?.Area,
                    Birthdate = x.Applicant?.Birthdate,
                    Certifications = x.Applicant?.Certifications,
                    City = x.Applicant?.City,
                    Country = x.Applicant?.Country,
                    EducationLevel=x.Applicant?.EducationLevel.ToString(),
                    Experiences = x.Applicant?.Experiences,
                    FullName = $"{x.Applicant?.User?.FirstName} {x.Applicant?.User?.LastName}",
                    Gender = x.Applicant?.Gender.ToString(),
                    Id = x.Applicant?.Id??0,
                    Level = x.Applicant?.Level.ToString(),
                    MobileNumber = x.Applicant?.MobileNumber,
                    Nationality = x.Applicant?.Nationality,
                    OnlinePresences = x.Applicant?.OnlinePresences,
                    PostalCode = x.Applicant?.PostalCode,
                    YearsOfExperince = x.Applicant?.YearsOfExperince
                }
            }).ToList();
        }

        public List<ApplicantJobDTO> GetByApplicantId(int applicantId)
        {
            return _applicantJobRepository.GetByApplicantId(applicantId)
                .Select(x => new ApplicantJobDTO
                {
                    Id = x.Id,
                    CompanyName = x.Job.Recruiter.CompanyName,
                    JobTitle = x.Job.Title,
                    CreatedAt = x.CreatedAt,
                    JobId = x.JobId,
                    Location = x.Job.Country,
                    Status = x.Status.ToString(),
                }).ToList();
        }

        public bool UpdateStatus(UpdateApplicationStatusDTO updateStatus)
        {
            return _applicantJobRepository.UpdateStatus(updateStatus.JobId, updateStatus.ApplicantId, updateStatus.ApplicationStatus, updateStatus.Comment);
        }
    }
}