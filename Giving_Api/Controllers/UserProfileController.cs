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
    public class UserProfileController : ControllerBase
    {

        private readonly IUserProfile _userprofile;
        private readonly IDocs _docs;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _accessor;


        public UserProfileController(IUserProfile userProfile, IConfiguration config, IHttpContextAccessor accessor, IDocs docs)
        {
            _userprofile = userProfile;
            _config = config;
            _accessor = accessor;
            _docs = docs;
        }

        [HttpPost("AddUserprofile")]
        public async Task<IActionResult> AddUserprofile(UserProfileDTO userprofileDTO)
        {
            try
            {
                //var userid = _accessor.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).SingleOrDefault();

                var userid = "36198786-9A70-4BCE-ECB1-08D8151C3370";

                var result = await _userprofile.AddUserProfile(userprofileDTO);
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


        [HttpPost("UpdateUserprofile/{Id}")]
        public async Task<IActionResult> UpdateUserprofile(UserProfileDTO userprofileDTO, Guid Id)
        {
            try
            {
                dynamic result = await _userprofile.UpdateUserProfile(userprofileDTO, Id);
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
        [Route("DeleteUserprofileById/{id}")]
        public async Task<IActionResult> DeleteUserprofileById(Guid id)
        {
            try
            {
                if (id != null)
                {
                    dynamic deleteById = await _userprofile.DeleteUserProfileById(id);
                    if (deleteById.Success == false)
                    {
                        return NotFound(deleteById);
                    }

                    return Ok();

                }

                return BadRequest("Profile Id cannot be null");
            }
            catch (Exception ex)
            {

                throw;
            }

        }

    }
}
