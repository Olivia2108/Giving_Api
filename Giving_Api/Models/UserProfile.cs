using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Models
{
    public class UserProfile
    {
        [Key]
        public Guid Id { get; set; }
        public string PysicalAddress { get; set; }
        public string Picture { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        public string Website { get; set; }
        public bool Facebook { get; set; }
        public bool Twitter { get; set; }
        public bool Instagram { get; set; }

        [ForeignKey("RegDocumentId")]
        public RegistrationDocument RegDocument { get; set; }
        public Guid RegDocumentId { get; set; }
        public string UserID { get; set; }

    }
}
