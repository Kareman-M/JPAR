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
        public List<Experience> Experiences { get; set; }
        public List<Skill> Skills { get; set; }
        public string EducationLevel { get; set; }
        public List<UniversityDegree> UniversityDegrees { get; set; }
        public List<Certification> Certifications { get; set; }
        public List<OnlinePresence> OnlinePresences { get; set; }
        public string? Achievements { get; set; }
        public List<ApplicationStage> ApplicationStages { get; set; }
    }
}
