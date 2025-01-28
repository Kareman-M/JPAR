using JPAR.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
namespace JPAR.Infrastructure.Models
{
    [PrimaryKey(nameof(ApplicantId), nameof(JobId), nameof(Stage))]
    public class ApplicationStage : BaseModel
    {
        public Stage Stage { get; set; }
        public int ApplicantId { get; set; }
        public int JobId { get; set; }
        public ApplicantJob ApplicantJob { get; set; }
        public string Comment { get; set; }
    }
}
