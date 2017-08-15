using System;
using System.Collections.Generic;

namespace RabbitHutch.Web.Models
{
    public class MessageResult
    {
        public string MessageId { get; set; }
        public long DocumentId { get; set; }
        public string ServiceBusTechnology { get; set; }
        public string Body { get; set; }
        public string StackTrace { get; set; }
        public IEnumerable<object> Headers { get; set; }
        public IEnumerable<MessageReplayResult> Replays { get; set; }

        public class MessageReplayResult
        {
            public DateTime ReplayDateTime { get; set; }
            public bool IsError { get; set; }
        }
    }
}