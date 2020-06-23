using Giving_Api.Models;
using Giving_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Interface
{
   public  interface IUser
    {
        Task<object> Register(RegisterDTO registerDTO);

        Task<string> ConfirmUserToken(string confirmationToken);

        Task<object> Login(LoginDTO loginDTO);
        Task<bool> IsUserExist(string EmailAddress);
    }
}
