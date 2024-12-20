namespace JPAR.Service.DTOs
{
    public class UpdateEducationDTO
    {
        public List<UpdateUniversityDegreeDTO> UniversityDegrees {  get; set; }
        public List<UpdateCertificationDTO> Certifications {  get; set; }
    }
}