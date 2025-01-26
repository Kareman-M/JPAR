using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[PrimaryKey(nameof(Number), nameof(ApplicantId))]
public class OnlinePresence
{
    public int Number { get; set; }
    public Social AccountName { get; set; }
    public string AccountLink { get; set; }

     public int ApplicantId { get; set; }
    [ForeignKey(nameof(ApplicantId))]
    public Applicant Applicant { get; set; }
}