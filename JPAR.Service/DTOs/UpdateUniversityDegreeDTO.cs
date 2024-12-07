using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPAR.Service.DTOs
{
    public class UpdateUniversityDegreeDTO
    {
        public int? Id { get; set; }
        public DegreeLevel DegreeLevel { get; set; }
        public string Country { get; set; }
        public string University { get; set; }
        public string StudyField { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public Grade Grade { get; set; }
        public string Info { get; set; }
    }
}
