using Giving_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.ViewModels
{
    public class CauseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Donation { get; set; }
        public double TargetAmount { get; set; }
        public string BeneficiaryAddress { get; set; }
        public string BeneficiaryNumber { get; set; }
        public string Duration { get; set; }
        public string PicturePath { get; set; }
        public string VideoPath { get; set; }
        public string UserId { get; set; }
        public CauseAccount CauseBeneficiaryAccount { get; set; }
        public string ExpectedProjectImpact { get; set; }
        public DateTime DateCountDown { get; set; }
    }
}
