using JPAR.Infrastructure.Enums;

namespace JPAR.Service.DTOs
{
    public class UpdateApplicationStatusDTO
    {
        public ApplicationStatus ApplicationStatus { get; set; }
        public string Comment { get; set; }
        public int JobId { get; set; }
        public int ApplicantId { get; set; }
    }
}
