using System.ComponentModel.DataAnnotations;

namespace JPAR.Service.DTOs
{
    public class UpdateOnlinePresenceDTO
    {
        public Social AccountName { get; set; }

        [Url]
        public string AccountLink { get; set; }
    }


}
