using Giving_Api.Data;
using Giving_Api.Interface;
using Giving_Api.Models;
using Giving_Api.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Giving_Api.Repositories
{
    public class VolunteerRepo: IVolunteer
    {
        private readonly DataContext dataContext;

        public VolunteerRepo(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        ServiceResponse res = new ServiceResponse();


        public async Task<object> AddVolunteer(VolunteerDTO volunteerDTO, string userID)
        {
            try
            {
                var data = new Volunteer 
                {
               
                    Address = volunteerDTO.Address,
                    Comment = volunteerDTO.Comment,
                    CompanyName = volunteerDTO.CompanyName,
                    Country = volunteerDTO.Country,
                    Email = volunteerDTO.Email,
                    FirstName = volunteerDTO.FirstName,
                    Interest = volunteerDTO.Interest,
                    InterestDuration = volunteerDTO.InterestDuration,
                    LastName = volunteerDTO.LastName,
                    PhoneNumber = volunteerDTO.PhoneNumber,
                    State = volunteerDTO.State,
                    VolunteerPledge =volunteerDTO.VolunteerPledge,
                    UserId = userID,
                    DateCreated = DateTime.Now
                };
                await dataContext.AddAsync(data);
                int result = await dataContext.SaveChangesAsync();
                if (result > 0)
                {
                    res.Success = true;
                    res.Data = "Ok";
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

        public async Task<object> GetAllVolunteer()
        {
            try
            {
                var result =  dataContext.volunteers.Select(x => new Volunteer
                {
                  Address = x.Address,
                  Comment = x.Comment,
                  CompanyName = x.CompanyName,
                  Country = x.Country,
                  Email = x.Email,
                  FirstName = x.FirstName,
                  Interest = x.Interest,
                  InterestDuration = x.InterestDuration,
                  LastName = x.LastName,
                  PhoneNumber = x.PhoneNumber,
                  State = x.State,
                  VolunteerPledge = x.VolunteerPledge
                });

                var volunteerList = new VolunteerListDTO
                {
                    Volunteer  = result.ToList()
                };
                res.Data = volunteerList;
                res.Message = "List of volunteer";
                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<object> GetVolunteerById(Guid Id)
        {
            try
            {

                var result = await dataContext.volunteers.Where(p => p.Id == Id).FirstOrDefaultAsync();
                if (result == null)
                {
                    res.Data = null;
                    res.Message = "Volunteer deatils not available";
                    res.Success = false;
                    return res;
                }
                else
                {
                    res.Data = result;
                    res.Message = "Volunteer Id was successful";
                    res.Success = true;
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<object> GetVolunteerByUseId(Guid UserId)
        {
            try
            {

                var result = dataContext.volunteers.Where(x => x.UserId == UserId.ToString()).AsQueryable().Select(x => new Volunteer
                {
                   Address = x.Address,
                   Comment = x.Comment,
                   CompanyName = x.CompanyName,
                   Country = x.Country,
                   Email = x.Email,
                   FirstName = x.FirstName,
                   Interest = x.Interest,
                   InterestDuration =x.InterestDuration,
                   LastName = x.LastName,
                   PhoneNumber = x.PhoneNumber,
                   State = x.State,
                   VolunteerPledge = x.VolunteerPledge,
                   

                });
                var list = new VolunteerListDTO
                {
                    Volunteer = result.ToList()
                };

                if (list == null)
                {
                    res.Data = null;
                    res.Message = "No Volunteer user was found";
                    res.Success = false;
                    return res;
                }
                else
                {
                    res.Data = list;
                    res.Message = "List of Volunteer made by this user returned";
                    res.Success = true;
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<object> UpdateVolunteer(VolunteerDTO volunteerDTO, Guid Id)
        {
            try
            {
                var update = await dataContext.volunteers.Where(p => p.Id == Id).FirstOrDefaultAsync();
                if (update != null)
                {
                    update.Address = volunteerDTO.Address;
                    update.Comment = volunteerDTO.Comment;
                    update.CompanyName = volunteerDTO.CompanyName;
                    update.Country = volunteerDTO.Country;
                    update.Email = volunteerDTO.Email;
                    update.FirstName = volunteerDTO.FirstName;
                    update.Interest = volunteerDTO.Interest;
                    update.InterestDuration = volunteerDTO.InterestDuration;
                    update.PhoneNumber = volunteerDTO.PhoneNumber;
                    update.State = volunteerDTO.State;
                    update.VolunteerPledge = volunteerDTO.VolunteerPledge;
                    update.LastName = volunteerDTO.LastName;

                    int result = await dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        res.Success = true;
                        res.Message = "Volunteer successfully updated";
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
                    res.Message = "Volunteer id does not exist";
                    res.Data = null;
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> DeleteVolunteerById(Guid Id)
        {
            try
            {
                var delete = await dataContext.volunteers.Where(p => p.Id == Id).FirstOrDefaultAsync();
                if (delete != null)
                {
                    dataContext.Remove(delete);
                    int result = await dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        res.Success = true;
                        res.Message = "Volunteer successfully deleted";
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
                    res.Message = "Volunteer id does not exist";
                    res.Data = null;
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
