using JPAR.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Recruiter :BaseModel
{
    [Key]
    public int Id { get; set; }
    public string UserId { get; set; }
    public string CompanyName { get; set; }
    public string JobTitle { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    public List<Job> Jobs { get; set; }
}