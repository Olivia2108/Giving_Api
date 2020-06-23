
using Giving_Api.Data;
using Giving_Api.Interface;
using Giving_Api.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Giving_Api.Repositories
{
    public class EmailRepo:IEmail
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _dataContext;

        public EmailRepo(IConfiguration configuration, DataContext dataContext)
        {
            _configuration = configuration;
            _dataContext = dataContext;
        }



        public void WelcomeNewUser(User user, string emailFor = "Verification")
        {
            try
            {
                string body = "";
                string subject = "";
                if (emailFor == "Verification")
                {
                    body = string.Format(_configuration.GetValue<string>("WelcomeNewUserMessage"), _configuration.GetValue<string>("ServerUrl"), user.ConfirmationToken);
                    subject = "Welcome to DREAS";
                }
                //else if (emailFor == "ResetPassword")
                //{
                //    body = string.Format(_configuration.GetValue<string>("ResetUserPasswordMessage"), _configuration.GetValue<string>("ServerUrl"), user.PasswordResetCode);
                //    subject = "Reset Password";

               
                    


                //}



                WebClient client = new WebClient();
                NameValueCollection values = new NameValueCollection();
                values.Add("username", _configuration["Email:Email"]);
                values.Add("api_key", _configuration["Email:api_key"]);
                values.Add("from", _configuration["Email:Email"]);
                values.Add("from_name", _configuration["Email:from_name"]);
                values.Add("subject", subject);
                values.Add("body_html", body);
                values.Add("to", user.Name);
                client.UploadValuesAsync(new Uri("https://api.elasticemail.com/mailer/send"), values);



            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
