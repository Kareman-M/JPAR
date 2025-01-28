namespace JPAR.Service.DTOs
{
    public class ApplicantJobDTO
    {
        public int ApplicantId { get; set; }
        public int JobId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
    }
}
