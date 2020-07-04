using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Models
{
    public class Cause
    {
        [Key]
        public Guid Id { get; set; }

        public string UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Donation { get; set; }
        public double TargetAmount { get; set; }
        public string BeneficiaryAddress { get; set; }
        public string BeneficiaryNumber { get; set; }
        public string Duration { get; set; }
        public string PicturePath { get; set; }
        public string VideoPath { get; set; }
        public CauseAccount CauseBeneficiaryAccount { get; set; }
        public string ExpectedProjectImpact { get; set; }
        public DateTime DateCountDown { get; set; }
        public DateTime DateCreated { get; set; }
        public string Device { get; set; }
        public string IpAddress { get; set; }
        public string Location { get; set; }
        public int TransactionType { get; set; }

    }
}
