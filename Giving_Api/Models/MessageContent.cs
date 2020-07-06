using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Models
{
    public class MessageContent
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public int messageCode { get; set; }
        public string status { get; set; }

    }
}
