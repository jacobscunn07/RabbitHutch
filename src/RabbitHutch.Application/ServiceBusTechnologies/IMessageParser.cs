using System.Collections.Generic;

namespace RabbitHutch.Application.ServiceBusTechnologies
{
	public interface IMessageParser
	{
		string MessageId { get; }
		IDictionary<string, string> Headers { get; }
		string Body { get; }
		bool IsError { get; }
		string ContentType { get; }
		string OriginatingEndPoint { get; }
		string ProcessingEndPoint { get; }
		string FailedQueue { get; }
		string MessageTypes { get; }
		string ServiceBusTechnology { get; }
	}
}
