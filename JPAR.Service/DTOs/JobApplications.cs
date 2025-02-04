using JPAR.Infrastructure.Models;

namespace JPAR.Service.DTOs
{
    public class JobApplications
    {
        public string Title { get; set; }
        public List<string>? Categories { get; set; }
        public List<string>? JobTypes { get; set; }
        public string? WorkPlace { get; set; }
        public string Country { get; set; }
        public string CareerLevel { get; set; }
        public int MinYearsOfExperince { get; set; }
        public int MaxYearsOfExperince { get; set; }
        public decimal MinSalaryRange { get; set; }
        public decimal MaxSalaryRange { get; set; }
        public string Status { get; set; }
        public int NumberOfVecancy { get; set; }
        public string JobDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<LookUpDTO> Applicants { get; set; }
    }
}
