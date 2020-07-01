using Giving_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Interface
{
   public interface IRecurringDonation
    {
        Task<object> DeleteRecurringDonationById(Guid Id);
        Task<object> UpdateRecurringDonation(RecurringDonationDTO recurringdonationDTO, Guid Id);
        Task<object> GetRecurringDonationById(Guid Id);
        Task<object> AddRecurringDonation(RecurringDonationDTO recurringDonationDTO);
        Task<object> GetRecurringDonation();
    }
}
