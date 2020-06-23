using Giving_Api.Data;
using Giving_Api.Interface;
using Giving_Api.Models;
using Giving_Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Repositories
{
    public class UserRepo : IUser
    {
        private readonly DataContext _dataContext;
        private readonly IEmail _email;

        public UserRepo(DataContext dataContext, IEmail  email)
        {
            _dataContext = dataContext;
            _email = email;

        }

        ServiceResponse res = new ServiceResponse();
        public async Task<object> Register(RegisterDTO registerDTO)
        {
            try
            {

                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(registerDTO.Password, out passwordHash, out passwordSalt);
                var userObj = new User
                {

                    EmailAddress = registerDTO.EmailAddress,
                    Name = registerDTO.Name,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    PhoneNumber = registerDTO.PhoneNumber,
                    Role= "User",
                    ConfirmationToken = Guid.NewGuid().ToString().Replace("-", ""),
                    IsConfirmed = false

                };
                await _dataContext.AddAsync(userObj);
                int result = await _dataContext.SaveChangesAsync();
                if (result > 0)
                {
                    string emailFor = "Verification";
                    _email.WelcomeNewUser(userObj, emailFor);
                }
                res.Success = true;
                res.Data = userObj;
                return res;


            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<string> ConfirmUserToken(string confirmationToken)
        {
            try
            {
                var confirmUser = await _dataContext.Users.FirstOrDefaultAsync(p => p.ConfirmationToken == confirmationToken);
                if (confirmUser == null)
                {
                    return null;
                }
                else
                {
                    confirmUser.IsConfirmed = true;
                    int result = await _dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        return confirmUser.EmailAddress;
                    }
                    else
                    {

                        return res.Message = "db error";
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        public async Task<object> Login(LoginDTO loginDTO)
        {
            try
            {

                var user = await _dataContext.Users.Where(p => p.EmailAddress == loginDTO.Email).FirstOrDefaultAsync();
                if (user != null)
                {
                    user.IsConfirmed = true;
                    if (user.IsConfirmed == true)
                    {
                        if (!VerifyPasswordHash(loginDTO.Password, user.PasswordHash, user.PasswordSalt))
                        {
                            res.Message = "Invalid username or password";
                            return res;
                        }
                        else
                        {
                            res.Message = "User logged in";
                            res.Data = user;
                            res.Success = true;
                            return res;
                        }
                    }
                    else
                    {
                        res.Message = "Kindly confirm your email";
                        return res;
                    }
                }
                else
                {
                    res.Message = "User does not exist";
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
            

        }

        public async Task<bool> IsUserExist(string EmailAddress)
        {
            try
            {
                //using (DataContext db = new DataContext(DbContextOptionsBuilder<DataContext>))
                    if (await _dataContext.Users.AnyAsync(p => p.EmailAddress == EmailAddress))
                    {
                         
                        return true;
                    }
                    else
                    {
                        
                        return false;
                    }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }



        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (passwordHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (passwordSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");


            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {

                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }


                }

                return true;
            }
        }

    }
}
