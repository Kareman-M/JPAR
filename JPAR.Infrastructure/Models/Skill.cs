using Microsoft.EntityFrameworkCore;

namespace JPAR.Infrastructure.Models
{
    [PrimaryKey(nameof(Number), nameof(ApplicantId))]
    public class Skill
    {
        public int Number { get; set; }
        public string SkillName { get; set; }
        public int Proficiency { get; set; } // 1 to 5 stars
        public int Interest { get; set; }    // 1 to 5 stars
        public string Justification { get; set; } // Optional
        public int YearsOfExperience { get; set; }
        public int ApplicantId { get; set; } // Foreign Key
        public Applicant Applicant { get; set; }
    }

}
