using Giving_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Interface
{
    public interface ILoanDonor
    {
        Task<object> AddLoanDonor(LoanDonorDTO loandonorDTO, string userID);
        Task<object> GetAllLoanDonor();
        Task<object> GetLoanDonorById(Guid Id);
        Task<object> GetLoanDonorByUserId(Guid UserId);
        Task<object> UpdateLoanDonor(LoanDonorDTO loandonorDTO, Guid Id);
        Task<object> DeleteLoanDonorById(Guid Id);
        int GetLoanDonorCount();

    }
}
