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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CauseController : ControllerBase
    {

        private readonly ICause _cause;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _accessor;

        public CauseController(ICause cause, IConfiguration config, IHttpContextAccessor accessor)
        {
            _cause = cause;
            _config = config;
            _accessor = accessor;
        }

        ServiceResponse res = new ServiceResponse();


        
        [HttpPost("AddCause")]
        public async Task<IActionResult> AddCause(CauseDTO causeDTO)
        {
            try
            {
                //var userid = _accessor.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).SingleOrDefault();

                var userid = "36198786-9A70-4BCE-ECB1-08D8151C3370";
                dynamic result = await _cause.AddCause(causeDTO, userid);
                if (result.Success == false)
                {
                    return BadRequest(result);
                }

                return Ok(result);
                
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


        [HttpPost("UpdateCause/{Id}")]
        public async Task<IActionResult> UpdateCause(CauseDTO causeDTO, Guid Id)
        {
            try
            {
                dynamic result = await _cause.UpdateCause(causeDTO, Id);
                if (result.Success == false)
                {
                    return BadRequest(result);
                }

                return Ok(result);
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpDelete]
        [Route("DeleteCauseById/{id}")]
        public async Task<IActionResult> DeleteCauseById(Guid id)
        {
            try
            {
                if (id != null)
                {
                    dynamic deleteById = await _cause.DeleteCauseById(id);
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
