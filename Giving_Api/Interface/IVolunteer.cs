using Giving_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Interface
{
    public interface IVolunteer
    {
        Task<object> AddVolunteer(VolunteerDTO volunteerDTO, string userID);
        Task<object> GetAllVolunteer();
        Task<object> GetVolunteerById(Guid Id);
        Task<object> GetVolunteerByUseId(Guid UserId);
        Task<object> UpdateVolunteer(VolunteerDTO volunteerDTO, Guid Id);
        Task<object> DeleteVolunteerById(Guid Id);
    }
}
