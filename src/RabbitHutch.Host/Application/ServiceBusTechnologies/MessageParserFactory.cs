using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitHutch.Host.Application.ServiceBusTechnologies.NServiceBus;
using RabbitMQ.Client.Events;

namespace RabbitHutch.Host.Application.ServiceBusTechnologies
{
	public class MessageParserFactory : IMessageParserFactory
	{
		public IMessageParser GetMessageParser(BasicDeliverEventArgs ea)
		{
			var dict = new Dictionary<string, string>();
			if (ea.BasicProperties.Headers != null)
			{
				foreach (var header in ea.BasicProperties.Headers)
				{
					dict.Add(header.Key, Encoding.UTF8.GetString((byte[])header.Value));
				}
			}

			if(dict.Keys.Any(x => x.StartsWith("NServiceBus")))
				return new NServiceBusMessageParser(ea);

			throw new Exception($"Unable to find a concrete message parser");
		}
	}
}
