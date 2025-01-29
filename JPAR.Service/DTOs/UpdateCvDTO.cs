using Microsoft.AspNetCore.Http;

namespace JPAR.Service.DTOs
{
    public class UpdateCvDTO
    {
        public IFormFile CvFile { get; set; }
    }
}
