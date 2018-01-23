using RabbitHutch.Application.Helpers;
using RabbitHutch.Domain;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitHutch.Application.ServiceBusTechnologies.MassTransit
{
    public class MassTransitMessageParser : IMessageParser
    {
        public MassTransitMessageParser(BasicDeliverEventArgs ea)
        {
            Headers = ea.BasicProperties.GetHeadersDictionary();
            Body = Encoding.UTF8.GetString(ea.Body).TrimStart('\uFEFF'); // UTF8 Preamble or BOM https://en.wikipedia.org/wiki/Byte_order_mark
        }

        public MassTransitMessageParser(MessageDocument document)
        {
            Headers = document.Headers;
            Body = document.Body;
        }

        public string MessageId => Headers.GetValueByKey(MassTransit.Headers.MessageId);

        public IDictionary<string, string> Headers { get; }

        public string Body { get; }

        public bool IsError => Headers.ContainsKey(MassTransit.Headers.StackStrace);

        public string OriginatingEndPoint => Headers.GetValueByKey(MassTransit.Headers.OriginatingEndPoint);

        public string ProcessingEndPoint => Headers.GetValueByKey(MassTransit.Headers.ProcessingEndPoint);

        public string FailedQueue => Headers.GetValueByKey(MassTransit.Headers.FailedQ);

        public string MessageTypes => Headers.GetValueByKey(MassTransit.Headers.EnclosedMessageTypes);

        public string ClassType => "WIP";

        public string ServiceBusTechnology => "MassTransit";

        public bool IsReplay => Headers.ContainsKey(MassTransit.Headers.IsReplay);

        public DateTime ReplayDateTime => DateTime.Parse(Headers.GetValueByKey(MassTransit.Headers.ReplayDateTime));

        public string StackTrace => Headers.GetValueByKey(MassTransit.Headers.StackStrace);

        public DateTime ProcessedDateTime => DateTime.Parse(Headers.GetValueByKey(MassTransit.Headers.ProcessingDateTimeEnded));
    }
}
