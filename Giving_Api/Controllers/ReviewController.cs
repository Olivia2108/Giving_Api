using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giving_Api.Interface;
using Giving_Api.Models;
using Giving_Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Giving_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReview _review;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _accessor;

        public ReviewController(IReview review, IConfiguration config, IHttpContextAccessor accessor)
        {
            _review = review;
            _config = config;
            _accessor = accessor;
        }

        ServiceResponse res = new ServiceResponse();


        // [Authorize(Roles ="User")]
        [HttpPost("Review")]
        public async Task<IActionResult> AddReview(string ReviewId, ReviewDTO reviewDTO)
        {

            try
            {
                var userID = "B7C60175-B370-4CE4-AC86-08D81D38F5FE";
                dynamic result = await _review.AddReview(reviewDTO, userID);
                if (result.Success == false)
                {
                    return BadRequest(result);
                }

                return Ok(result);

            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        [HttpGet]
        [Route("GetReviewById/{id}")]
        public async Task<IActionResult> GetReviewById(Guid id)
        {
            try
            {
                if (id != null)
                {
                    dynamic reviewById = await _review.GetReviewsById(id);
                    if (reviewById.Success == false)
                    {
                        return NotFound(reviewById);
                    }

                    return Ok(reviewById);

                }

                return BadRequest("Review Id cannot be null");
            }
            catch (Exception ex)
            {

                throw;
            }

        }



        [HttpGet]
        [Route("GetReviewByUserEmail/{Email}")]
        public IActionResult GetReviewByUserEmail(string Email)
        {
            try
            {
                dynamic data = _review.GetReviewByUserEmail(Email);

                if (data.Success == false)
                {
                    return NotFound(data);
                }
                return Ok(data);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("AllReviews")]
        public async Task<IActionResult> GetAllReviews()
        {
            try
            {
                dynamic data = await _review.GetAllReview();

                if (data.Success == false)
                {
                    return NotFound(data);
                }
                return Ok(data);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("UpdateReview/{Id}")]
        public async Task<IActionResult> UpdateReview(ReviewDTO reviewDTO, Guid Id)
        {

            try
            {
                dynamic result = await _review.UpdateReview(reviewDTO, Id);
                if (result.Success == false)
                {
                    return BadRequest(result);
                }
                return Ok(result);

            }
            catch (Exception ex)
            {

                throw new Exception();
            }


        }


        [HttpDelete]
        [Route("DeleteReviewById/{id}")]
        public async Task<IActionResult> DeleteReviewById(Guid id)
        {
            try
            {
                if (id != null)
                {
                    dynamic deleteById = await _review.DeleteReviewById(id);
                    if (deleteById.Success == false)
                    {
                        return NotFound(deleteById);
                    }

                    return Ok();

                }

                return BadRequest("Review Id cannot be null");
            }
            catch (Exception ex)
            {

                throw;
            }

        }





    }
}
