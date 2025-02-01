using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPAR.Service.DTOs
{
    public class UpdateSkillsDTO
    {
        public List<SkillDTO> Skills { get; set; }
    }

    public class SkillDTO
    {
        public string SkillName { get; set; }
        public int? Proficiency { get; set; } // 1 to 5
        public int? Interest { get; set; }    // 1 to 5
        public int? YearsOfExperience { get; set; }
        public string Justification { get; set; } // Optional
    }

}
