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

        public bool UpdateAchievements(UpdateAchievementsDTO achievements)
        {
            var applicant = _applicantRepository.GetByUserId(achievements.UserId);
            if (applicant == null) return false;

            applicant.Achievements = achievements.Achievements;

            return _applicantRepository.Update(applicant);
        }


        public bool UpdateOnlinePresence(string userId, List<UpdateOnlinePresenceDTO> onlinePresences)
        {
            var applicant = _applicantRepository.GetByUserId(userId);
            if (applicant == null) return false;

            // Clear existing online presences
            applicant.OnlinePresences.Clear();

            // Map new online presences
            applicant.OnlinePresences = onlinePresences
                .Where(op => !string.IsNullOrEmpty(op.AccountName)) // Skip if AccountName is null or empty
                .Select(op => new OnlinePresence
                {
                    Id = op.Id ?? 0,
                    AccountName = Enum.TryParse<Social>(op.AccountName, true, out var account)
                                  ? account
                                  : Social.Other, // Use 'Other' or a default enum value
                    AccountLink = op.AccountLink // Allow null or empty links
                }).ToList();

            return _applicantRepository.Update(applicant);
        }


        public bool UpdateEducation(UpdateEducationDTO updateEducation, string userId)
        {
            var applicant = _applicantRepository.GetByUserId(userId);
            if (applicant == null) return false;

            // Update University Degrees
            applicant.UniversityDegrees.Clear();
            applicant.UniversityDegrees = updateEducation.UniversityDegrees.Select(d => new UniversityDegree
            {
                Id = d.Id ?? 0,
                DegreeLevel = d.DegreeLevel,
                Country = d.Country,
                University = d.University,
                StudyField = d.StudyField,
                StrtYear = d.StartYear,
                EndYear = d.EndYear,
                Info = d.Info
            }).ToList();

            // Update Certifications
            applicant.Certifications.Clear();
            applicant.Certifications = updateEducation.Certifications.Select(c => new Certification
            {
                Id = c.Id ?? 0,
                Name = c.Name,
                AwardedYear = c.AwardedYear,
                AwardedMonth = c.AwardedMonth,
                OrganizationName = c.OrganizationName,
                CertificateLink = c.CertificateLink,
                CertificateID = c.CertificateID,
                AdditionalInfo = c.AdditionalInfo
            }).ToList();

            return _applicantRepository.Update(applicant);
        }


        public bool UpdateSkills(UpdateSkillsDTO updateSkills)
        {
            var applicant = _applicantRepository.GetByUserId(updateSkills.UserId);
            if (applicant == null) return false;

            // Clear and update skills (optional approach)
            applicant.Skills.Clear();
            applicant.Skills = updateSkills.Skills.Select(skill => new Skill
            {
                Id = skill.Id ?? 0, // Use 0 for new skills
                SkillName = skill.SkillName,
                Proficiency = skill.Proficiency,
                Interest = skill.Interest,
                YearsOfExperience = skill.YearsOfExperience,
                Justification = skill.Justification
            }).ToList();

            return _applicantRepository.Update(applicant);
        }


        public bool UpdateExperience(UpdateExperienceDTO updateExperience)
        {
            var applicant = _applicantRepository.GetByUserId(updateExperience.UserId);
            if (applicant == null) return false;

            // Clear existing experiences (optional)
            applicant.Experiences.Clear();

            // Map new experiences
            applicant.Experiences = updateExperience.Experiences.Select(e => new Experience
            {
                Id = e.Id ?? 0,
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
                CompanyWebsite = e.CompanyWebsite
            }).ToList();

            return _applicantRepository.Update(applicant);
        }


        public bool UpdateCv(UpdateCvDTO updateCv)
        {
            var applicant = _applicantRepository.GetByUserId(updateCv.UserId);
            if (applicant == null) return false;

            // Define the path to store the CV
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

            // Update the CV path in the database
            applicant.UploadedCVPath = filePath;
            return _applicantRepository.Update(applicant);
        }

        public bool UpdateCareerInterest(UpdateCareerInterestDTO updateCareerInterest)
        {
            var applicant = _applicantRepository.GetByUserId(updateCareerInterest.UserId);

            applicant.Level = updateCareerInterest.Level;
            applicant.JobType = updateCareerInterest.JobType;
            applicant.WorkPlace = updateCareerInterest.WorkPlace;
            applicant.JobTitles = updateCareerInterest.JobTitles;
            applicant.JobCategories = updateCareerInterest.JobCategories;
            applicant.DesiredNetSalaryPerMonth = updateCareerInterest.DesiredNetSalaryPerMonth;

            return _applicantRepository.Update(applicant);

        }

        public bool UpdateGenralInfo(UpdateApplicantGeneralInfoDTO applicantDto)
        {
            var applicant = _applicantRepository.GetByUserId(applicantDto.UserId);
            applicant = UpdateInfo(applicant, applicantDto);
            return _applicantRepository.Update(applicant);
        }

        private Applicant UpdateInfo(Applicant applicant, UpdateApplicantGeneralInfoDTO applicantDto)
        {

            applicant.User.FirstName = applicantDto.FirstName;
            applicant.User.LastName = applicantDto.LastName;
            applicant.Birthdate = applicantDto.Birthdate;
            applicant.Area = applicantDto.Area;
            applicant.Gender = applicantDto.Gender;

            return applicant;
        }
    }

}
