using Giving_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Interface
{
   public  interface IContact
    {
        Task<object> UpdateContact(ContactDTO contactDTO, Guid Id);
        Task<object> DeleteContactById(Guid Id);
        Task<object> GetContactById(Guid Id);
        Task<object> GetAllContact();
        Task<object> AddContact(ContactDTO contacDTO);
        Task<object> GetContatByUserEmail(string Email);
    }
}
