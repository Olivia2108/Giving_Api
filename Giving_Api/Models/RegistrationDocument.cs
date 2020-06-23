using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Models
{
    public class RegistrationDocument
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string MemorandumOfAssociation_Path { get; set; }
        public string AlumniAssociationSetup_Path { get; set; }
        public string CAC_RegDocument_Path { get; set; }
        public string CorporateGovernanceStructure_Path { get; set; }
        public string Identification_Path { get; set; }
        public string AuthorizedSignatoryList_Path { get; set; }
        public string ValidIdentificationOfAuthorizedSignatories_Path { get; set; }
       

    }
}
