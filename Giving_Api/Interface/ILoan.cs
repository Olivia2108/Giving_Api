using Giving_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Interface
{
    public interface ILoan
    {
        Task<object> AddLoan(LoansDTO loansDTO, string userID);
        Task<object> GetAllLoans();
        Task<object> GetLoanById(Guid Id);
        Task<object> GetLoanByUserId(Guid UserId);
        Task<object> UpdateLoan(LoansDTO loansDTO, Guid Id);
        Task<object> DeleteLoanById(Guid Id);
    }
}
