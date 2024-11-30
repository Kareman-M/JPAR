using System.ComponentModel.DataAnnotations;

namespace JPAR.Service.DTOs
{
    public class UpdateApplicantGeneralInfoDTO
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public MaritalStatus MaritalStatus { get; set; } 
        public string Country { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string PostalCode { get; set; }
        public string MobileNumber { get; set; }
        public string AlternativeMobileNumber { get; set; }
    }
}
