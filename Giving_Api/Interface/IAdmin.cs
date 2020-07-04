using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Interface
{
    public interface IAdmin
    {
        Task<object> GetDonation();
        Task<object> GetAllCause();
        Task<object> GetAllContact();
        Task<object> GetAllLoanDonor();
        Task<object> GetAllLoans();
        Task<object> GetRecurringDonation();
        Task<object> GetAllReview();
        Task<object> GetAllUserProfile();
        Task<object> GetAllVolunteer();

        Task<object> GetVolunteerById(Guid Id);
        Task<object> GetReviewsById(Guid Id);
        Task<object> GetCauseById(Guid Id);
        Task<object> GetContactById(Guid Id);
        Task<object> GetDonationById(Guid Id);
        Task<object> GetLoanDonorById(Guid Id);
        Task<object> GetLoanById(Guid Id);
        Task<object> GetRecurringDonationById(Guid Id);
        Task<object> GetAllUserProfileById(Guid Id);

        Task<object> GetCauseByUserId(Guid UserId);
        Task<object> GetContatByUserEmail(string Email);
        Task<object> GetDonationByUserEmail(string Email);
        Task<object> GetLoanDonorByUserId(Guid UserId);
        Task<object> GetLoanByUserId(Guid UserId);
        Task<object> GetReviewByUserEmail(string Email);
    }
}
