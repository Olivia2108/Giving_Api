using Giving_Api.Interface;
using Giving_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Giving_Api.Services
{
    public class MailService :IMailService
    {
        private readonly IHttpClientFactory _client;
        public MailService(IHttpClientFactory client)
        {
            _client = client;
        }
        
        public async Task<bool> SendMail(EmailDTO model)
        {
            var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]{
                new KeyValuePair<string, string>("body", model.Body),
                new KeyValuePair<string, string>("subject", model.Subject),
                new KeyValuePair<string, string>("sourceEmail", model.SourceEmail),
                new KeyValuePair<string, string>("destinationEmail", model.DestinatonEmail),
            });

            var client = _client.CreateClient();
            //client.BaseAddress = new Uri("https://apisandbox.sterling.ng/EWService/1.0/sendmail");
            var response = await client.PostAsync("https://apisandbox.sterling.ng/EWService/1.0/sendmail", content);
            if(response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}
