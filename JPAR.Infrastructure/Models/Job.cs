using JPAR.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPAR.Infrastructure.Models
{
    public class Job : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public List<JobCategory> JobCategories { get; set; }
        public List<JobType> JobTypes { get; set; }
        public WorkPlaceEnum WorkPlace { get; set; }
        public string Country { get; set; }
        public Level CareerLevel { get; set; }
        public int MinYearsOfExperince { get; set; }
        public int MaxYearsOfExperince { get; set; }
        public decimal MinSalaryRange { get; set; }
        public decimal MaxSalaryRange { get; set; }
        public bool HideSalary { get; set; }
        public string AdditinalSalaryDetails { get; set; }
        public JobStatus Status { get; set; }
        public int NumberOfVecancy { get; set; }
        public string JobDescription { get; set; }
        public int RecruiterId { get; set; }

        [ForeignKey(nameof(RecruiterId))]
        public Recruiter Recruiter { get; set; }
        public List<ApplicantJob> ApplicantJobs { get; set; }
    }
}