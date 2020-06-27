using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.ViewModels
{
    public class VolunteerDTO
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Interest { get; set; }
        public string InterestDuration { get; set; }
        public bool VolunteerPledge { get; set; }
        public string Comment { get; set; }
    }
}
