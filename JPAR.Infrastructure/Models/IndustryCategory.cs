using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPAR.Infrastructure.Models
{
    [PrimaryKey(nameof(ApplicantId), nameof(Category))]
    public class IndustryCategory
    {
        public string Category { get; set; }
        public int ApplicantId { get; set; }
        [ForeignKey(nameof(ApplicantId))]
        public Applicant Applicant { get; set; }
    }
}
