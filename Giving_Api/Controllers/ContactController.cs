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
    public class ContactController : ControllerBase
    {
        private readonly IContact _contact;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _accessor;

        public ContactController(IContact contact, IConfiguration config, IHttpContextAccessor accessor)
        {
            _contact = contact;
            _config = config;
            _accessor = accessor;
        }

        ServiceResponse res = new ServiceResponse();

        // [Authorize(Roles ="User")]
        [HttpPost("AddContact")]
        public async Task<IActionResult> AddContact(string contactId, ContactDTO contactDTO)
        {

            try
            {
                var userID = "B7C60175-B370-4CE4-AC86-08D81D38F5FE";
                dynamic result = await _contact.AddContact(contactDTO);
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

        [HttpPost("UpdateContact/{Id}")]
        public async Task<IActionResult> UpdateContact(ContactDTO contactDTO, Guid Id)
        {

            try
            {
                dynamic result = await _contact.UpdateContact(contactDTO, Id);
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
        [Route("DeleteContactById/{id}")]
        public async Task<IActionResult> DeleteContactById(Guid id)
        {
            try
            {
                if (id != null)
                {
                    dynamic deleteById = await _contact.DeleteContactById(id);
                    if (deleteById.Success == false)
                    {
                        return NotFound(deleteById);
                    }

                    return Ok();

                }

                return BadRequest("Contact Id cannot be null");
            }
            catch (Exception ex)
            {

                throw;
            }

        }

    }
}
