namespace JPAR.Service.DTOs
{
    public class EditJobDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<string> Categories { get; set; }
        public List<JobTypeEnum> JobTypes { get; set; }
        public WorkPlaceEnum WorkPlace { get; set; }
        public string Country { get; set; }
        public Level CareerLevel { get; set; }
        public int MinYearsOfExperince { get; set; }
        public int MaxYearsOfExperince { get; set; }
        public decimal MinSalaryRange { get; set; }
        public decimal MaxSalaryRange { get; set; }
        public bool HideSalary { get; set; }
        public string AdditinalSalaryDetails { get; set; }
        public int NumberOfVecancy { get; set; }
        public string JobDescription { get; set; }
    }
}
