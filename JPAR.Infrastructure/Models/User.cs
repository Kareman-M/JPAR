using Microsoft.AspNetCore.Identity;

internal class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
