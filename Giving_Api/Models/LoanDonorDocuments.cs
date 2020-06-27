using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Models
{
    public class LoanDonorDocuments
    {
        [Key]
        public Guid Id { get; set; }
        public string registrationdocuments { get; set; }
        public string MeansOfIdentification { get; set; }
    }
}
