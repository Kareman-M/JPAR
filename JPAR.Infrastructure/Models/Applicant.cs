internal class Applicant : User
{
    public DateTime Birthdate { get; set; }
    public Gender Gender { get; set; }
    public string Nationality { get; set; }
    public MaritalStatus MaritalStatus { get; set; }

    public string Country { get; set; }
    public string City { get; set; }
    public string Area { get; set; }
    public string PostalCode { get; set; }

    public string AlternativeMobileNumber { get; set; }

    public Level Level { get; set; }
    public JobType JobType { get; set; }
    public WorkPlace WorkPlace { get; set; }
    public List<string> JobTitles { get; set; }
    public List<string> JobCategories { get; set; }
    public decimal DesiredNetSalaryPerMonth { get; set; }

    public string UploadedCVPath { get; set; }

    public int YearsOfExperince { get; set; }
    public List<string> Skills { get; set; }

    public EducationLevel EducationLevel { get; set; }
    public List<UniversityDegree> UniversityDegrees { get; set; }
    public List<Certification> Certifications { get; set; }
    public List<OnlinePresence> OnlinePresences { get; set; }
    public string Achivement { get; set; }
}