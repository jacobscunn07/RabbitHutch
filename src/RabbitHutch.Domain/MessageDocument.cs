using System.Collections.Generic;

namespace RabbitHutch.Domain
{
    public class MessageDocument
    {
        public long Id { get; set; }
        public long DocId => Id;
        public IDictionary<string, string> Headers { get; set; }
        public string Body { get; set; }
        public string ServiceBusTechnology { get; set; }
        public string ApplicationId { get; set; }
        public string MessageTypes { get; set; }
        public bool IsError { get; set; }
        public string Any { get; set; }
    }
}
