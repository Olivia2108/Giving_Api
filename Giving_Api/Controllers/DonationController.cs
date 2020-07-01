using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Giving_Api.Interface;
using Giving_Api.Models;
using Giving_Api.Security;
using Giving_Api.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Giving_Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IDonation _donation;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _accessor;

        public DonationController(IDonation donation, IConfiguration config, IHttpContextAccessor accessor)
        {
            _donation = donation;
            _config = config;
            _accessor = accessor;
        }

        ServiceResponse res = new ServiceResponse();

        // [Authorize(Roles ="User")]
        [HttpPost("Donation/{CauseId}")]
        public async Task<IActionResult> Donation(string CauseId, DonationDTO donationDTO)
        {

            try
            {
                var UserId = "B7C60175-B370-4CE4-AC86-08D81D38F5FE";
                donationDTO.UserId = UserId;
                dynamic result = await _donation.AddDonation(donationDTO, CauseId);
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
        [Route("AllDonation")]
        public async Task<IActionResult> GetAllDonation()
        {
            try
            {
                dynamic data = _donation.GetDonation();

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


        [HttpPost("UpdateDonation/{Id}")]
        public async Task<IActionResult> UpdateDonation(DonationDTO donationDTO, Guid Id)
        {

            try
            {
                dynamic result = await _donation.UpdateDonation(donationDTO, Id);
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
        [Route("DeleteDonationById/{id}")]
        public async Task<IActionResult> DeleteDonationById(Guid id)
        {
            try
            {
                if (id != null)
                {
                    dynamic deleteById = await _donation.DeleteDonationById(id);
                    if (deleteById.Success == false)
                    {
                        return NotFound(deleteById);
                    }

                    return Ok();

                }

                return BadRequest("Donation Id cannot be null");
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
