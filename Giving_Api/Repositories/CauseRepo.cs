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
    public class CauseRepo:ICause
    {
        private readonly DataContext dataContext;

        public CauseRepo(DataContext _dataContext)
        {

            dataContext = _dataContext;
        }

        ServiceResponse res = new ServiceResponse();
        public async Task<object> AddCause(CauseDTO causeDTO, string userID)
        {
            try 
            { 
                var data = new Cause
                {
                    BeneficiaryAddress = causeDTO.BeneficiaryAddress,
                    TargetAmount = causeDTO.TargetAmount,
                    CauseBeneficiaryAccount = causeDTO.CauseBeneficiaryAccount,
                    BeneficiaryNumber = causeDTO.BeneficiaryNumber,
                    DateCountDown = causeDTO.DateCountDown,
                    Description = causeDTO.Description,
                    Donation = causeDTO.Donation,
                    Duration = causeDTO.Duration,
                    ExpectedProjectImpact = causeDTO.ExpectedProjectImpact,
                    PicturePath = causeDTO.PicturePath,
                    Title = causeDTO.Title,
                    VideoPath = causeDTO.VideoPath,
                    UserID = userID
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


        public async Task<object> GetAllCause()
        {
            try
            {

                var result = dataContext.Cause.Include(p => p.CauseBeneficiaryAccount).AsQueryable().Select(x => new Cause
                {
                    Description = x.Description,
                    BeneficiaryAddress = x.BeneficiaryAddress,
                    CauseBeneficiaryAccount = x.CauseBeneficiaryAccount,
                    TargetAmount = x.TargetAmount,
                    BeneficiaryNumber = x.BeneficiaryNumber,
                    DateCountDown = x.DateCountDown,
                    Donation = x.Donation,
                    Duration = x.Duration,
                    ExpectedProjectImpact = x.ExpectedProjectImpact,
                    PicturePath = x.PicturePath,
                    Title = x.Title,
                    VideoPath = x.VideoPath,
                    UserID = x.UserID
                });

                var causeList = new CauseListDTO
                {
                    Cause = result.ToList()
                };
                res.Data = causeList;
                res.Message = "List of cause";
                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<object> GetCauseById(Guid Id)
        {
            try
            {

                var result = await dataContext.Cause.Where(p => p.Id == Id).FirstOrDefaultAsync();
                if (result == null)
                {
                    res.Data = null;
                    res.Message = "Cause id does not exist ";
                    res.Success = false;
                    return res;
                }
                else
                {
                    res.Data = result;
                    res.Message = "Cause details gotten";
                    res.Success = true;
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public async Task<object> GetCauseByUserId(Guid UserId)
        {
            try
            {

                var result = dataContext.Cause.Where(x=>x.UserID == UserId.ToString()).Include(p => p.CauseBeneficiaryAccount).AsQueryable().Select(x => new Cause
                {
                    Description = x.Description,
                    BeneficiaryAddress = x.BeneficiaryAddress,
                    CauseBeneficiaryAccount = x.CauseBeneficiaryAccount,
                    TargetAmount = x.TargetAmount,
                    BeneficiaryNumber = x.BeneficiaryNumber,
                    DateCountDown = x.DateCountDown,
                    Donation = x.Donation,
                    Duration = x.Duration,
                    ExpectedProjectImpact = x.ExpectedProjectImpact,
                    PicturePath = x.PicturePath,
                    Title = x.Title,
                    VideoPath = x.VideoPath,
                    UserID = x.UserID
                });

                var causeList = new CauseListDTO
                {
                    Cause = result.ToList()
                };
                res.Data = causeList;
                res.Message = "List of cause For this user found";
                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public async Task<object> UpdateCause(CauseDTO causeDTO, Guid Id)
        {
            try
            {
                var update = await dataContext.Cause.Where(p => p.Id == Id).FirstOrDefaultAsync();
                if (update != null)
                {

                    update.BeneficiaryAddress = causeDTO.BeneficiaryAddress;
                    update.TargetAmount = causeDTO.TargetAmount;
                    update.CauseBeneficiaryAccount = causeDTO.CauseBeneficiaryAccount;
                    update.BeneficiaryNumber = causeDTO.BeneficiaryNumber;
                    update.DateCountDown = causeDTO.DateCountDown;
                    update.Description = causeDTO.Description;
                    update.Donation = causeDTO.Donation;
                    update.Duration = causeDTO.Duration;
                    update.ExpectedProjectImpact = causeDTO.ExpectedProjectImpact;
                    update.PicturePath = causeDTO.PicturePath;
                    update.Title = causeDTO.Title;
                    update.VideoPath = causeDTO.VideoPath;



                    int result = await dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        res.Success = true;
                        res.Message = "Cause successfully updated";
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
                    res.Message = "Cause id does not exist";
                    res.Data = null;
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> DeleteCauseById(Guid Id)
        {
            try
            {
                var delete = await dataContext.Cause.Where(p => p.Id == Id).Include(p=> p.CauseBeneficiaryAccount).FirstOrDefaultAsync();
                if (delete != null)
                {
                    dataContext.Remove(delete);
                    int result = await dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        res.Success = true;
                        res.Message = "cause successfully deleted";
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
                    res.Message = "Cause id does not exist";
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
