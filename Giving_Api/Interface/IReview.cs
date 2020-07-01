using Giving_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Interface
{
    public interface IReview
    {
        Task<object> UpdateReview(ReviewDTO reviewDTO, Guid Id);
        Task<object> DeleteReviewById(Guid Id);
        Task<object> GetReviewsById(Guid Id);
        Task<object> GetReviewByUserEmail(string Email);
        Task<object> GetAllReview();
        Task<object> AddReview(ReviewDTO reviewDTO, string userID);
    }
}
