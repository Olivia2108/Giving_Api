using Giving_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Interface
{
    public interface IEmail
    {
        void WelcomeNewUser(User user, string emailFor = "Verification");
    }
}
