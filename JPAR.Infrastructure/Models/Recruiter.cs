using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Recruiter 
{
    [Key]
    public int Id { get; set; }
    public string UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}