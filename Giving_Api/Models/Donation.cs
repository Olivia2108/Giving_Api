using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Models
{
    public class Donation
    {
        [Key]
        public Guid Id { get; set; }
        public string CauseId { get; set; }
        public string UserEmail { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double Amount { get; set; }
        public int CardNumber { get; set; }
        public string AccountType { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public string Pin { get; set; }
        public bool Annonymous { get; set; }
        public string Frequency { get; set; }
    }
}
