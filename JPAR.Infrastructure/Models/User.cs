using JPAR.Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserType UserType { get; set; }
}