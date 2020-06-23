using Giving_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.ViewModels
{
    public class UserProfileDTO
    {
        public string PysicalAddress { get; set; }
        public string Picture { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        public string Website { get; set; }
        public bool Facebook { get; set; }
        public bool Twitter { get; set; }
        public bool Instagram { get; set; }
        public string UserID { get; set; }
        public RegistrationDocument RegDocument { get; set; }
        public int RegDocumentId { get; set; }

    }
}
