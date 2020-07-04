using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Models
{
    public class GroupCollection
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public Guid GroupCode { get; set; }
        public DateTime DateCreated { get; set; }
        public string Device { get; set; }
        public string IpAddress { get; set; }
        public string Location { get; set; }
        public int TransactionType { get; set; }

    }
}
