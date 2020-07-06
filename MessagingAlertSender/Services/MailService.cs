using MessagingAlertSender.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MessagingAlertSender.Services
{
    public class MailService 
    {
        private readonly HttpClientHandler _handler = new HttpClientHandler();
        private static HttpClient _httpClientInstance;

        public MailService()
        { }
            public async Task<bool> SendMail(EmailDTO entity)
        {
            bool responseMsg = false;
            var objData = new JavaScriptSerializer().Serialize(entity);
            DateTime requestDatetime = new DateTime(), responseDateTime = new DateTime();
            HttpResponseMessage response = null;
            string responseMessage = "";

            HttpClient client = new HttpClient(_handler);
            _httpClientInstance = new HttpClient();
            _httpClientInstance.DefaultRequestHeaders.ConnectionClose = false;
            client.Timeout = TimeSpan.FromSeconds(180);
            client.BaseAddress = new Uri("https://apisandbox.sterling.ng/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            response = client.PostAsync("EWService/1.0/sendmail", new StringContent(
                                            new JavaScriptSerializer().Serialize(entity), Encoding.UTF8, "application/json")).Result;
            
            bool result = false;
            result = response.IsSuccessStatusCode;
            if (result)
            {
                responseMsg = true;
            }
            else
            {
                responseMsg = false;
            }

            responseMessage = await response.Content.ReadAsStringAsync();
            _handler.Dispose();
            client.Dispose();

            return responseMsg;
        }


        //private readonly IHttpClientFactory _client;
        //public MailService(IHttpClientFactory client)
        //{
        //    _client = client;
        //}

        //public async Task<bool> SendMail(EmailDTO model)
        //{
        //    var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]{
        //        new KeyValuePair<string, string>("body", model.Body),
        //        new KeyValuePair<string, string>("subject", model.Subject),
        //        new KeyValuePair<string, string>("sourceEmail", model.SourceEmail),
        //        new KeyValuePair<string, string>("destinationEmail", model.DestinatonEmail),
        //    });

        //    var client = _client.CreateClient();
        //    //client.BaseAddress = new Uri("https://apisandbox.sterling.ng/EWService/1.0/sendmail");
        //    var response = await client.PostAsync("https://apisandbox.sterling.ng/EWService/1.0/sendmail", content);
        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

    }
}
