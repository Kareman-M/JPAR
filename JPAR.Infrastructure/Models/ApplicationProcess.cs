using JPAR.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPAR.Infrastructure.Models
{
    public class ApplicationProcess : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public ProcessStage ProcessStage { get; set; }
        public int ApplicantJobId { get; set; }
        
        [ForeignKey(nameof(ApplicantJobId))]
        public ApplicantJob ApplicantJob { get; set; }
        public string Comment { get; set; }
    }
}
