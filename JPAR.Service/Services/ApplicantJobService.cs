using JPAR.Infrastructure.IRepository;
using JPAR.Service.DTOs;
using JPAR.Service.IServices;

namespace JPAR.Service.Services
{
    public class ApplicantJobService : IApplicantJobService
    {
        private readonly IApplicantJobRepository _applicantJobRepository;
        private readonly IApplicantRepository _applicantRepository;
        public ApplicantJobService(IApplicantJobRepository applicantJobRepository, IApplicantRepository applicantRepository)
        {
            _applicantJobRepository = applicantJobRepository;
            _applicantRepository = applicantRepository;
        }

        public bool Applay(int jobId, string userId)
        {
            return _applicantJobRepository.Applay(jobId, userId);
        }

        public ApplicantDTO GetApplicantDataById(int applicantId)
        {
            var applicant = _applicantRepository.GetById(applicantId);
            return new ApplicantDTO
            {
                Achievements = applicant?.Achievements,
                Skills = applicant?.Skills?.Select(x => new SkillDTO
                {
                    Interest = x.Interest,
                    Justification = x.Justification,
                    Proficiency = x.Proficiency,
                    SkillName = x.SkillName,
                    YearsOfExperience = x.YearsOfExperience,
                })?.ToList(),
                MaritalStatus = applicant?.MaritalStatus?.ToString(),
                UniversityDegrees = applicant?.UniversityDegrees?.Select(c => new UniversityDegreeDTO
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
                })?.ToList(),
                AlternativeMobileNumber = applicant?.AlternativeMobileNumber,
                Area = applicant?.Area,
                Birthdate = applicant?.Birthdate,
                Certifications = applicant?.Certifications?.Select(x => new CertificationDTO
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
                })?.ToList(),
                City = applicant?.City,
                Country = applicant?.Country,
                EducationLevel = applicant?.EducationLevel?.ToString(),
                Experiences = applicant.Experiences?.Select(c => new ExperienceDTO
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
                })?.ToList(),
                FullName = $"{applicant?.User?.FirstName} {applicant?.User?.LastName}",
                Gender = applicant?.Gender?.ToString(),
                Id = applicant?.Id ?? 0,
                Level =  applicant?.Level?.ToString(),
                MobileNumber = applicant?.MobileNumber,
                Nationality = applicant?.Nationality,
                OnlinePresences = applicant?.OnlinePresences?.Select(x => new OnlinePresenceDTO
                {
                    AccountLink = x.AccountLink,
                    AccountName = x.AccountName,
                    Number = x.Number,
                })?.ToList(),
                PostalCode = applicant?.PostalCode,
                YearsOfExperince = applicant?.YearsOfExperince,
                JobTitles = applicant.JobTitles?.Select(x => x.Title)?.ToList(),
                JobTypes = applicant.JobType?.Select(x => x.Name)?.ToList(),
                WorkPlaces = applicant.WorkPlace?.Select(x => x.Name)?.ToList(),
                Categories = applicant.IndustryCategories?.Select(x=> x.Category)?.ToList(),
                DesiredNetSalaryPerMonth = applicant?.DesiredNetSalaryPerMonth,
                FileName = applicant?.UploadedCVFileName,
                FilePath = applicant?.UploadedCVPath
            };
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
                    YearsOfExperince = x.Applicant?.YearsOfExperince,
                    JobTitles = x.Applicant?.JobTitles.Select(x => x.Title).ToList(),
                    JobTypes = x.Applicant?.JobType.Select(x => x.Name).ToList(),
                    WorkPlaces = x.Applicant?.WorkPlace.Select(x => x.Name).ToList(),
                    Categories = x.Applicant?.IndustryCategories.Select(x => x.Category).ToList(),
                    DesiredNetSalaryPerMonth = x.Applicant?.DesiredNetSalaryPerMonth,
                    FileName = x.Applicant?.UploadedCVFileName,
                    FilePath = x.Applicant?.UploadedCVPath
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