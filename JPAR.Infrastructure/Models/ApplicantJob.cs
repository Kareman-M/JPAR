using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPAR.Infrastructure.Models
{
    public class ApplicantJob
    {
        [Key]
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        [ForeignKey(nameof(ApplicantId))]
        public Applicant Applicant { get; set; }
        public int JobPostId { get; set; }
        [ForeignKey(nameof(JobPostId))]
        public Job JobPost { get; set; }
    }
}