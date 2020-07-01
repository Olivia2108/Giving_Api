using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Models
{
    public class Review
    {
        [Key]
        public Guid ReviewID { get; set; }
        public string ReviewMessage { get; set; }
        public string ReviewEmail { get; set;}
        public DateTime ReviewTime { get; set; }
        public Guid CauseID { get; set; }
        public Guid UserId { get; set; }
    }
}
