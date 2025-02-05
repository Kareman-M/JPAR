using JPAR.Infrastructure.IRepository;
using JPAR.Infrastructure.Models;
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

        public ApplicantDTO GetByUserId(string userId)
        {
            var applicant = _applicantRepository.GetByUserId(userId);

            if (applicant is null) return null;

            return new ApplicantDTO
            {
                FullName = $"{applicant.User.FirstName} {applicant.User.LastName}",
                UniversityDegrees = applicant.UniversityDegrees?.Select(x => new UniversityDegreeDTO
                {
                    StudyField = x.StudyField,
                    Country = x.Country,
                    DegreeLevel = x.DegreeLevel,
                    EndYear = x.EndYear,
                    Grade = x.Grade,
                    Info = x.Info,
                    Number = x.Number,
                    StrtYear = x.StrtYear,
                    University = x.University,
                }).ToList(),
                Achievements = applicant.Achievements,
                AlternativeMobileNumber = applicant.AlternativeMobileNumber,
                Area = applicant.Area,
                Birthdate = applicant.Birthdate,
                Certifications = applicant.Certifications?.Select(x => new CertificationDTO
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
                Country = applicant.Country,
                City = applicant.City,
                EducationLevel = applicant.EducationLevel?.ToString(),
                Experiences = applicant.Experiences?.Select(x => new ExperienceDTO
                {
                    Achievements = x.Achievements,
                    EndDate = x.EndDate,
                    CompanyName = x.CompanyName,
                    CompanySize = x.CompanySize,
                    CompanyWebsite = x.CompanyWebsite,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    Country = x.Country,
                    EndingSalary = x.EndingSalary,
                    Industry = x.Industry,
                    IsCurrent = x.IsCurrent,
                    JobTitle = x.JobTitle,
                    JobType = x.JobType,
                    StartingSalary = x.StartingSalary,
                }).ToList(),
                Gender = applicant.Gender?.ToString(),
                Id = applicant.Id,
                Level = applicant.Level?.ToString(),
                MaritalStatus = applicant.MaritalStatus?.ToString(),
                MobileNumber = applicant.User.PhoneNumber,
                Nationality = applicant.Nationality,
                OnlinePresences = applicant.OnlinePresences?.Select(x => new OnlinePresenceDTO
                {
                    AccountLink = x.AccountLink,
                    AccountName = x.AccountName,
                    Number = x.Number,
                }).ToList(),
                Skills = applicant.Skills?.Select(x => new SkillDTO
                {
                    Interest = x.Interest,
                    Justification = x.Justification,
                    Proficiency = x.Proficiency,
                    SkillName = x.SkillName,
                    YearsOfExperience = x.YearsOfExperience,
                }).ToList(),
                PostalCode = applicant.PostalCode,
                YearsOfExperince = applicant.YearsOfExperince,
                JobTitles = applicant.JobTitles.Select(x => x.Title).ToList(),
                JobTypes = applicant.JobType.Select(x => x.Name).ToList(),
                WorkPlaces = applicant.WorkPlace.Select(x => x.Name).ToList(),
                Categories = applicant.IndustryCategories.Select(x => x.Category).ToList(),
                DesiredNetSalaryPerMonth = applicant?.DesiredNetSalaryPerMonth,
                FileName = applicant?.UploadedCVFileName,
                FilePath = applicant?.UploadedCVPath
            };
        }

        public (UpdateAchievementsDTO Data, int ApplicantId) UpdateAchievements(string userId, UpdateAchievementsDTO dto)
        {
            var applicant = _applicantRepository.GetByUserId(userId);

            if (applicant == null) return (null, applicant.Id);

            applicant.Achievements = dto.Achievements;

            var upadtedApplicant = _applicantRepository.Update(applicant);

            return (new UpdateAchievementsDTO { Achievements = upadtedApplicant.Achievements, }, upadtedApplicant.Id);
        }

        public (List<UpdateOnlinePresenceDTO> Data, int ApplicantId) UpdateOnlinePresence(string userId, List<UpdateOnlinePresenceDTO> onlinePresences)
        {
            var applicant = _applicantRepository.GetByUserId(userId);
            if (applicant == null) return (null, applicant.Id);

            var _onlinePresences = onlinePresences
                .Select(op => new OnlinePresence
                {
                    AccountName = op.AccountName,
                    AccountLink = op.AccountLink,
                    ApplicantId = applicant.Id
                }).ToList();

            if (applicant.OnlinePresences is null) applicant.OnlinePresences = new List<OnlinePresence>();

            applicant.OnlinePresences.AddRange(_onlinePresences);

            var updatedApplicant = _applicantRepository.Update(applicant);

            return (
                 updatedApplicant.OnlinePresences.Select(x => new UpdateOnlinePresenceDTO { AccountLink = x.AccountLink, AccountName = x.AccountName }).ToList(),
                updatedApplicant.Id
                );
        }

        public (UpdateEducationDTO Data, int ApplicantId) UpdateEducation(string userId, UpdateEducationDTO updateEducation)
        {
            var applicant = _applicantRepository.GetByUserId(userId);
            if (applicant == null) return (null, applicant.Id);

            var universityDegrees = updateEducation.UniversityDegrees.Select(d => new UniversityDegree
            {
                DegreeLevel = d.DegreeLevel,
                Country = d.Country,
                University = d.University,
                StudyField = d.StudyField,
                StrtYear = d.StartYear,
                EndYear = d.EndYear,
                Info = d.Info,
                Grade = d.Grade,
                ApplicantId = applicant.Id
            }).ToList();

            var certifications = updateEducation.Certifications.Select(c => new Certification
            {
                Name = c.Name,
                AwardedYear = c.AwardedYear,
                AwardedMonth = c.AwardedMonth,
                OrganizationName = c.OrganizationName,
                CertificateLink = c.CertificateLink,
                CertificateID = c.CertificateID,
                AdditionalInfo = c.AdditionalInfo,
                ResultOutOfTotal = c.ResultOutOfTotal,
                ApplicantId = applicant.Id
            }).ToList();

            if (applicant.UniversityDegrees == null) applicant.UniversityDegrees = new List<UniversityDegree>();
            if (applicant.Certifications == null) applicant.Certifications = new List<Certification>();

            applicant.Certifications.AddRange(certifications);
            applicant.UniversityDegrees.AddRange(universityDegrees);

            var updatedApllicant = _applicantRepository.Update(applicant);

            return
                (
                    new UpdateEducationDTO
                    {
                        Certifications = updatedApllicant.Certifications.Select(x => new UpdateCertificationDTO
                        {
                            Name = x.Name,
                            AwardedYear = x.AwardedYear,
                            AwardedMonth = x.AwardedMonth,
                            OrganizationName = x.OrganizationName,
                            CertificateLink = x.CertificateLink,
                            CertificateID = x.CertificateID,
                            AdditionalInfo = x.AdditionalInfo,
                            ResultOutOfTotal = x.ResultOutOfTotal,
                        }).ToList(),
                        UniversityDegrees = updatedApllicant.UniversityDegrees.Select(x => new UpdateUniversityDegreeDTO
                        {
                            DegreeLevel = x.DegreeLevel,
                            StartYear = x.StrtYear,
                            EndYear = x.EndYear,
                            Country = x.Country,
                            Grade = x.Grade,
                            Info = x.Info,
                            StudyField = x.StudyField,
                            University = x.University
                        }).ToList()
                    }, updatedApllicant.Id
                );
        }

        public (UpdateSkillsDTO Data, int ApplicantId) UpdateSkills(string userId, UpdateSkillsDTO updateSkills)
        {
            var applicant = _applicantRepository.GetByUserId(userId);
            if (applicant == null) return (null, applicant.Id);

            var skills = updateSkills.Skills.Select(skill => new Skill
            {
                SkillName = skill.SkillName,
                Proficiency = skill?.Proficiency ?? 0,
                Interest = skill?.Interest ?? 0,
                YearsOfExperience = skill?.YearsOfExperience ?? 0,
                Justification = skill.Justification,
                ApplicantId = applicant.Id,
            }).ToList();
            if (applicant.Skills is null) applicant.Skills = new List<Skill>();
            applicant.Skills.AddRange(skills);
            var updatedApplicant = _applicantRepository.Update(applicant);
            return (
               new UpdateSkillsDTO
               {
                   Skills = updatedApplicant.Skills.Select(x => new SkillDTO
                   {
                       Interest = x.Interest,
                       Justification = x.Justification,
                       Proficiency = x.Proficiency,
                       SkillName = x.SkillName,
                       YearsOfExperience = x.YearsOfExperience,
                   }).ToList(),
               }, updatedApplicant.Id);
        }

        public (UpdateExperienceDTO Data, int ApplicantId) UpdateExperience(string userId, UpdateExperienceDTO updateExperience)
        {
            var applicant = _applicantRepository.GetByUserId(userId);
            if (applicant == null) return (null, applicant.Id);

            var newExperinces = updateExperience.Experiences.Select(e => new Experience
            {
                JobTitle = e.JobTitle,
                CompanyName = e.CompanyName,
                JobType = e.JobType,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                IsCurrent = e.IsCurrent,
                Description = e.Description,
                StartingSalary = e.StartingSalary,
                EndingSalary = e.EndingSalary,
                Country = e.Country,
                Achievements = e.Achievements,
                CompanySize = e.CompanySize,
                Industry = e.Industry,
                CompanyWebsite = e.CompanyWebsite,
                ApplicantId = applicant.Id
            }).ToList();
            if (applicant.Experiences is null) applicant.Experiences = new List<Experience>();
            applicant.Experiences.AddRange(newExperinces);
            var updatedApplicant = _applicantRepository.Update(applicant);
            return (
                new UpdateExperienceDTO
                {
                    Experiences = updateExperience.Experiences.Select(x => new ExperienceDTO
                    {
                        JobTitle = x.JobTitle,
                        CompanyName = x.CompanyName,
                        JobType = x.JobType,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        IsCurrent = x.IsCurrent,
                        Description = x.Description,
                        StartingSalary = x.StartingSalary,
                        EndingSalary = x.EndingSalary,
                        Country = x.Country,
                        Achievements = x.Achievements,
                        CompanySize = x.CompanySize,
                        CompanyWebsite = x.CompanyWebsite,
                        Industry = x.Industry,
                    }).ToList()
                },
                updatedApplicant.Id);
        }

        public (string FileName, string FilePath, int ApplicantId) UpdateCv(string userId, UpdateCvDTO updateCv)
        {
            var applicant = _applicantRepository.GetByUserId(userId);
            if (applicant == null) return (null, null, applicant.Id);

            var uploadsFolder = Path.Combine("UploadedCVs");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + updateCv.CvFile.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                updateCv.CvFile.CopyTo(fileStream);
            }

            applicant.UploadedCVPath = filePath;
            applicant.UploadedCVFileName = updateCv.CvFile.FileName;
            var updatedApplicant = _applicantRepository.Update(applicant);
            return (updatedApplicant.UploadedCVFileName, updatedApplicant.UploadedCVPath, updatedApplicant.Id);
        }

        public (UpdateCareerInterestDTO Data, int ApplicantId) UpdateCareerInterest(string userId, UpdateCareerInterestDTO updateCareerInterest)
        {
            var applicant = _applicantRepository.GetByUserId(userId);
            if (applicant == null) return (null, applicant.Id);

            applicant.Level = updateCareerInterest.Level;
            applicant.JobType = updateCareerInterest.JobType.Select(x => new ContractType { ApplicantId = applicant.Id, Name = x }).ToList();
            applicant.WorkPlace = updateCareerInterest.WorkPlace.Select(x => new WorkPlace { ApplicantId = applicant.Id, Name = x }).ToList();
            applicant.JobTitles = updateCareerInterest.JobTitles.Select(x => new JobTitle { ApplicantId = applicant.Id, Title = x }).ToList();
            applicant.IndustryCategories = updateCareerInterest.JobCategories.Select(x => new IndustryCategory { ApplicantId = applicant.Id, Category = x }).ToList();
            applicant.DesiredNetSalaryPerMonth = updateCareerInterest.DesiredNetSalaryPerMonth;

            var updatedApplicant = _applicantRepository.Update(applicant);

            return
                (
                 new UpdateCareerInterestDTO
                 {
                     DesiredNetSalaryPerMonth = updatedApplicant.DesiredNetSalaryPerMonth,
                     JobCategories = updatedApplicant.IndustryCategories.Select(x => x.Category).ToList(),
                     JobTitles = updatedApplicant.JobTitles.Select(x => x.Title).ToList(),
                     JobType = updatedApplicant.JobType.Select(x => x.Name).ToList(),
                     Level = updatedApplicant.Level,
                     WorkPlace = updatedApplicant.WorkPlace.Select(x => x.Name).ToList(),
                 },
                 updatedApplicant.Id
                );
        }

        public (UpdateApplicantGeneralInfoDTO Data, int ApplicantId) UpdateGenralInfo(string userId, UpdateApplicantGeneralInfoDTO applicantDto)
        {
            var applicant = _applicantRepository.GetByUserId(userId);
            applicant = UpdateInfo(applicant, applicantDto);

            var updatedApllicant = _applicantRepository.Update(applicant);

            return
                (new UpdateApplicantGeneralInfoDTO
                {
                    FirstName = updatedApllicant.User.FirstName,
                    LastName = updatedApllicant.User.LastName,
                    Area = updatedApllicant.Area,
                    AlternativeMobileNumber = updatedApllicant.AlternativeMobileNumber,
                    Birthdate = updatedApllicant.Birthdate,
                    City = updatedApllicant.City,
                    Country = updatedApllicant.Country,
                    Gender = updatedApllicant.Gender,
                    MaritalStatus = updatedApllicant.MaritalStatus,
                    MobileNumber = updatedApllicant.MobileNumber,
                    Nationality = updatedApllicant.Nationality,
                    PostalCode = updatedApllicant.PostalCode
                }, updatedApllicant.Id);
        }

        private Applicant UpdateInfo(Applicant applicant, UpdateApplicantGeneralInfoDTO applicantDto)
        {
            applicant.User.FirstName = applicantDto.FirstName;
            applicant.User.LastName = applicantDto.LastName;
            applicant.Birthdate = applicantDto.Birthdate;
            applicant.User.PhoneNumber = applicantDto.MobileNumber;
            applicant.Area = applicantDto.Area;
            applicant.Gender = applicantDto.Gender;
            applicant.Nationality = applicantDto.Nationality;
            applicant.MaritalStatus = applicantDto.MaritalStatus;
            applicant.Country = applicantDto.Country;
            applicant.City = applicantDto.City;
            applicant.Area = applicantDto.Area;
            applicant.PostalCode = applicantDto.PostalCode;
            applicant.AlternativeMobileNumber = applicantDto.AlternativeMobileNumber;

            return applicant;
        }

        public byte[] DownloadCV(string userId, string contentRootPath)
        {
            var applicant = _applicantRepository.GetByUserId(userId);
            if (applicant is null || applicant.UploadedCVPath is null) return null;
            string filePath = Path.Combine(contentRootPath, applicant.UploadedCVPath);
            var file = File.ReadAllBytes(filePath);
            return file;
        }

        public bool DeleteCV(string userId, string contentRootPath)
        {
            var applicant = _applicantRepository.GetByUserId(userId);
            if (applicant is null || applicant.UploadedCVPath is null) return false;
            string filePath = Path.Combine(contentRootPath, applicant.UploadedCVPath);
            applicant.UploadedCVPath = null;
            applicant.UploadedCVFileName =null;
            Directory.Delete(filePath, true);
            _applicantRepository.Update(applicant);
            return true;
        }
    }
}
