using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPAR.Infrastructure.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
        public int Proficiency { get; set; } // 1 to 5 stars
        public int Interest { get; set; }    // 1 to 5 stars
        public string Justification { get; set; } // Optional
        public int YearsOfExperience { get; set; }
        public int ApplicantId { get; set; } // Foreign Key
        public Applicant Applicant { get; set; }
    }

}
