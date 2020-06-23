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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Giving_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        private readonly IConfiguration _config;

        public UserController(IUser user,IConfiguration config)
        {
            _user = user;
            _config = config;
        }

        ServiceResponse res = new ServiceResponse();
        [HttpPost("Register")]
       public async Task<IActionResult> Register(RegisterDTO registerDTO )
        {
            if(! await _user.IsUserExist(registerDTO.EmailAddress))
            {
                dynamic result = await _user.Register(registerDTO);
                if (result.Success == false)
                {
                    return BadRequest(result);
                }

                else
                {
                    return Ok(result);
                }
            }
            else
            {
                return BadRequest("User already exists");
            }
            
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            dynamic result = await _user.Login(loginDTO);
            if (result.Success == false)
            {
                return BadRequest(result);
            }


            else
            {
                var userRole = result.Data.Role;

                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()),
                    new Claim(ClaimTypes.Name, loginDTO.Email.ToString()),
                    new Claim(ClaimTypes.Role, result.Data.Role.ToString()),
                };


                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new JwtSecurityToken
                (
                    claims: claim,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

                //var roles = user.Item1.Data.Role;
                var tokenHandler = new JwtSecurityTokenHandler();
                //var tokenDesc = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(tokenDescriptor);
                var response = new AuthResponse
                {
                    Role = userRole,
                    Token = tokenString,
                    Email = loginDTO.Email,
                    ExpiryDate = DateTime.Now.AddDays(1)
                };


                res.Data = response;
                res.Message = "Login is successful";
                res.Success = true;

                return Ok(res);
            }
        }


        [HttpPost("ConfirmUserToken/{confirmationToken}")]

        public async Task<IActionResult> ConfirmUserToken(string confirmationToken)
        {
            var result = await _user.ConfirmUserToken(confirmationToken);
            if(result == null)
            {
                return BadRequest("Invalid Token");

            }
            else
            {
                return Ok(result);
            }
        }

    }
}
