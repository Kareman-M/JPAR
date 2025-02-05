namespace JPAR.Service.DTOs
{
    public class JobDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<string>? Categories { get; set; }
        public List<string>? JobTypes { get; set; }
        public string? WorkPlace { get; set; }
        public string Country { get; set; }
        public string CareerLevel { get; set; }
        public int? MinYearsOfExperince { get; set; }
        public int? MaxYearsOfExperince { get; set; }
        public decimal? MinSalaryRange { get; set; }
        public decimal? MaxSalaryRange { get; set; }
        public bool? HideSalary { get; set; }
        public string AdditinalSalaryDetails { get; set; }
        public string Status { get; set; }
        public int? NumberOfVecancy { get; set; }
        public string JobDescription { get; set; }
        public int? RecruiterId { get; set; }
        public string CompanyName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
