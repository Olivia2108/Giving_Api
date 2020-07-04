using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Models
{
    public class LoanDocument
    {

        [Key]
        public Guid Id { get; set; }
        public string BusinessPlan { get; set; }
        public string CompanyRegistrationDocuments { get; set; }
        public string GuarantorLetter { get; set; }
        public string IndemnityForm { get; set; }
        public string MeansOfIdentification { get; set; }
        public string RelevantPictures { get; set; }
        public string VideoRecording { get; set; }
        public DateTime DateCreated { get; set; }
        public string Device { get; set; }
        public string IpAddress { get; set; }
        public string Location { get; set; }



    }
}
