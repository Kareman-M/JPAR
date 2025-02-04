using JPAR.Infrastructure.Enums;
using JPAR.Infrastructure.Models;

namespace JPAR.Service.DTOs
{
    public class ApplicationStageDTO
    {
        public Stage Stage { get; set; }
        public StageStatus Status { get; set; }
        public int ApplicantId { get; set; }
        public int JobId { get; set; }
        public string Comment { get; set; }
    }
}
