using JPAR.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPAR.Infrastructure.Models
{
    public class ApplicantJob :BaseModel
    {
        [Key]
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public int JobId { get; set; }
        public ApplicationStatus Status { get; set; }
        public string Comment { get; set; }

        [ForeignKey(nameof(ApplicantId))]
        public Applicant Applicant { get; set; }

        [ForeignKey(nameof(JobId))]
        public Job Job { get; set; }
    }
}
