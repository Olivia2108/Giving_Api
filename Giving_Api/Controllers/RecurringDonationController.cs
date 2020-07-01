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
    public class RecurringDonationController : ControllerBase
    {
        private readonly IRecurringDonation _recurringdonation;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _accessor;

        public RecurringDonationController(IRecurringDonation recurringdonation, IConfiguration config, IHttpContextAccessor accessor)
        {
            _recurringdonation = recurringdonation;
            _config = config;
            _accessor = accessor;
        }

        ServiceResponse res = new ServiceResponse();

        // [Authorize(Roles ="User")]
        [HttpPost("RecurringDonation")]
        public async Task<IActionResult> RecurringDonation(RecurringDonationDTO RecurringdonationDTO)
        {

            try
            {
                var UserId = "6B42D1A9-C066-4F7F-8686-08D819F151A5";
                dynamic result = await _recurringdonation.AddRecurringDonation(RecurringdonationDTO);
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

        [HttpGet]
        [Route("AllRecuuringDonation")]
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


        [HttpPost("UpdateRecurringDonation/{Id}")]
        public async Task<IActionResult> UpdateRecurringDonation(RecurringDonationDTO recurringdonationDTO, Guid Id)
        {

            try
            {
                dynamic result = await _recurringdonation.UpdateRecurringDonation(recurringdonationDTO, Id);
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
        [Route("DeleteRecurringDonationById/{id}")]
        public async Task<IActionResult> DeleteRecurringDonationById(Guid id)
        {
            try
            {
                if (id != null)
                {
                    dynamic deleteById = await _recurringdonation.DeleteRecurringDonationById(id);
                    if (deleteById.Success == false)
                    {
                        return NotFound(deleteById);
                    }

                    return Ok();

                }

                return BadRequest("RecurringDonation Id cannot be null");
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
