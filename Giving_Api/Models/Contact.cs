using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Models
{
    public class Contact
    {
        public Guid ContactID { get; set; }
        public string ContactMessage { get; set; }
        public string ContactEmail { get; set; }
        public Guid CauseId { get; set; }
        public DateTime Time { get; set; }
    }
}
