using JPAR.Infrastructure.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPAR.Service.DTOs
{
    public class ApplicantDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Gender { get; set; }
        public string? Nationality { get; set; }
        public string MaritalStatus { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Area { get; set; }
        public string? PostalCode { get; set; }
        public string? MobileNumber { get; set; }
        public string? AlternativeMobileNumber { get; set; }
        public string Level { get; set; }
        public int? YearsOfExperince { get; set; }
        public decimal? DesiredNetSalaryPerMonth { get; set; }
        public string FileName { get; init; }
        public string FilePath { get; init; }

        public List<ExperienceDTO> Experiences { get; set; }
        public List<SkillDTO> Skills { get; set; }
        public string EducationLevel { get; set; }
        public List<UniversityDegreeDTO> UniversityDegrees { get; set; }
        public List<CertificationDTO> Certifications { get; set; }
        public List<OnlinePresenceDTO> OnlinePresences { get; set; }
        public string? Achievements { get; set; }
        public List<ApplicationStageDTO> ApplicationStages { get; set; }
        public List<JobTypeEnum> JobTypes { get; set; }
        public List<WorkPlaceEnum> WorkPlaces { get; set; }
        public List<string> JobTitles { get; set; }
        public List<string> Categories { get; set; }
    }
}
