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
    public class DonationRepo:IDonation
    {
        private readonly DataContext dataContext;
        private readonly IRecurringDonation _recurringDonation;

        public DonationRepo(DataContext _dataContext, IRecurringDonation recurringDonation)
        {
            dataContext = _dataContext;
            _recurringDonation = recurringDonation;
        }

        ServiceResponse res = new ServiceResponse();

       
        public async Task<object> AddDonation(DonationDTO donationDTO, string CauseID)
        {
            try
            {
                if(string.IsNullOrEmpty(donationDTO.Email))
                {
                    donationDTO.Email = "Annonymous";
                }
                var data = new Donation
                {
                    Amount = donationDTO.Amount,
                    AccountType = donationDTO.AccountType,
                    Annonymous = donationDTO.Annonymous,
                    CardNumber = donationDTO.CardNumber,
                    CVV = donationDTO.CVV,
                    Email = donationDTO.Email,
                    ExpiryDate = donationDTO.ExpiryDate,
                    Name = donationDTO.Name,
                    Pin = donationDTO.Pin,
                    CauseId = CauseID,
                    UserId = donationDTO.UserId,
                    Frequency = donationDTO.Frequency,
                    DateCreated = DateTime.Now

                };
                await dataContext.AddAsync(data);
                int result = await dataContext.SaveChangesAsync();
                if (result > 0)
                {
                    if(donationDTO.Frequency != "one time")
                    {
                        var donationId = await dataContext.Donations.Where(x => x.Email == donationDTO.Email).FirstOrDefaultAsync();
                        var recurringDonation = new RecurringDonationDTO
                        {
                            CauseID = CauseID,
                            DonationDay = DateTime.Now,
                            DonationID = donationId.Id,
                            Email = donationDTO.Email,
                            Frequency = donationDTO.Frequency,
                            FullName = donationDTO.Name,
                            UserID = donationDTO.UserId

                        };
                        dynamic response = await _recurringDonation.AddRecurringDonation(recurringDonation);
                    }
                    
                   // if(response.Success == true) { }
                    //email
                    res.Success = true;
                    res.Data = "Ok";
                    res.Message = "Donation was added successful";
                    return res;
                }
                else
                {
                    //email
                    res.Success = false;
                    res.Message = "Db Error";
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<object> GetDonation()
        {
            try
            {
                var result = dataContext.Donations.Select(x => new Donation
                {
                    Annonymous = x.Annonymous,
                    Amount = x.Amount,
                    AccountType = x.AccountType,
                    CardNumber = x.CardNumber,
                    CVV = x.CVV,
                    Email = x.Email,
                    ExpiryDate = x.ExpiryDate,
                    Name = x.Name,
                    Pin = x.Pin

                });

                var donationList = new DonationListDTO
                {
                    Donation = result.ToList()
                };
                res.Data = donationList;
                res.Message = "List of donation";
                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<object> GetDonationById(Guid Id)
        {
            try
            {

                var result = await dataContext.Donations.Where(p => p.Id == Id).FirstOrDefaultAsync();
                if (result == null)
                {
                    res.Data = null;
                    res.Message = "Donation deatils not gotten";
                    res.Success = false;
                    return res;
                }
                else
                {
                    res.Data = result;
                    res.Message = "Donation Id does not exist";
                    res.Success = true;
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<object> GetDonationByUserEmail(string Email)
        {
            try
            {

                var result = dataContext.Donations.Where(x => x.Email == Email.ToString()).AsQueryable().Select(x => new Donation
                {
                    Annonymous = x.Annonymous,
                    Amount = x.Amount,
                    AccountType = x.AccountType,
                    CardNumber = x.CardNumber,
                    CVV = x.CVV,
                    Email = x.Email,
                    ExpiryDate = x.ExpiryDate,
                    Name = x.Name,
                    Pin = x.Pin

                });
                var list = new DonationListDTO
                {
                    Donation = result.ToList()
                };

                if (list == null)
                {
                    res.Data = null;
                    res.Message = "No Donation made by this user was found";
                    res.Success = false;
                    return res;
                }
                else
                {
                    res.Data = list;
                    res.Message = "List of Donations made by this user returned";
                    res.Success = true;
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<object> UpdateDonation(DonationDTO donationDTO, Guid Id)
        {
            try
            {
                var update = await dataContext.Donations.Where(p => p.Id == Id).FirstOrDefaultAsync();
                if (update != null)
                {

                    update.Amount = donationDTO.Amount;
                    update.AccountType = donationDTO.AccountType;
                    update.Annonymous = donationDTO.Annonymous;
                    update.CardNumber = donationDTO.CardNumber;
                    update.CVV = donationDTO.CVV;
                    update.Email = donationDTO.Email;
                    update.ExpiryDate = donationDTO.ExpiryDate;
                    update.Name = donationDTO.Name;
                    update.Pin = donationDTO.Pin;



                    int result = await dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        res.Success = true;
                        res.Message = "Donation successfully updated";
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
                    res.Message = "Donation id does not exist";
                    res.Data = null;
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> DeleteDonationById(Guid Id)
        {
            try
            {
                var delete = await dataContext.Donations.Where(p => p.Id == Id).FirstOrDefaultAsync();
                if (delete != null)
                {
                     dataContext.Remove(delete);
                    int result = await dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        res.Success = true;
                        res.Message = "Donation successfully deleted";
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
                    res.Message = "Donation id does not exist";
                    res.Data = null;
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int GetDonationCount() => dataContext.Donations.Count();

    }
}
