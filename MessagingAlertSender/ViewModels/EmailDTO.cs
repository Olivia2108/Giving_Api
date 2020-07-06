using System;
using System.Collections.Generic;

namespace MessagingAlertSender.ViewModels
{
    public partial class EmailDTO
    {
        public string Body { get; set; }
        public string Subject { get; set; }
        public string SourceEmail { get; set; }
        //public List<string> DestinatonEmail { get; }
        public List<string> receiverEmailList { get; set; }

       public EmailDTO()
        {
            DestinatonEmail = new List<string>();
        }
        public List<string> DestinatonEmail { get; set; }
    }
    }
