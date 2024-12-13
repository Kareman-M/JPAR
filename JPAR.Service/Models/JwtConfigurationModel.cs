namespace JPAR.Service.Models
{
    public class JwtConfigurationModel
    {
        public string AccessTokenSecret { get; set; }
        public string RefreshTokenSecret { get; set; }
        public int AccessTokenExpirationDurationMinutes { get; set; }
        public int RefreshTokenExpirationDurationMinutes { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
