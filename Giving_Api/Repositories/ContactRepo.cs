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
    public class ContactRepo:IContact
    {
        private readonly DataContext dataContext;

        public ContactRepo(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        ServiceResponse res = new ServiceResponse();

        public async Task<object> AddContact(ContactDTO contacDTO)
        {
            try
            {
                var data = new Contact
                {
                    ContactEmail = contacDTO.ContactEmail,
                     ContactMessage = contacDTO.ContactMessage,
                     Time = contacDTO.Time,
                     CauseId = contacDTO.CauseId,
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

        public async Task<object> GetAllContact()
        {
            try
            {
                var result = dataContext.contacts.Select(x => new Contact
                {
                    ContactEmail = x.ContactEmail,
                    ContactMessage = x.ContactMessage,
                    Time = x.Time ,
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

        public async Task<object> DeleteContactById(Guid Id)
        {
            try
            {
                var delete = await dataContext.contacts.Where(p => p.ContactID == Id).FirstOrDefaultAsync();
                if (delete != null)
                {
                    dataContext.Remove(delete);
                    int result = await dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        res.Success = true;
                        res.Message = "Contact successfully deleted";
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
                    res.Message = "Contact's id does not exist";
                    res.Data = null;
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> UpdateContact(ContactDTO contactDTO, Guid Id)
        {
            try
            {
                var update = await dataContext.contacts.Where(p => p.ContactID == Id).FirstOrDefaultAsync();
                if (update != null)
                {
                    update.ContactEmail = contactDTO.ContactEmail;
                    update.ContactMessage = contactDTO.ContactMessage;
                    update.Time = contactDTO.Time;
                    update.CauseId = contactDTO.CauseId;
                    

                    int result = await dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        res.Success = true;
                        res.Message = "Contact's record has been successfully updated";
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
                    res.Message = "Contact's id does not exist";
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
