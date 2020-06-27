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
    public class LoansController : ControllerBase
    {
        private readonly ILoan _loan;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _accessor;


        public LoansController(ILoan loan, IConfiguration config, IHttpContextAccessor accessor)
        {
            _loan = loan;
            _config = config;
            _accessor = accessor;
        }
        ServiceResponse res = new ServiceResponse();


        [HttpPost("AddLoan")]
        public async Task<IActionResult> AddLoan( LoansDTO loansDTO)
        {

            try
            {
                //var userid = _accessor.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).SingleOrDefault();

                var UserId = "6B42D1A9-C066-4F7F-8686-08D819F151A5";
                dynamic result = await _loan.AddLoan(loansDTO, UserId);
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


        [HttpPost("UpdateLoan/{Id}")]
        public async Task<IActionResult> UpdateLoan(LoansDTO loansDTO, Guid Id)
        {

            try
            {
                dynamic result = await _loan.UpdateLoan(loansDTO, Id);
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
        [Route("DeleteLoanById/{id}")]
        public async Task<IActionResult> DeleteLoanById(Guid id)
        {
            try
            {
                if (id != null)
                {
                    dynamic deleteById = await _loan.DeleteLoanById(id);
                    if (deleteById.Success == false)
                    {
                        return NotFound(deleteById);
                    }

                    return Ok();

                }

                return BadRequest("Loan Id cannot be null");
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
    }
}
