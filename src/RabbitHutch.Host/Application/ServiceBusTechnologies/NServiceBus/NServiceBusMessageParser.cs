using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client.Events;

namespace RabbitHutch.Host.Application.ServiceBusTechnologies.NServiceBus
{
	public class NServiceBusMessageParser : IMessageParser
	{
		private readonly BasicDeliverEventArgs _ea;

		public NServiceBusMessageParser(BasicDeliverEventArgs ea)
		{
			_ea = ea;
		}

		public string MessageId => GetHeaderValue(NServiceBus.Headers.MessageId);

		public IDictionary<string, string> Headers => ParseHeadersToDict(_ea);

		public string Body => Encoding.UTF8.GetString(_ea.Body);

		public bool IsError => Headers.ContainsKey(NServiceBus.Headers.ExceptionType);

		public string ContentType => GetHeaderValue(NServiceBus.Headers.ContentType);

		public string OriginatingEndPoint => GetHeaderValue(NServiceBus.Headers.OriginatingEndPoint);

		public string ProcessingEndPoint => GetHeaderValue(NServiceBus.Headers.ProcessingEndPoint);

		public string FailedQueue => GetHeaderValue(NServiceBus.Headers.FailedQ);

		public string MessageTypes => GetHeaderValue(NServiceBus.Headers.EnclosedMessageTypes);

		public string ServiceBusTechnology => "NServiceBus";

		private static IDictionary<string, string> ParseHeadersToDict(BasicDeliverEventArgs ea)
		{
			var dict = new Dictionary<string, string>();
			if (ea.BasicProperties.Headers != null)
			{
				foreach (var header in ea.BasicProperties.Headers)
				{
					dict.Add(header.Key, Encoding.UTF8.GetString((byte[])header.Value));
				}
			}
			return dict;
		}

		private string GetHeaderValue(string key)
		{
			string val;
			Headers.TryGetValue(key, out val);
			return val;
		}
	}
}
