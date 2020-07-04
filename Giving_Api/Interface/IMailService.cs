using Giving_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Interface
{
    public interface IMailService
    {
        Task<bool> SendMail(EmailDTO model);
    }
}
