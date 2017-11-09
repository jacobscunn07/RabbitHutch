using System;
using System.Linq;
using RabbitHutch.Application.Helpers;
using RabbitHutch.Application.ServiceBusTechnologies.NServiceBus;
using RabbitHutch.Domain;
using RabbitMQ.Client.Events;

namespace RabbitHutch.Application.ServiceBusTechnologies
{
	public static class MessageParserFactory
	{
		public static IMessageParser GetMessageParser(BasicDeliverEventArgs ea)
		{
			var dict = ea.BasicProperties.GetHeadersDictionary();

			if(dict.Keys.Any(x => x.StartsWith("NServiceBus")))
				return new NServiceBusMessageParser(ea);

			throw new Exception($"Unable to find a concrete message parser");
		}

	    public static IMessageParser GetMessageDocumentParser(MessageDocument document)
	    {
	        if(document.ServiceBusTechnology == "NServiceBus")
                return new NServiceBusMessageParser(document);

            throw new Exception("Unable to find a concrete message document parser");
	    }
	}
}
