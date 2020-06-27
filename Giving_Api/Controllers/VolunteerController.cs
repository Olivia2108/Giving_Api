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
    public class VolunteerController : ControllerBase
    {
        private readonly IVolunteer _volunteer;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _accessor;


        public VolunteerController(IVolunteer volunteer, IConfiguration config, IHttpContextAccessor accessor)
        {
            _volunteer = volunteer;
            _config = config;
            _accessor = accessor;
        }

        ServiceResponse res = new ServiceResponse();

        [HttpPost("AddVolunteer")]
        public async Task<IActionResult> AddVolunteer( VolunteerDTO volunteerDTO)
        {

            try
            {
                //var userid = _accessor.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).SingleOrDefault();

                var UserId = "6B42D1A9-C066-4F7F-8686-08D819F151A5";
                dynamic result = await _volunteer.AddVolunteer(volunteerDTO, UserId);
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


        [HttpPost("UpdateVolunteer/{Id}")]
        public async Task<IActionResult> UpdateVolunteer(VolunteerDTO volunteerDTO, Guid Id)
        {

            try
            {
                dynamic result = await _volunteer.UpdateVolunteer(volunteerDTO, Id);
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
        [Route("DeleteVolunteerById/{id}")]
        public async Task<IActionResult> DeleteVolunteerById(Guid id)
        {
            try
            {
                if (id != null)
                {
                    dynamic deleteById = await _volunteer.DeleteVolunteerById(id);
                    if (deleteById.Success == false)
                    {
                        return NotFound(deleteById);
                    }

                    return Ok();

                }

                return BadRequest("Volunteer Id cannot be null");
            }
            catch (Exception ex)
            {

                throw;
            }

        }



        [Route("GetVolunteerByUserId/{UserId}")]
        [HttpGet]
        public async Task<IActionResult> GetVolunteerByUserId(Guid UserId)
        {
            try
            {

                if (UserId != null)
                {
                    dynamic cause = await _volunteer.GetVolunteerByUseId(UserId);
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
    }
}
