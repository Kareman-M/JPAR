using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPAR.Service.DTOs
{
    public class UpdateCvDTO
    {
        public string UserId { get; set; }

       // public string UploadedCVPath { get; set; }
       //
        public IFormFile CvFile { get; set; }
    }
}
