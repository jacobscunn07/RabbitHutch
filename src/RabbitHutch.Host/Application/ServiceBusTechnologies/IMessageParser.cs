using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitHutch.Host.Application.ServiceBusTechnologies
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
