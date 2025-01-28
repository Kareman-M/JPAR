namespace JPAR.Service.DTOs
{
    public class ApplicationDTO
    {
        public int JobId { get; set; }
        public int ApplicantId { get; set; }
        public ApplicantDTO Applicant { get; set; }
    }
}
