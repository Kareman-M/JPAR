namespace JPAR.Service.DTOs
{
    public class UpdateCareerInterestDTO
    {
        public Level? Level { get; set; }
        public List<JobTypeEnum> JobType { get; set; }
        public List<WorkPlaceEnum> WorkPlace { get; set; }
        public List<string> JobTitles { get; set; }
        public List<string> JobCategories { get; set; }
        public decimal? DesiredNetSalaryPerMonth { get; set; }
    }
}