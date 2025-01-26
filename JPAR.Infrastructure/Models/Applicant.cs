using JPAR.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Applicant : BaseModel
{
    [Key]
    public int Id { get; set; }
    public DateTime? Birthdate { get; set; }
    public Gender? Gender { get; set; }
    public string? Nationality { get; set; }
    public MaritalStatus? MaritalStatus { get; set; }

    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Area { get; set; }
    public string? PostalCode { get; set; }

    public string? MobileNumber { get; set; }
    public string? AlternativeMobileNumber { get; set; }

    public Level? Level { get; set; }
    //Full time, part time, Freelance, internship, contract
    public JobType? JobType { get; set; }
    //onSite/ remote
    public WorkPlace? WorkPlace { get; set; }
    //List of Strings > web dev, full stack,..
    public List<string>? JobTitles { get; set; }
    //List of Strings -> IT, Marketing, Finance, HR,..
    public List<string>? JobCategories { get; set; }
    //Expected salary
    public decimal? DesiredNetSalaryPerMonth { get; set; }
    //DB stores only path of CV, not the CV itself.
    public string? UploadedCVPath { get; set; }

    public int? YearsOfExperince { get; set; }

    public List<Experience> Experiences { get; set; }

    //public List<string> Skills { get; set; }

    public List<Skill> Skills { get; set; }


    public EducationLevel? EducationLevel { get; set; }
    public List<UniversityDegree> UniversityDegrees { get; set; }
    public List<Certification> Certifications { get; set; }
    public List<OnlinePresence> OnlinePresences { get; set; }
    public string? Achievements { get; set; }

    public string UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }

    public List<Job> Jobs { get; }

}