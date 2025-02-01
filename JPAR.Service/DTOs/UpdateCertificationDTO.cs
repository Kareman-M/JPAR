namespace JPAR.Service.DTOs
{
    public class UpdateCertificationDTO
    {
        public string Name { get; set; }
        public int? AwardedYear { get; set; }
        public int? AwardedMonth { get; set; }
        public string OrganizationName { get; set; }
        public string ResultOutOfTotal { get; set; }
        public string CertificateLink { get; set; }
        public string CertificateID { get; set; }
        public string AdditionalInfo { get; set; }
    }

}
