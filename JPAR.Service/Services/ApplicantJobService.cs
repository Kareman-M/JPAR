using JPAR.Infrastructure.IRepository;
using JPAR.Service.DTOs;
using JPAR.Service.IServices;

namespace JPAR.Service.Services
{
    public class ApplicantJobService : IApplicantJobService
    {
        private readonly IApplicantJobRepository _applicantJobRepository;

        public ApplicantJobService(IApplicantJobRepository applicantJobRepository)
        {
            _applicantJobRepository = applicantJobRepository;
        }

        public bool Applay(int jobId, string userId)
        {
            return _applicantJobRepository.Applay(jobId, userId);
        }

        public List<ApplicationDTO> GetApplicationsByJobId(int jobId)
        {
            return _applicantJobRepository.GetByJobId(jobId).Select(x => new ApplicationDTO
            {
                ApplicantId = x.ApplicantId,
                JobId = x.JobId,
                Applicant = new ApplicantDTO
                {
                    Achievements = x.Applicant?.Achievements,
                    Skills = x.Applicant?.Skills.Select(x => new SkillDTO
                    {
                        Interest = x.Interest,
                        Justification = x.Justification,
                        Proficiency = x.Proficiency,
                        SkillName = x.SkillName,
                        YearsOfExperience = x.YearsOfExperience,
                    }).ToList(),
                    MaritalStatus = x.Applicant?.MaritalStatus.ToString(),
                    UniversityDegrees = x.Applicant?.UniversityDegrees.Select(c => new UniversityDegreeDTO
                    {
                        StudyField = c.StudyField,
                        Country = c.Country,
                        DegreeLevel = c.DegreeLevel,
                        EndYear = c.EndYear,
                        Grade = c.Grade,
                        Info = c.Info,
                        Number = c.Number,
                        StrtYear = c.StrtYear,
                        University = c.University,
                    }).ToList(),
                    AlternativeMobileNumber = x.Applicant?.AlternativeMobileNumber,
                    Area = x.Applicant?.Area,
                    Birthdate = x.Applicant?.Birthdate,
                    Certifications = x.Applicant?.Certifications.Select(x => new CertificationDTO
                    {
                        AdditionalInfo = x.AdditionalInfo,
                        AwardedMonth = x.AwardedMonth,
                        AwardedYear = x.AwardedYear,
                        CertificateID = x.CertificateID,
                        CertificateLink = x.CertificateLink,
                        Name = x.Name,
                        Number = x.Number,
                        OrganizationName = x.OrganizationName,
                        ResultOutOfTotal = x.ResultOutOfTotal,
                    }).ToList(),
                    City = x.Applicant?.City,
                    Country = x.Applicant?.Country,
                    EducationLevel = x.Applicant?.EducationLevel.ToString(),
                    Experiences = x.Applicant.Experiences.Select(c => new ExperienceDTO
                    {
                        Achievements = c.Achievements,
                        EndDate = c.EndDate,
                        CompanyName = c.CompanyName,
                        CompanySize = c.CompanySize,
                        CompanyWebsite = c.CompanyWebsite,
                        Description = c.Description,
                        StartDate = c.StartDate,
                        Country = c.Country,
                        EndingSalary = c.EndingSalary,
                        Industry = c.Industry,
                        IsCurrent = c.IsCurrent,
                        JobTitle = c.JobTitle,
                        JobType = c.JobType,
                        StartingSalary = c.StartingSalary,
                    }).ToList(),
                    FullName = $"{x.Applicant?.User?.FirstName} {x.Applicant?.User?.LastName}",
                    Gender = x.Applicant?.Gender.ToString(),
                    Id = x.Applicant?.Id ?? 0,
                    Level = x.Applicant?.Level.ToString(),
                    MobileNumber = x.Applicant?.MobileNumber,
                    Nationality = x.Applicant?.Nationality,
                    OnlinePresences = x.Applicant?.OnlinePresences.Select(x => new OnlinePresenceDTO
                    {
                        AccountLink = x.AccountLink,
                        AccountName = x.AccountName,
                        Number = x.Number,
                    }).ToList(),
                    PostalCode = x.Applicant?.PostalCode,
                    YearsOfExperince = x.Applicant?.YearsOfExperince
                }
            }).ToList();
        }

        public List<ApplicantJobDTO> GetByApplicantId(string userId)
        {
            return _applicantJobRepository.GetByApplicantId(userId)
                .Select(x => new ApplicantJobDTO
                {
                    ApplicantId = x.ApplicantId,
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