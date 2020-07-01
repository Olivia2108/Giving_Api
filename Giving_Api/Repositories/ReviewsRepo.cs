using Giving_Api.Data;
using Giving_Api.Interface;
using Giving_Api.Models;
using Giving_Api.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Repositories
{
    public class ReviewsRepo:IReview
    {
        private readonly DataContext dataContext;

        public ReviewsRepo(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        ServiceResponse res = new ServiceResponse();

        public async Task<object> AddReview(ReviewDTO reviewDTO, string userID)
        {
            try
            {
                var data = new Review
                {
                    ReviewEmail = reviewDTO.ReviewEmail,
                    CauseID = reviewDTO.CauseID,
                    ReviewID = reviewDTO.ReviewID,
                    ReviewMessage = reviewDTO.ReviewMessage,
                    ReviewTime = reviewDTO.ReviewTime,
                    UserId = reviewDTO.UserId
                  
                };
                await dataContext.AddAsync(data);
                int result = await dataContext.SaveChangesAsync();
                if (result > 0)
                {
                    res.Success = true;
                    res.Data = data;
                    return res;
                }
                else
                {
                    res.Success = false;
                    res.Message = "Db Error";
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> GetAllReview()
        {
            try
            {
                var result = dataContext.reviews.Select(x => new Review
                {

                    ReviewEmail = x.ReviewEmail,
                    CauseID = x.CauseID,
                    ReviewID = x.ReviewID,
                    ReviewMessage = x.ReviewMessage,
                    ReviewTime = x.ReviewTime,
                    UserId = x.UserId,
                    

                });

                var ReviewListDTO = new ReviewListDTO
                {
                    Reviews = result.ToList()
                };
                res.Data = ReviewListDTO;
                res.Message = "List of Reviews";
                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<object> GetReviewsById(Guid Id)
        {
            try
            {

                var result = await dataContext.reviews.Where(p => p.ReviewID == Id).FirstOrDefaultAsync();
                if (result == null)
                {
                    res.Data = null;
                    res.Message = "Review details not available";
                    res.Success = false;
                    return res;
                }
                else
                {
                    res.Data = result;
                    res.Message = "Review Id does not exist";
                    res.Success = true;
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<object> GetReviewByUserEmail(string Email)
        {
            try
            {

                var result = dataContext.reviews.Where(x => x.ReviewEmail == Email.ToString()).AsQueryable().Select(x => new Review
                {

                    CauseID = x.CauseID,
                    ReviewEmail = x.ReviewEmail,
                    ReviewMessage = x.ReviewMessage,
                    ReviewTime = x.ReviewTime,
                    UserId = x.UserId

                });
                var list = new ReviewListDTO
                {
                    Reviews = result.ToList()
                };

                if (list == null)
                {
                    res.Data = null;
                    res.Message = "No Review found by this user was found";
                    res.Success = false;
                    return res;
                }
                else
                {
                    res.Data = list;
                    res.Message = "List of Review made by this user returned";
                    res.Success = true;
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<object> DeleteReviewById(Guid Id)
        {
            try
            {
                var delete = await dataContext.reviews.Where(p => p.ReviewID == Id).FirstOrDefaultAsync();
                if (delete != null)
                {
                    dataContext.Remove(delete);
                    int result = await dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        res.Success = true;
                        res.Message = "Review successfully deleted";
                        res.Data = delete;
                        return res;
                    }
                    else
                    {
                        res.Success = false;
                        res.Message = "Db Error";
                        return res;
                    }
                }
                else
                {
                    res.Success = false;
                    res.Message = "Review's id does not exist";
                    res.Data = null;
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> UpdateReview(ReviewDTO reviewDTO, Guid Id)
        {
            try
            {
                var update = await dataContext.reviews.Where(p => p.ReviewID== Id).FirstOrDefaultAsync();
                if (update != null)
                {
                    update.ReviewEmail = reviewDTO.ReviewEmail;
                    update.ReviewMessage = reviewDTO.ReviewMessage;
                    update.ReviewTime = reviewDTO.ReviewTime;
                   
                    int result = await dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        res.Success = true;
                        res.Message = "Review's record has been successfully updated";
                        res.Data = update;
                        return res;
                    }
                    else
                    {
                        res.Success = false;
                        res.Message = "Db Error";
                        return res;
                    }
                }
                else
                {
                    res.Success = false;
                    res.Message = "Review's id does not exist";
                    res.Data = null;
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

    }
}
