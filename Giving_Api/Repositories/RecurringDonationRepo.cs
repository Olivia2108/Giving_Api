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
    public class RecurringDonationRepo:IRecurringDonation
    {
        private readonly DataContext dataContext;

        public RecurringDonationRepo(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        ServiceResponse res = new ServiceResponse();
     
        public async Task<object> GetRecurringDonation()
        {
            try
            {
                var result = dataContext.recurringDonations.Select(x => new RecurringDonations
                {
                    DonationDay = x.DonationDay,
                    Email = x.Email,
                    FullName = x.FullName,
                    Frequency = x.Frequency,
                    UserID = x.UserID,
                    DonationID = x.DonationID, 
                    CauseID = x.CauseID

                });

                var recurringdonationList = new RecurringDonationListDTO
                {
                    RecurringDonations = result.ToList()
                };
                res.Data = recurringdonationList;
                res.Message = "List of Recuringdonation";
                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<object> AddRecurringDonation(RecurringDonationDTO recurringDonationDTO)
        {
            try
            {
                var data = new RecurringDonations
                {

                    CauseID = recurringDonationDTO.CauseID,
                   DonationDay = recurringDonationDTO.DonationDay,
                   DonationID = recurringDonationDTO.DonationID,
                   Email = recurringDonationDTO.Email,
                   Frequency = recurringDonationDTO.Frequency,
                   FullName = recurringDonationDTO.FullName,
                   UserID = recurringDonationDTO.UserID,
                    DateCreated = DateTime.Now,
                    ModifiedDate = DateTime.Now


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

        public async Task<object> GetRecurringDonationById(Guid Id)
        {
            try
            {

                var result = await dataContext.recurringDonations.Where(p => p.RecurringDonationID == Id).FirstOrDefaultAsync();
                if (result == null)
                {
                    res.Data = null;
                    res.Message = "RecurringDonation deatils not gotten";
                    res.Success = false;
                    return res;
                }
                else
                {
                    res.Data = result;
                    res.Message = "RecurringDonation Id Found";
                    res.Success = true;
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<object> UpdateRecurringDonation(RecurringDonationDTO recurringdonationDTO, Guid Id)
        {
            try
            {
                var update = await dataContext.recurringDonations.Where(p => p.RecurringDonationID == Id).FirstOrDefaultAsync();
                if (update != null)
                {

                    update.DonationDay = recurringdonationDTO.DonationDay;
                    update.CauseID = recurringdonationDTO.CauseID;
                    update.DonationID = recurringdonationDTO.DonationID;
                    update.Email = recurringdonationDTO.Email;
                    update.Frequency = recurringdonationDTO.Frequency;
                    update.FullName = recurringdonationDTO.FullName;
                    update.UserID = recurringdonationDTO.UserID;

                    int result = await dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        res.Success = true;
                        res.Message = "RecurringDonation successfully updated";
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
                    res.Message = "RecurringDonation id does not exist";
                    res.Data = null;
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> DeleteRecurringDonationById(Guid Id)
        {
            try
            {
                var delete = await dataContext.recurringDonations.Where(p => p.RecurringDonationID == Id).FirstOrDefaultAsync();
                if (delete != null)
                {
                    dataContext.Remove(delete);
                    int result = await dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        res.Success = true;
                        res.Message = "RecurringDonation successfully deleted";
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
                    res.Message = "RecurringDonation id does not exist";
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
