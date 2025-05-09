﻿using Microsoft.IdentityModel.Tokens;

namespace JPAR.Service.DTOs
{
    public class RecruiterRegistrationDTO
    {
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string JobTitle { get; set; }
    }
}
