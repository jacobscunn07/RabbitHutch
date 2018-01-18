﻿using System;
using System.Collections.Generic;
using System.Text;
using RabbitHutch.Application.Helpers;
using RabbitHutch.Domain;
using RabbitMQ.Client.Events;

namespace RabbitHutch.Application.ServiceBusTechnologies.NServiceBus
{
	public class NServiceBusMessageParser : IMessageParser
	{

	    public NServiceBusMessageParser(BasicDeliverEventArgs ea)
		{
		    Headers = ea.BasicProperties.GetHeadersDictionary();
		    Body = Encoding.UTF8.GetString(ea.Body).TrimStart('\uFEFF'); // UTF8 Preamble or BOM https://en.wikipedia.org/wiki/Byte_order_mark
        }

	    public NServiceBusMessageParser(MessageDocument document)
	    {
	        Headers = document.Headers;
	        Body = document.Body;
	    }

		public string MessageId => Headers.GetValueByKey(NServiceBus.Headers.MessageId);

		public IDictionary<string, string> Headers { get; }

	    public string Body { get; }

		public bool IsError => Headers.ContainsKey(NServiceBus.Headers.StackStrace);

		public string ContentType => Headers.GetValueByKey(NServiceBus.Headers.ContentType);

		public string OriginatingEndPoint => Headers.GetValueByKey(NServiceBus.Headers.OriginatingEndPoint);

        public string ProcessingEndPoint => IsError ? FailedQueue : Headers.GetValueByKey(NServiceBus.Headers.ProcessingEndPoint);

	    public string ReplyTo => Headers.GetValueByKey(NServiceBus.Headers.ReplyTo);

	    public string FailedQueue => Headers.GetValueByKey(NServiceBus.Headers.FailedQ).Split('@')[0];

	    public string MessageTypes => Headers.GetValueByKey(NServiceBus.Headers.EnclosedMessageTypes);

		public string ServiceBusTechnology => "NServiceBus";

	    public bool IsReplay => Headers.ContainsKey(NServiceBus.Headers.IsReplay);

	    public DateTime ReplayDateTime => DateTime.Parse(Headers.GetValueByKey(NServiceBus.Headers.ReplayDateTime));

	    public string StackTrace => Headers.GetValueByKey(NServiceBus.Headers.StackStrace);
	}
}
