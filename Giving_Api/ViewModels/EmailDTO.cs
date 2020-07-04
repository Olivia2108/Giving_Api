using System;

namespace Giving_Api.ViewModels
{
    public class EmailDTO
    {
        public string Body { get; set; }
        public string Subject { get; set; }
        public string SourceEmail { get; set; }
        public string DestinatonEmail { get; set; }
    }
}
