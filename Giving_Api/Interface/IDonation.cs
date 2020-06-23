using Giving_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Interface
{
   public interface IDonation
   {
        Task<object> GetDonation();
        Task<object> GetDonationById(Guid Id);
        Task<object> AddDonation(DonationDTO donationDTO, string CauseID, string UserEmail);
        Task<object> UpdateDonation(DonationDTO donationDTO, Guid Id);
        Task<object> DeleteDonationById(Guid Id);
        Task<object> GetDonationByUserEmail(string Email);
    }
}
