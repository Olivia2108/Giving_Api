using Giving_Api.Data;
using Giving_Api.Interface;
using Giving_Api.Models;
using Giving_Api.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Repositories
{
    public class UserProfileRepo:IUserProfile
    {
        private readonly DataContext dataContext;

        public UserProfileRepo(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        ServiceResponse res = new ServiceResponse();


        public async Task<ServiceResponse> AddUserProfile(UserProfileDTO userProfileDTO)
        {
            try
            {
                var data = new UserProfile
                {
                    PysicalAddress = userProfileDTO.PysicalAddress,
                    Company = userProfileDTO.Company,
                    Country = userProfileDTO.Country,
                    Facebook = userProfileDTO.Facebook,
                    Instagram = userProfileDTO.Instagram,
                    Picture = userProfileDTO.Picture,
                    RegDocumentId = userProfileDTO.RegDocumentId,
                    State = userProfileDTO.State,
                    Twitter = userProfileDTO.Twitter,
                    Website = userProfileDTO.Website,
                    UserID = userProfileDTO.UserID,
                    DateCreated = DateTime.Now
                };
                await dataContext.AddAsync(data);
                int result = await dataContext.SaveChangesAsync();
                if (result > 0)
                {
                    res.Success = true;
                    res.Data = data;
                    return res;
                }
                else
                {
                    res.Success = false;
                    res.Message = "Db Error";
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<object> GetAllUserProfile()
        {
            try
            {

                var result = dataContext.UserProfile.Include(p =>p.RegDocument).AsQueryable().Select(x => new UserProfile
                {

                   PysicalAddress = x.PysicalAddress,
                   Company = x.Company,
                   Country = x.Country,
                   Facebook = x.Facebook,
                   Instagram = x.Instagram,
                   Picture = x.Picture,
                   RegDocument =x.RegDocument,
                   State = x.State,
                   Twitter = x.Twitter,
                   Website = x.Website,
                   UserID = x.UserID
                });

                var ProfileList = new UserProfileListDTO
                {
                    UserProfiles = result.ToList()
                };
                res.Data = ProfileList;
                res.Message = "List of Profile";
                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<object> GetAllUserProfileById(Guid Id)
        {
            try
            {

                var result = await dataContext.UserProfile.Where(p => p.Id == Id).FirstOrDefaultAsync();
                if (result == null)
                {
                    res.Data = null;
                    res.Message = "UserProfile id does not exist ";
                    res.Success = false;
                    return res;
                }
                else
                {
                    res.Data = result;
                    res.Message = "UserProfile details gotten";
                    res.Success = true;
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public async Task<object> UpdateUserProfile(UserProfileDTO userprofileDTO , Guid Id)
        {
            try
            {
                var update = await dataContext.UserProfile.Where(p => p.Id == Id).FirstOrDefaultAsync();
                if (update != null)
                {
                    update.PysicalAddress = userprofileDTO.PysicalAddress;
                    update.Company = userprofileDTO.Company;
                    update.Country = userprofileDTO.Country;
                    update.Facebook = userprofileDTO.Facebook;
                    update.Instagram = userprofileDTO.Instagram;
                    update.Twitter = userprofileDTO.Twitter;
                    update.State = userprofileDTO.State;
                    update.Website = userprofileDTO.Website;
                    update.RegDocument = userprofileDTO.RegDocument;
                    update.Picture = userprofileDTO.Picture;
                   

                    int result = await dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        res.Success = true;
                        res.Message = "UserProfile successfully updated";
                        res.Data = update;
                        return res;
                    }
                    else
                    {
                        res.Success = false;
                        res.Message = "Db Error";
                        return res;
                    }
                }
                else
                {
                    res.Success = false;
                    res.Message = "UserProfile id does not exist";
                    res.Data = null;
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<object> DeleteUserProfileById(Guid Id)
        {
            try
            {
                var delete = await dataContext.UserProfile.Where(p => p.Id == Id).Include(p => p.RegDocument).FirstOrDefaultAsync();
                if (delete != null)
                {
                    dataContext.Remove(delete);
                    int result = await dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        res.Success = true;
                        res.Message = "userprofile successfully deleted";
                        res.Data = delete;
                        return res;
                    }
                    else
                    {
                        res.Success = false;
                        res.Message = "Db Error";
                        return res;
                    }
                }
                else
                {
                    res.Success = false;
                    res.Message = "userprofile id does not exist";
                    res.Data = null;
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> GetUserProfileByUserId(Guid UserId)
        {
            try
            {

                var result = dataContext.UserProfile.Where(x => x.UserID == UserId.ToString()).Include(p => p.RegDocument).AsQueryable().Select(x => new UserProfile
                {
                    PysicalAddress =x.PysicalAddress,
                    Company = x.Company,
                    Country = x.Country,
                    Facebook = x.Facebook,
                    Instagram =x.Instagram,
                    Picture = x.Picture,
                    State = x.State,
                    Twitter = x.Twitter,
                    Website = x.Website,
                    RegDocument = x.RegDocument,
                    UserID = x.UserID
                });

                var userProfileList = new UserProfileListDTO
                {
                    UserProfiles = result.ToList()
                };
                res.Data = userProfileList;
                res.Message = "Profile for this user found";
                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }

        }


    }
}
