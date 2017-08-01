using RabbitMQ.Client.Events;

namespace RabbitHutch.Host.Application.ServiceBusTechnologies
{
	public interface IMessageParserFactory
	{
		IMessageParser GetMessageParser(BasicDeliverEventArgs ea);
	}
}
