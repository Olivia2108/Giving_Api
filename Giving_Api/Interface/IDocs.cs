using Giving_Api.Models;
using Giving_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Interface
{
    public interface IDocs
    {
        //Task<object> GetUserProfileByUserId(Guid UserId);
        //Task<object> DeleteUserProfileById(Guid Id);
        //Task<object> UpdateUserProfile(UserProfileDTO userprofileDTO, Guid Id);
        //Task<object> GetAllUserProfileById(Guid Id);
        //Task<object> GetAllUserProfile();
        Task<ServiceResponse> Add(RegistrationDocument model, string UserId);
    }
}
