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
    public class LoanDonorController : ControllerBase
    {
        private readonly ILoanDonor _loandonor;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _accessor;


        public LoanDonorController(ILoanDonor loandonor, IConfiguration config, IHttpContextAccessor accessor)
        {
            _loandonor = loandonor;
            _config = config;
            _accessor = accessor;
        }
        ServiceResponse res = new ServiceResponse();


        [HttpPost("AddLoanDonor")]
        public async Task<IActionResult> AddLoanDonor(LoanDonorDTO loanDonorDTO)
        {

            try
            {
                //var userid = _accessor.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).SingleOrDefault();

                var UserId = "B7C60175-B370-4CE4-AC86-08D81D38F5FE";
                dynamic result = await _loandonor.AddLoanDonor(loanDonorDTO, UserId);
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


        [HttpPost("UpdateLoanDonorId")]
        public async Task<IActionResult> UpdateLoanDonorId(LoanDonorDTO loanDonorDTO, Guid Id)
        {

            try
            {
                dynamic result = await _loandonor.UpdateLoanDonor(loanDonorDTO, Id);
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
        [Route("DeleteLoanDonorById/{id}")]
        public async Task<IActionResult> DeleteLoanDonorById(Guid id)
        {
            try
            {
                if (id != null)
                {
                    dynamic deleteById = await _loandonor.DeleteLoanDonorById(id);
                    if (deleteById.Success == false)
                    {
                        return NotFound(deleteById);
                    }

                    return Ok();

                }

                return BadRequest("Donor's Id cannot be null");
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
        [Route("GetTotalLoanDonor")]
        public int Calculate_Total_Number_LoanDonor() => _loandonor.GetLoanDonorCount();
    }
}
