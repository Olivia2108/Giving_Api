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
    public class LoanRepo:ILoan
    {
        private readonly DataContext dataContext;

        public LoanRepo(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        ServiceResponse res = new ServiceResponse();

        public async Task<object> AddLoan(LoansDTO  loansDTO, string userID)
        {
            try
            {
                var data = new Loans
                {

                    AmountRequested = loansDTO.AmountRequested,
                    Email = loansDTO.Email,
                    FirstName = loansDTO.FirstName,
                    LastName = loansDTO.LastName,
                    LoanDocument = loansDTO.LoanDocument,
                    Location = loansDTO.Location,
                    PhoneNumber = loansDTO.PhoneNumber,
                    Purpose = loansDTO.Purpose,
                    Repaymentsource = loansDTO.Repaymentsource,
                    Tenor = loansDTO.Tenor,
                    UserId = userID
                };
                await dataContext.AddAsync(data);
                int result = await dataContext.SaveChangesAsync();
                if (result > 0)
                {
                    res.Message = "Saved Successful";
                    res.Success = true;
                    res.Data = "OK";
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

        public async Task<object> GetAllLoans()
        {
            try
            {
                var result = dataContext.loans.Select(x => new Loans
                {
                    AmountRequested = x.AmountRequested,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    LoanDocument = x.LoanDocument,
                    Location = x.Location,
                    PhoneNumber =x.PhoneNumber,
                    Purpose = x.Purpose,
                    Repaymentsource = x.Repaymentsource,
                    Tenor = x.Tenor,
                   
                });

                var LoanList = new LoansListDTO
                {
                    loan = result.ToList()
                };
                res.Data = LoanList;
                res.Message = "List of Loans";
                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<object> GetLoanById(Guid Id)
        {
            try
            {

                var result = await dataContext.loans.Where(p => p.Id == Id).FirstOrDefaultAsync();
                if (result == null)
                {
                    res.Data = null;
                    res.Message = "This id does not exist";
                    res.Success = false;
                    return res;
                }
                else
                {
                    res.Data = result;
                    res.Message = "Loan details for this Id returned";
                    res.Success = true;
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<object> GetLoanByUserId(Guid UserId)
        {
            try
            {

                var result = dataContext.loans.Where(x => x.UserId == UserId.ToString()).Include(p => p.LoanDocument).AsQueryable().Select(x => new Loans
                {
                    AmountRequested = x.AmountRequested,
                    FirstName = x.FirstName,
                    Email = x.Email,
                    LastName = x.LastName,
                    LoanDocument = x.LoanDocument,
                    Location = x.Location,
                    PhoneNumber = x.PhoneNumber,
                    Purpose = x.Purpose,
                    Repaymentsource = x.Repaymentsource,
                    Tenor = x.Tenor,
                    UserId = x.UserId
                });

                var loanList = new LoansListDTO
                {
                    loan = result.ToList()
                };
                res.Data = loanList;
                res.Message = "List of Loans For this user found";
                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<object> UpdateLoan(LoansDTO loansDTO, Guid Id)
        {
            try
            {
                var update = await dataContext.loans.Where(p => p.Id == Id).FirstOrDefaultAsync();
                if (update != null)
                {

                    update.FirstName = loansDTO.FirstName;
                    update.AmountRequested = loansDTO.AmountRequested;
                    update.Email = loansDTO.Email;
                    update.LastName = loansDTO.LastName;
                    update.LoanDocument = loansDTO.LoanDocument;
                    update.Location = loansDTO.Location;
                    update.PhoneNumber = loansDTO.PhoneNumber;
                    update.Purpose = loansDTO.Purpose;
                    update.Repaymentsource = loansDTO.Repaymentsource;
                    update.Tenor = loansDTO.Tenor;

                    int result = await dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        res.Success = true;
                        res.Message = "Loan record has been successfully updated";
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
                    res.Message = "Loan id does not exist";
                    res.Data = null;
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> DeleteLoanById(Guid Id)
        {
            try
            {
                var delete = await dataContext.loans.Where(p => p.Id == Id).FirstOrDefaultAsync();
                if (delete != null)
                {
                    dataContext.Remove(delete);
                    int result = await dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        res.Success = true;
                        res.Message = "Loans successfully deleted";
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
                    res.Message = "Loan id does not exist";
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
