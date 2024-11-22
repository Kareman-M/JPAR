using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OnlinePresence
{
    [Key]
    public int Id { get; set; }
    public Social AccountName { get; set; }
    public string AccountLink { get; set; }

     public int ApplicantId { get; set; }
    [ForeignKey(nameof(ApplicantId))]
    public Applicant Applicant { get; set; }
}