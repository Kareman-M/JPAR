namespace JPAR.Service.DTOs
{
    public class UpdateCareerInterestDTO
    {
        public string UserId { get; set; }
        public Level Level { get; set; }
        public JobType JobType { get; set; }
        public WorkPlace WorkPlace { get; set; }
        public List<string> JobTitles { get; set; }
        public List<string> JobCategories { get; set; }
        public decimal DesiredNetSalaryPerMonth { get; set; }
     




    }
}