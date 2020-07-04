using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Models
{
    public class Loans
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string FirstName {get;set;}
        public string LastName { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public double  AmountRequested { get; set; }
        public string Purpose { get; set; }
        public string Tenor { get; set; }
        public string Repaymentsource { get; set; }
        public LoanDocument LoanDocument { get; set; }
        public DateTime DateCreated { get; set; }
        public string Device { get; set; }
        public string IpAddress { get; set; }
        public int TransactionType { get; set; }


    }
}
