using System;
using System.Linq;
using RabbitHutch.Application.Helpers;
using RabbitHutch.Application.ServiceBusTechnologies.NServiceBus;
using RabbitMQ.Client.Events;

namespace RabbitHutch.Application.ServiceBusTechnologies
{
	public class MessageParserFactory : IMessageParserFactory
	{
		public IMessageParser GetMessageParser(BasicDeliverEventArgs ea)
		{
			var dict = ea.BasicProperties.GetHeadersDictionary();

			if(dict.Keys.Any(x => x.StartsWith("NServiceBus")))
				return new NServiceBusMessageParser(ea);

			throw new Exception($"Unable to find a concrete message parser");
		}
	}
}
