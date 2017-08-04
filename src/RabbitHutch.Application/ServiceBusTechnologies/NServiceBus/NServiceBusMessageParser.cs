using System.Collections.Generic;
using System.Text;
using RabbitHutch.Application.Helpers;
using RabbitMQ.Client.Events;

namespace RabbitHutch.Application.ServiceBusTechnologies.NServiceBus
{
	public class NServiceBusMessageParser : IMessageParser
	{
		private readonly BasicDeliverEventArgs _ea;
	    private readonly IDictionary<string, string> _headers;

		public NServiceBusMessageParser(BasicDeliverEventArgs ea)
		{
			_ea = ea;
		    _headers = _ea.BasicProperties.GetHeadersDictionary();
		}

		public string MessageId => Headers.GetValueByKey(NServiceBus.Headers.MessageId);

		public IDictionary<string, string> Headers => _headers;

		public string Body => Encoding.UTF8.GetString(_ea.Body);

		public bool IsError => Headers.ContainsKey(NServiceBus.Headers.ExceptionType);

		public string ContentType => Headers.GetValueByKey(NServiceBus.Headers.ContentType);

		public string OriginatingEndPoint => Headers.GetValueByKey(NServiceBus.Headers.OriginatingEndPoint);

		public string ProcessingEndPoint => Headers.GetValueByKey(NServiceBus.Headers.ProcessingEndPoint);

		public string FailedQueue => Headers.GetValueByKey(NServiceBus.Headers.FailedQ);

		public string MessageTypes => Headers.GetValueByKey(NServiceBus.Headers.EnclosedMessageTypes);

		public string ServiceBusTechnology => "NServiceBus";
	}
}
