using Giving_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.ViewModels
{
    public class LoanDonorDTO
    {
        public string UserId { get; set; }
        public string LoanId { get; set; }
        public string Options { get; set; }
        public string DonorFirstName { get; set; }
        public string DonorLastName { get; set; }
        public string DonorLocation { get; set; }
        public string DonorEmail { get; set; }
        public string DonorPhoneNumber { get; set; }
        public string EcoFriendlyPurpose { get; set; }
        public double ImpactInvestmentAmount { get; set; }
        public string PurposePreferred { get; set; }
        public string Tenor { get; set; }
        public string DonorBank { get; set; }
        public double DonorAccountNumber { get; set; }
        public string DonorAccountName { get; set; }
        public LoanDonorDocuments LoanDonorDocuments { get; set; }

    }
}
