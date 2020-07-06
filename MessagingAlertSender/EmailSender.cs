using System;
using System.Linq;
using System.Text;
using System.Configuration;
using Topshelf.Logging;
using static Giving_Api.Security.EnumsManager;
using MessagingAlertSender.Data;
using MessagingAlertSender.ViewModels;
using MessagingAlertSender.Services;
using System.Collections.Generic;
using System.Data.Entity;

namespace MessagingAlertSender
{
    public class EmailSender 
    {
        Guid mailId = new Guid();
        private string displayName = ConfigurationManager.AppSettings["emailDisplayName"];
        private string userName = ConfigurationManager.AppSettings["Username"];
        private string password = ConfigurationManager.AppSettings["Password"];
        private string smtpclient = ConfigurationManager.AppSettings["smtpClient"];
        private string enableSsl = ConfigurationManager.AppSettings["enableSsl"];
        private string postNumber = ConfigurationManager.AppSettings["smtpPort"];
       
        private string requireCredential = ConfigurationManager.AppSettings["requireCredential"];
        private string exceptionReportingEmails = ConfigurationManager.AppSettings["exceptionReportingEmails"];
        private  string[] Addy = { };
        private static readonly LogWriter _log = HostLogger.Get<WindowService>();
        DataContext dataContext = new DataContext();

        public bool SendEmailOfException(string body)
        {
                char[] seperators = { ',', ';' };
                EmailDTO mail = new EmailDTO();
                mail.SourceEmail = "kingsley.ozoemena@sterling.ng";
                Addy = exceptionReportingEmails.Split(seperators);

                foreach (var emailAddy in Addy)
                {
                    if (emailAddy != null && emailAddy != string.Empty)
                    {
                        mail.DestinatonEmail.Add(emailAddy);
                    }
                }

                mail.Subject = "Giving Sterling Bank Service - Email Alert Sender Exception";
                mail.Body = "Dear Sir/Ma, <br /><br /> ERROR EXCEPTION REPORT <br /><br /> The service has failed with error : " + body + "<br /><br /> Kindly escalate this issue to Fintrak Credit 360 support for urgent attention." +
                    "<br /><br /> Thanks <br /> Giving Sterling Bank.";


                Console.WriteLine("");
                Console.WriteLine("email body loaded and sending started  ~~~~~~~~~~~~~~~~~");
                Console.WriteLine("");

                try
                {
                    MailService mailService = new MailService();
                    mailService.SendMail(mail);
                    Console.WriteLine("");
                    Console.WriteLine("email sent successfully ~~~~~~~~~~~~~~~");
                    Console.WriteLine("");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("");
                    Console.WriteLine("error sending mail ~~~~~~~~~~~~~~~");
                    Console.WriteLine("");

                    throw new Exception("Error : " + ex);
                }


            
            return true;
        }
        public bool SendEmails()
        {
            try
            {
                //checks if record has been excecuted
                /* TimeSpan start = new TimeSpan(17, 0, 0); //5 o'clock pm
                 TimeSpan end = new TimeSpan(23, 0, 0); //11 o'clock pm
                 TimeSpan now = DateTime.Now.TimeOfDay;

                 if ((now >= start) && (now <= end))
                 {*/
                //gets lists of records from the db that matches these conditons
                List<int> days = new List<int> { 365, 90, 30, 7 };

                var listOfMails = dataContext.recurringDonations.Where(o => days.Contains(DbFunctions.DiffDays(DateTime.UtcNow, o.ModifiedDate).Value) && (o.statusId == (int)MessageStatusEnum.Pending 
                    || o.statusId == (short)MessageStatusEnum.Attempted)
                   ).ToList();

                //loops through each of the mail gotten
                if (listOfMails !=null)
                    {
                        foreach (var newMail in listOfMails)
                        {

                            EmailDTO mail = new EmailDTO();
                            mail.SourceEmail = "kingsley.ozoemena@sterling.ng";

                            if (newMail.Email != null && newMail.Email != string.Empty)
                            {
                                char[] seperators = { ',', ';' };
                                Addy = newMail.Email.Split(seperators);
                                foreach (var emailAddy in Addy)
                                {
                                    if (emailAddy != null && emailAddy != string.Empty)
                                    {
                                    mail.DestinatonEmail.Add(emailAddy);
                                }
                            }
                        }
                            //goes to get the message body and subject from the messagecontent table where it matches the id in enums manager

                        var messageBody = dataContext.messageContent.Where(o => o.messageCode ==  (int)MessageContentCode.RecurringDonation).FirstOrDefault();
                                mail.Subject = messageBody.subject;
                                mail.Body = messageBody.body;
                                mailId = newMail.RecurringDonationID;

                            MailService mailService = new MailService();

                        //this sends the message to Sterling mail endpoint
                            mailService.SendMail(mail);

                        //this updates the recurring table with the current status and modified date

                        UpdateMailDeliveryStatus(newMail.RecurringDonationID, (short)MessageStatusEnum.Sent, "Email Sent Successfully");
                        }
                    }
                   
                //}
                return true;
            }
            catch (Exception ex)
            {
                UpdateMailDeliveryStatus(mailId, (short)MessageStatusEnum.Attempted, "Email sending failed. Error Response : " + ex.Message);
                throw new Exception("Failed with error sending mail: " + ex);
            }
        }

        public bool UpdateMailDeliveryStatus(Guid messageId, short statusId, string response)
        {

            var mailMessage = dataContext.recurringDonations.Find(messageId);

            if (mailMessage != null)
            {
                mailMessage.statusId = (short)statusId;
                mailMessage.ModifiedDate = DateTime.Now;
                var output = dataContext.SaveChanges() > 0;

                if (output)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public bool UpdateMailStatus(Guid ID)
        {
            try
            {
                var mail = dataContext.recurringDonations.Where(p => p.RecurringDonationID == ID).FirstOrDefault();
                if (mail != null)
                {
                    mail.statusId = (short)MessageStatusEnum.Sent;
                    dataContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException;
                string innerMessage = "";
                if (innerException != null)
                    innerMessage = innerException.Message;

              //  throw new SecureException("Failed with error : " + innerMessage);
                return false;

            }
        }

        public string RemoveSpecial(string evalstr)
        {
            StringBuilder finalstr = new StringBuilder();
            foreach (char c in evalstr)
            {
                int charassci = Convert.ToInt16(c);
                if (!(charassci >= 33 && charassci <= 47))// special char ???
                    finalstr.Append(c);
            }
            return finalstr.ToString();
        }




    }
}
