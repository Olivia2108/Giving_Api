using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Security
{
    public class AuthResponse
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
