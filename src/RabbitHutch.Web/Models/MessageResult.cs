﻿using System.Collections.Generic;

namespace RabbitHutch.Web.Models
{
    public class MessageResult
    {
        public string ServiceBusTechnology { get; set; }
        public string Body { get; set; }
        public IEnumerable<object> Headers { get; set; }
    }
}