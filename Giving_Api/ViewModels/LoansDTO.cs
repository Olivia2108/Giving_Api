using Giving_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.ViewModels
{
    public class LoansDTO
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public double AmountRequested { get; set; }
        public string Purpose { get; set; }
        public string Tenor { get; set; }
        public string Repaymentsource { get; set; }
        public LoanDocument LoanDocument { get; set; }
    }
}
