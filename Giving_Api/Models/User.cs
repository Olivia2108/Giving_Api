using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Giving_Api.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string ConfirmationToken { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime DateCreated { get; set; }
        public string Device { get; set; }
        public string IpAddress { get; set; }
        public string Location { get; set; }




    }
}
