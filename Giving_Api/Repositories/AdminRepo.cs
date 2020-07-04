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
    public class AdminRepo:IAdmin
    {

        private readonly DataContext dataContext;
        private readonly IAdmin _admin;

        public AdminRepo(DataContext _dataContext, IAdmin admin)
        {
            dataContext = _dataContext;
            _admin = admin;
        }

        ServiceResponse res = new ServiceResponse();


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

        public async Task<object> GetAllContact()
        {
            try
            {
                var result = dataContext.contacts.Select(x => new Contact
                {
                    ContactEmail = x.ContactEmail,
                    ContactMessage = x.ContactMessage,
                    Time = x.Time,
                    CauseId = x.CauseId

                });

                var ContactListDTO = new ContactListDTO
                {
                    contacts = result.ToList()
                };
                res.Data = ContactListDTO;
                res.Message = "List of Contact";
                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {

                throw;
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
                    DonorFirstName = x.DonorFirstName,
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
                    PhoneNumber = x.PhoneNumber,
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

        public async Task<object> GetAllReview()
        {
            try
            {
                var result = dataContext.reviews.Select(x => new Review
                {

                    ReviewEmail = x.ReviewEmail,
                    CauseID = x.CauseID,
                    ReviewID = x.ReviewID,
                    ReviewMessage = x.ReviewMessage,
                    ReviewTime = x.ReviewTime,
                    UserId = x.UserId,


                });

                var ReviewListDTO = new ReviewListDTO
                {
                    Reviews = result.ToList()
                };
                res.Data = ReviewListDTO;
                res.Message = "List of Reviews";
                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<object> GetAllUserProfile()
        {
            try
            {

                var result = dataContext.UserProfile.Include(p => p.RegDocument).AsQueryable().Select(x => new UserProfile
                {

                    PysicalAddress = x.PysicalAddress,
                    Company = x.Company,
                    Country = x.Country,
                    Facebook = x.Facebook,
                    Instagram = x.Instagram,
                    Picture = x.Picture,
                    RegDocument = x.RegDocument,
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
        public async Task<object> GetAllVolunteer()
        {
            try
            {
                var result = dataContext.volunteers.Select(x => new Volunteer
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
                    Volunteer = result.ToList()
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
        public async Task<object> GetReviewsById(Guid Id)
        {
            try
            {

                var result = await dataContext.reviews.Where(p => p.ReviewID == Id).FirstOrDefaultAsync();
                if (result == null)
                {
                    res.Data = null;
                    res.Message = "Review details not available";
                    res.Success = false;
                    return res;
                }
                else
                {
                    res.Data = result;
                    res.Message = "Review Id does not exist";
                    res.Success = true;
                    return res;
                }
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
        public async Task<object> GetContactById(Guid Id)
        {
            try
            {

                var result = await dataContext.contacts.Where(p => p.ContactID == Id).FirstOrDefaultAsync();
                if (result == null)
                {
                    res.Data = null;
                    res.Message = "Contact details not available";
                    res.Success = false;
                    return res;
                }
                else
                {
                    res.Data = result;
                    res.Message = "Contact Id does not exist";
                    res.Success = true;
                    return res;
                }
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
        public async Task<object> GetCauseByUserId(Guid UserId)
        {
            try
            {

                var result = dataContext.Cause.Where(x => x.UserID == UserId.ToString()).Include(p => p.CauseBeneficiaryAccount).AsQueryable().Select(x => new Cause
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
        public async Task<object> GetContatByUserEmail(string Email)
        {
            try
            {

                var result = dataContext.contacts.Where(x => x.ContactEmail == Email.ToString()).AsQueryable().Select(x => new Contact
                {
                    ContactEmail = x.ContactEmail,
                    CauseId = x.CauseId,
                    ContactMessage = x.ContactMessage,
                    Time = x.Time

                });
                var list = new ContactListDTO
                {
                    contacts = result.ToList()
                };

                if (list == null)
                {
                    res.Data = null;
                    res.Message = "No Contact found by this user was found";
                    res.Success = false;
                    return res;
                }
                else
                {
                    res.Data = list;
                    res.Message = "List of Contact made by this user returned";
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
        public async Task<object> GetReviewByUserEmail(string Email)
        {
            try
            {

                var result = dataContext.reviews.Where(x => x.ReviewEmail == Email.ToString()).AsQueryable().Select(x => new Review
                {

                    CauseID = x.CauseID,
                    ReviewEmail = x.ReviewEmail,
                    ReviewMessage = x.ReviewMessage,
                    ReviewTime = x.ReviewTime,
                    UserId = x.UserId

                });
                var list = new ReviewListDTO
                {
                    Reviews = result.ToList()
                };

                if (list == null)
                {
                    res.Data = null;
                    res.Message = "No Review found by this user was found";
                    res.Success = false;
                    return res;
                }
                else
                {
                    res.Data = list;
                    res.Message = "List of Review made by this user returned";
                    res.Success = true;
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

    }
}
