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

        public ApplicantDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAchievements(string userId, UpdateAchievementsDTO achievements)
        {
            var applicant = _applicantRepository.GetByUserId(userId);
            if (applicant == null) return false;

            applicant.Achievements = achievements.Achievements;

            return _applicantRepository.Update(applicant);
        }

        public bool UpdateOnlinePresence(string userId, List<UpdateOnlinePresenceDTO> onlinePresences)
        {
            var applicant = _applicantRepository.GetByUserId(userId);
            if (applicant == null) return false;

            var _onlinePresences = onlinePresences
                .Select(op => new OnlinePresence
                {
                    AccountName = Enum.TryParse<Social>(op.AccountName, true, out var account)
                                  ? account
                                  : Social.Other, 
                    AccountLink = op.AccountLink,
                    ApplicantId = applicant.Id
                }).ToList();

            if(applicant.OnlinePresences is null) applicant.OnlinePresences = new List<OnlinePresence>();

            applicant.OnlinePresences.AddRange(_onlinePresences);

            return _applicantRepository.Update(applicant);
        }

        public bool UpdateEducation(string userId, UpdateEducationDTO updateEducation)
        {
            var applicant = _applicantRepository.GetByUserId(userId);
            if (applicant == null) return false;

            var universityDegrees = updateEducation.UniversityDegrees.Select(d => new UniversityDegree
            {
                DegreeLevel = d.DegreeLevel,
                Country = d.Country,
                University = d.University,
                StudyField = d.StudyField,
                StrtYear = d.StartYear,
                EndYear = d.EndYear,
                Info = d.Info,
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
                ResultOutOfTotal =c.ResultOutOfTotal,
                ApplicantId = applicant.Id
            }).ToList();

            if (applicant.UniversityDegrees == null) applicant.UniversityDegrees = new List<UniversityDegree>();
            if (applicant.Certifications == null) applicant.Certifications = new List<Certification>();

            applicant.Certifications.AddRange(certifications);
            applicant.UniversityDegrees.AddRange(universityDegrees);

            return _applicantRepository.Update(applicant);
        }

        public bool UpdateSkills(string userId ,UpdateSkillsDTO updateSkills)
        {
            var applicant = _applicantRepository.GetByUserId(userId);
            if (applicant == null) return false;

            var skills = updateSkills.Skills.Select(skill => new Skill
            {
                SkillName = skill.SkillName,
                Proficiency = skill.Proficiency,
                Interest = skill.Interest,
                YearsOfExperience = skill.YearsOfExperience,
                Justification = skill.Justification,
                ApplicantId = applicant.Id,
            }).ToList();
            if (applicant.Skills is null) applicant.Skills = new List<Skill>();
            applicant.Skills.AddRange(skills);
            return _applicantRepository.Update(applicant);
        }

        public bool UpdateExperience(string userId, UpdateExperienceDTO updateExperience)
        {
            var applicant = _applicantRepository.GetByUserId(userId);
            if (applicant == null) return false;

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
            return _applicantRepository.Update(applicant);
        }

        public bool UpdateCv(string userId, UpdateCvDTO updateCv)
        {
            var applicant = _applicantRepository.GetByUserId(userId);
            if (applicant == null) return false;

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
            return _applicantRepository.Update(applicant);
        }

        public bool UpdateCareerInterest(string userId, UpdateCareerInterestDTO updateCareerInterest)
        {
            var applicant = _applicantRepository.GetByUserId(userId);

            applicant.Level = updateCareerInterest.Level;
            applicant.JobType = updateCareerInterest.JobType.Select(x=> new ContractType { ApplicantId = applicant.Id, Name = x}).ToList();
            applicant.WorkPlace = updateCareerInterest.WorkPlace.Select(x=> new WorkPlace { ApplicantId = applicant.Id, Name = x}).ToList();
            applicant.JobTitles = updateCareerInterest.JobTitles.Select(x=> new JobTitle { ApplicantId = applicant.Id, Title = x}).ToList();
            applicant.IndustryCategories = updateCareerInterest.JobCategories.Select(x=> new IndustryCategory { ApplicantId = applicant.Id, Category = x}).ToList();
            applicant.DesiredNetSalaryPerMonth = updateCareerInterest.DesiredNetSalaryPerMonth;

            return _applicantRepository.Update(applicant);
        }

        public bool UpdateGenralInfo(string userId, UpdateApplicantGeneralInfoDTO applicantDto)
        {
            var applicant = _applicantRepository.GetByUserId(userId);
            applicant = UpdateInfo(applicant, applicantDto);
            return _applicantRepository.Update(applicant);
        }

        private Applicant UpdateInfo( Applicant applicant, UpdateApplicantGeneralInfoDTO applicantDto)
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
    }
}
