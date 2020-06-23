using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.ViewModels
{
    public class ProjectSummaryDTO
    {
        //public int Id { get; set; }
        public string Description { get; set; }
        public string TargetAmount { get; set; }
        public string BeneficiaryNumber { get; set; }
        public string BeneficiaryLocation { get; set; }
        public string QualitativeExpectedProjectImpact { get; set; }
        public string QuantitativeExpectedProjectImpact { get; set; }
        public string Duration { get; set; }
        public string BeneficiaryAccountNumber { get; set; }
        public string BeneficiaryAccountName { get; set; }
        public string BeneficiaryBank { get; set; }
        public string ImagesPath { get; set; }
        [Required(ErrorMessage = "Not more than 4minutes")]
        public string Video { get; set; }
    }
}
