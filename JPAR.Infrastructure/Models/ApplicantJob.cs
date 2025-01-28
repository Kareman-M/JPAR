using JPAR.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPAR.Infrastructure.Models
{
    public class ApplicantJob :BaseModel
    {
        public ApplicationStatus Status { get; set; }
        public string Comment { get; set; }
        public int ApplicantId { get; set; }

        [ForeignKey(nameof(ApplicantId))]
        public Applicant Applicant { get; set; }
        public int JobId { get; set; }
        [ForeignKey(nameof(JobId))]
        public Job Job { get; set; }
        public List<ApplicationStage> ApplicationStages { get; set; }
    }
}