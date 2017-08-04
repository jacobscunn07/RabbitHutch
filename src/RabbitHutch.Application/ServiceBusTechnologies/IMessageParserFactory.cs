using RabbitMQ.Client.Events;

namespace RabbitHutch.Application.ServiceBusTechnologies
{
	public interface IMessageParserFactory
	{
		IMessageParser GetMessageParser(BasicDeliverEventArgs ea);
	}
}
