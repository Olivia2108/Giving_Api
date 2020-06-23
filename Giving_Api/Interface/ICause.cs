using Giving_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Interface
{
    public  interface ICause
    {
        Task<object> AddCause(CauseDTO causeDTO, string userID);
        Task<object> GetCauseById(Guid Id);
        Task<object> GetAllCause();
        Task<object> GetCauseByUserId(Guid UserId);
        Task<object> UpdateCause(CauseDTO causeDTO, Guid Id);
        Task<object> DeleteCauseById(Guid Id);
    }
}
