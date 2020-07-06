using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingAlertSender.Models
{
    public class RecurringDonations
    {
        [Key]
        public Guid RecurringDonationID { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime DonationDay { get; set; }
        public string Frequency { get; set; }
        public int Interval { get; set; }
        public string CauseID { get; set; }
        public string UserID { get; set; }
       public Guid DonationID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Device { get; set; }
        public string IpAddress { get; set; }
        public string Location { get; set; }
        public int TransactionType { get; set; }
        public int statusId { get; set; }

    }
}
