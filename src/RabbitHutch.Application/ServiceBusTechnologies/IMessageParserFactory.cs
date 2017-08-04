using RabbitHutch.Domain;
using RabbitMQ.Client.Events;

namespace RabbitHutch.Application.ServiceBusTechnologies
{
	public interface IMessageParserFactory
	{
		IMessageParser GetMessageParser(BasicDeliverEventArgs ea);

	    IMessageParser GetMessageDocumentParser(MessageDocument document);
	}
}
