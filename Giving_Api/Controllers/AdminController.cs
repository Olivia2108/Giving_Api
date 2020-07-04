using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giving_Api.Interface;
using Giving_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Giving_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IContact _contact;
        private readonly ICause _cause;
        private readonly IVolunteer _volunteer;
        private readonly IUserProfile _userprofile;
        public readonly IRecurringDonation _recurringdonation;
        private readonly IDonation _donation;
        private readonly ILoanDonor _loandonor;
        private readonly ILoan _loan;
        private readonly IReview _review;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _accessor;

        public AdminController(IDonation donation,ILoanDonor loanDonor,IRecurringDonation recurringDonation,
            ILoan loan,IContact contact,IUserProfile userProfile,ICause cause, IReview review,IVolunteer volunteer, IConfiguration config, IHttpContextAccessor accessor)
        {
            _cause = cause;
            _recurringdonation = recurringDonation;
            _loan = loan;
            _loandonor = loanDonor;
            _volunteer = volunteer;
            _donation = donation;
            _contact = contact;
            _review = review;
            _userprofile = userProfile;
            _config = config;
            _accessor = accessor;
        }

        ServiceResponse res = new ServiceResponse();


        [HttpGet]
        [Route("AllDonation")]
        public async Task<IActionResult> GetAllDonation()
        {
            try
            {
                dynamic data = await _donation.GetDonation();

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
        [Route("AllLoanDonor")]
        public async Task<IActionResult> GetAllLoanDonor()
        {
            try
            {
                dynamic data = await _loandonor.GetAllLoanDonor();

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
        [Route("AllLoan")]
        public async Task<IActionResult> GetAllLoans()
        {
            try
            {
                dynamic data = await _loan.GetAllLoans();

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
        [Route("AllRecuringDonation")]
        public async Task<IActionResult> GetAllRecurringDonation()
        {
            try
            {
                dynamic data = await _recurringdonation.GetRecurringDonation();

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
        [Route("GetAllContact")]
        public async Task<IActionResult> GetAllContact()
        {
            try
            {
                dynamic data = await _contact.GetAllContact();

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

        [HttpGet]
        [Route("GetAllUserprofile")]
        public async Task<IActionResult> GetAllUserProfile()
        {
            try
            {
                dynamic data = await _userprofile.GetAllUserProfile();

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
        [Route("AllVolunteer")]
        public async Task<IActionResult> GetAllVolunteer()
        {
            try
            {
                dynamic data = await _volunteer.GetAllVolunteer();

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
        [Route("GetAllCauses")]
        public async Task<IActionResult> GetAllCauses()
        {
            try
            {
                dynamic data = await _cause.GetAllCause();

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


        [Route("GetCauseById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCauseById(Guid id)
        {
            try
            {

                if (id != null)
                {
                    dynamic cause = await _cause.GetCauseById(id);
                    if (cause.Success == false)
                    {
                        return NotFound(cause);
                    }

                    return Ok(cause);

                }

                return NotFound("Id field cannot be null");


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetVolunteerById/{id}")]
        public async Task<IActionResult> GetVolunteerById(Guid id)
        {
            try
            {
                if (id != null)
                {
                    dynamic volunteerById = await _volunteer.GetVolunteerById(id);
                    if (volunteerById.Success == false)
                    {
                        return NotFound(volunteerById);
                    }

                    return Ok(volunteerById);

                }

                return BadRequest("Volunteer Id cannot be null");
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        [HttpGet]
        [Route("GetContactById/{id}")]
        public async Task<IActionResult> GetContactById(Guid id)
        {
            try
            {
                if (id != null)
                {
                    dynamic reviewById = await _contact.GetContactById(id);
                    if (reviewById.Success == false)
                    {
                        return NotFound(reviewById);
                    }

                    return Ok(reviewById);

                }

                return BadRequest("Contact Id cannot be null");
            }
            catch (Exception ex)
            {

                throw;
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
        [Route("GetDonationById/{id}")]
        public async Task<IActionResult> GetDonationById(Guid id)
        {
            try
            {
                if (id != null)
                {
                    dynamic donateById = await _donation.GetDonationById(id);
                    if (donateById.Success == false)
                    {
                        return NotFound(donateById);
                    }

                    return Ok(donateById);

                }

                return BadRequest("Donation Id cannot be null");
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpGet]
        [Route("GetLoanDonorById/{id}")]
        public async Task<IActionResult> GetLoanDonorById(Guid id)
        {
            try
            {
                if (id != null)
                {
                    dynamic loanDonorById = await _loandonor.GetLoanDonorById(id);
                    if (loanDonorById.Success == false)
                    {
                        return NotFound(loanDonorById);
                    }

                    return Ok(loanDonorById);

                }

                return BadRequest("Donor's Id cannot be null");
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpGet]
        [Route("GetLoanById/{id}")]
        public async Task<IActionResult> GetLoanById(Guid id)
        {
            try
            {
                if (id != null)
                {
                    dynamic loanById = await _loan.GetLoanById(id);
                    if (loanById.Success == false)
                    {
                        return NotFound(loanById);
                    }

                    return Ok(loanById);

                }

                return BadRequest("Loan Id cannot be null");
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpGet]
        [Route("GetRecurringDonationById/{id}")]
        public async Task<IActionResult> GetRecurringDonationById(Guid id)
        {
            try
            {
                if (id != null)
                {
                    dynamic donateById = await _recurringdonation.GetRecurringDonationById(id);
                    if (donateById.Success == false)
                    {
                        return NotFound(donateById);
                    }

                    return Ok(donateById);

                }

                return BadRequest("Donation Id cannot be null");
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [Route("GetUserProfileById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfileById(Guid id)
        {
            try
            {

                if (id != null)
                {
                    dynamic userprofile = await _userprofile.GetAllUserProfileById(id);
                    if (userprofile.Success == false)
                    {
                        return NotFound(userprofile);
                    }

                    return Ok(userprofile);

                }

                return NotFound("Id field cannot be null");


            }
            catch (Exception ex)
            {

                throw;
            }
        }



        [Route("GetUserprofileByUserId/{UserId}")]
        [HttpGet]
        public async Task<IActionResult> GetUserprofileByUserId(Guid UserId)
        {
            try
            {

                if (UserId != null)
                {
                    dynamic userprofile = await _userprofile.GetUserProfileByUserId(UserId);
                    if (userprofile.Success == false)
                    {
                        return NotFound(userprofile);
                    }

                    return Ok(userprofile);

                }

                return NotFound("Id field cannot be null");


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [Route("GetCauseByUserId/{UserId}")]
        [HttpGet]
        public async Task<IActionResult> GetCauseByUserId(Guid UserId)
        {
            try
            {

                if (UserId != null)
                {
                    dynamic cause = await _cause.GetCauseByUserId(UserId);
                    if (cause.Success == false)
                    {
                        return NotFound(cause);
                    }

                    return Ok(cause);

                }

                return NotFound("Id field cannot be null");


            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [Route("GetLoanByUserId/{UserId}")]
        [HttpGet]
        public async Task<IActionResult> GetLoanByUserId(Guid UserId)
        {
            try
            {

                if (UserId != null)
                {
                    dynamic Loan = await _loan.GetLoanByUserId(UserId);
                    if (Loan.Success == false)
                    {
                        return NotFound(Loan);
                    }

                    return Ok(Loan);

                }

                return NotFound("Id field cannot be null");


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [Route("GetLoanDonorByUserId/{UserId}")]
        [HttpGet]
        public async Task<IActionResult> GetLoanDonorByUserId(Guid UserId)
        {
            try
            {

                if (UserId != null)
                {
                    dynamic Loan = await _loandonor.GetLoanDonorByUserId(UserId);
                    if (Loan.Success == false)
                    {
                        return NotFound(Loan);
                    }

                    return Ok(Loan);

                }

                return NotFound("Id field cannot be null");


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetContactByUserEmail/{Email}")]
        public async Task<IActionResult> GetContactByUserEmail(string Email)
        {
            try
            {
                dynamic data = _contact.GetContatByUserEmail(Email);

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
        [Route("GetDonationByUserEmail/{Email}")]
        public async Task<IActionResult> GetDonationByUserEmail(string Email)
        {
            try
            {
                dynamic data = _donation.GetDonationByUserEmail(Email);

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
        [Route("GetReviewByUserEmail/{Email}")]
        public async Task<IActionResult> GetReviewByUserEmail(string Email)
        {
            try
            {
                dynamic data = await _review.GetReviewByUserEmail(Email);

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

    }
}
