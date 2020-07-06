using MessagingAlertSender.ViewModels;
using System;
using System.Threading.Tasks;

namespace MessagingAlertSender.Interface
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
