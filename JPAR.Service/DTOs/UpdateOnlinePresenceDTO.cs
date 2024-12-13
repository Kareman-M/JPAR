using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPAR.Service.DTOs
{
    public class UpdateOnlinePresenceDTO
    {
        public int? Id { get; set; }
        public string AccountName { get; set; }

        [Required]
        [Url]
        public string AccountLink { get; set; }
    }


}
