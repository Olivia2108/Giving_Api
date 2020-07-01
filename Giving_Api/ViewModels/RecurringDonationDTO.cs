using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.ViewModels
{
    public class RecurringDonationDTO
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime DonationDay { get; set; }
        public string Frequency { get; set; }
        public string CauseID { get; set; }
        public string UserID { get; set; }
        public Guid DonationID { get; set; }
    }
}
