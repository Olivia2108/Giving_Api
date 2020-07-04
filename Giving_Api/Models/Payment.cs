using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Models
{
    public class Payment
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string CauseID { get; set; }
        public string DonationId { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string GroupCode { get; set; }
        public string Device { get; set; }
        public string IpAddress { get; set; }
        public string Location { get; set; }
        public int TransactionType { get; set; }

    }
}
