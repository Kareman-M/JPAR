using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[PrimaryKey(nameof(Number), nameof(ApplicantId))]
public class UniversityDegree
{
    public int Number { get; set; }
    public DegreeLevel DegreeLevel { get; set; }
    public string Country { get; set; }
    public string University { get; set; }
    public string StudyField { get; set; }
    public int StrtYear { get; set; }
    public int EndYear { get; set; }
    public Grade Grade { get; set; }
    public string Info { get; set; }

    public int ApplicantId { get; set; }
    [ForeignKey(nameof(ApplicantId))]
    public Applicant Applicant { get; set; }
}