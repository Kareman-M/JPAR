using System.ComponentModel.DataAnnotations.Schema;

public class Recruiter 
{

    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}