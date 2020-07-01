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
    public class LoanDonorRepo:ILoanDonor
    {
        private readonly DataContext dataContext;

        public LoanDonorRepo(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        ServiceResponse res = new ServiceResponse();

        public async Task<object> AddLoanDonor(LoanDonorDTO loandonorDTO, string userID)
        {
            try
            {
                var data = new LoanDonor
                {

                    DonorAccountName = loandonorDTO.DonorAccountName,
                    DonorAccountNumber = loandonorDTO.DonorAccountNumber,
                    ImpactInvestmentAmount = loandonorDTO.ImpactInvestmentAmount,
                    DonorBank = loandonorDTO.DonorBank,
                    DonorEmail = loandonorDTO.DonorEmail,
                    DonorFirstName = loandonorDTO.DonorFirstName,
                    DonorLastName = loandonorDTO.DonorLastName,
                    DonorLocation = loandonorDTO.DonorLocation,
                    DonorPhoneNumber = loandonorDTO.DonorPhoneNumber,
                    EcoFriendlyPurpose = loandonorDTO.EcoFriendlyPurpose,
                    LoanDonorDocuments = loandonorDTO.LoanDonorDocuments,
                    Options = loandonorDTO.Options,
                    PurposePreferred = loandonorDTO.PurposePreferred,
                    Tenor = loandonorDTO.Tenor,
                    UserId = userID
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

        public async Task<object> GetAllLoanDonor()
        {
            try
            {
                var result = dataContext.LoanDonors.Select(x => new LoanDonor
                {
                    DonorAccountName = x.DonorAccountName,
                    DonorAccountNumber = x.DonorAccountNumber,
                    ImpactInvestmentAmount = x.ImpactInvestmentAmount,
                    DonorBank = x.DonorBank,
                    DonorEmail = x.DonorEmail,
                    DonorFirstName =x.DonorFirstName,
                    DonorLastName = x.DonorLastName,
                    DonorLocation = x.DonorLocation,
                    DonorPhoneNumber = x.DonorPhoneNumber,
                    EcoFriendlyPurpose = x.EcoFriendlyPurpose,
                    LoanDonorDocuments = x.LoanDonorDocuments,
                    Options = x.Options,
                    PurposePreferred = x.PurposePreferred,
                    Tenor = x.Tenor

                });

                var LoanDonorList = new LoanDonorListDTO
                {
                    LoanDonors = result.ToList()
                };
                res.Data = LoanDonorList;
                res.Message = "List of LoanDonors";
                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<object> GetLoanDonorById(Guid Id)
        {
            try
            {

                var result = await dataContext.LoanDonors.Where(p => p.Id == Id).FirstOrDefaultAsync();
                if (result == null)
                {
                    res.Data = null;
                    res.Message = "Loan's Donor details not available";
                    res.Success = false;
                    return res;
                }
                else
                {
                    res.Data = result;
                    res.Message = "Loan's Donor Id does not exist";
                    res.Success = true;
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<object> GetLoanDonorByUserId(Guid UserId)
        {
            try
            {

                var result = dataContext.LoanDonors.Where(x => x.UserId == UserId.ToString()).Include(p => p.LoanDonorDocuments).AsQueryable().Select(x => new LoanDonor
                {
                    DonorAccountName = x.DonorAccountName,
                    DonorAccountNumber = x.DonorAccountNumber,
                    ImpactInvestmentAmount = x.ImpactInvestmentAmount,
                    DonorBank = x.DonorBank,
                    DonorEmail = x.DonorEmail,
                    DonorFirstName = x.DonorFirstName,
                    DonorLastName = x.DonorLastName,
                    DonorLocation = x.DonorLocation,
                    DonorPhoneNumber = x.DonorPhoneNumber,
                    EcoFriendlyPurpose = x.EcoFriendlyPurpose,
                    LoanDonorDocuments = x.LoanDonorDocuments,
                    Options = x.Options,
                    PurposePreferred = x.PurposePreferred,
                    Tenor = x.Tenor,
                    UserId = x.UserId
                });

                var loanDonorList = new LoanDonorListDTO
                {
                    LoanDonors = result.ToList()
                };
                res.Data = loanDonorList;
                res.Message = "List of Donors For this user found";
                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<object> UpdateLoanDonor(LoanDonorDTO loandonorDTO, Guid Id)
        {
            try
            {
                var update = await dataContext.LoanDonors.Where(p => p.Id == Id).FirstOrDefaultAsync();
                if (update != null)
                {

              
                    update.DonorAccountName = loandonorDTO.DonorAccountName;
                    update.DonorAccountNumber = loandonorDTO.DonorAccountNumber;
                    update.DonorBank = loandonorDTO.DonorBank;
                    update.DonorEmail = loandonorDTO.DonorEmail;
                    update.ImpactInvestmentAmount = loandonorDTO.ImpactInvestmentAmount;
                    update.LoanDonorDocuments = loandonorDTO.LoanDonorDocuments;
                    update.Options = loandonorDTO.Options;
                    update.PurposePreferred = loandonorDTO.PurposePreferred;
                    update.Tenor = loandonorDTO.Tenor;
                    update.EcoFriendlyPurpose = loandonorDTO.EcoFriendlyPurpose;
                    update.DonorPhoneNumber = loandonorDTO.DonorPhoneNumber;
                    update.DonorLocation = loandonorDTO.DonorLocation;
                    update.DonorLastName = loandonorDTO.DonorLastName;
                    update.DonorFirstName = loandonorDTO.DonorFirstName;
                    update.DonorEmail = loandonorDTO.DonorEmail;
                    update.DonorBank = loandonorDTO.DonorBank;
                    
                   

                    int result = await dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        res.Success = true;
                        res.Message = "Donor's record has been successfully updated";
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
                    res.Message = "Donor id does not exist";
                    res.Data = null;
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> DeleteLoanDonorById(Guid Id)
        {
            try
            {
                var delete = await dataContext.LoanDonors.Where(p => p.Id == Id).FirstOrDefaultAsync();
                if (delete != null)
                {
                    dataContext.Remove(delete);
                    int result = await dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        res.Success = true;
                        res.Message = "Donor successfully deleted";
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
                    res.Message = "Donor's id does not exist";
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
