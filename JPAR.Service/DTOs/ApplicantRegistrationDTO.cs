using JPAR.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;

namespace JPAR.Service.DTOs
{
    public class ApplicantRegistrationDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
