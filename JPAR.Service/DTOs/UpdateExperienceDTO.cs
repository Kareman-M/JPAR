

namespace JPAR.Service.DTOs
{
    public class UpdateExperienceDTO
    {
        public string UserId { get; set; }
        public List<ExperienceDTO> Experiences { get; set; }
    }

    public class ExperienceDTO
    {
        public int? Id { get; set; } // Null for new experiences
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public JobTypeEnum JobType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCurrent { get; set; }
        public string Description { get; set; }
        public decimal StartingSalary { get; set; }
        public decimal EndingSalary { get; set; }
        public string Country { get; set; }
        public string Achievements { get; set; }
        public string CompanySize { get; set; }
        public string Industry { get; set; }
        public string CompanyWebsite { get; set; }
    }

}
