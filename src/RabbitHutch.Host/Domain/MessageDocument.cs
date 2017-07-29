using System.Collections.Generic;

namespace RabbitHutch.Host.Domain
{
    public class MessageDocument
    {
        public IDictionary<string, string> Headers { get; set; }
        public string Body { get; set; }
        public string ServiceBusTechnology { get; set; }
        public string ApplicationId { get; set; }
        public string MessageTypes { get; set; }
    }
}
