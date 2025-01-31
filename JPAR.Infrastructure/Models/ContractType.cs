using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPAR.Infrastructure.Models
{
    [PrimaryKey(nameof(ApplicantId), nameof(Name))]

    public class ContractType
    {
        public JobTypeEnum Name { get; set; }
        public int ApplicantId { get; set; }
        [ForeignKey(nameof(ApplicantId))]
        public Applicant Applicant { get; set; }
    }
}
