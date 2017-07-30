using MediatR;
using RabbitHutch.Host.Application.CommandHandlers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace RabbitHutch.Host.Application
{
    public class Queue : IQueue
    {
        private readonly IMediator _mediator;
        private readonly IQueueSettings _queueSettings;

        public Queue(IMediator mediator, IQueueSettings queueSettings)
        {
            _mediator = mediator;
            _queueSettings = queueSettings;
        }

        public void Run()
        {
            Console.WriteLine($"Watching queue {_queueSettings.QueueName} on host {_queueSettings.HostName}");

            var factory = new ConnectionFactory() { HostName = _queueSettings.HostName };
            using (var conn = factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var result = await _mediator.Send(new HandleMessageCommand { DeliveryArgs = ea });
                    //channel.BasicAck(ea.DeliveryTag, false);
                };

                channel.BasicConsume(
                    queue: _queueSettings.QueueName,
                    autoAck: false,
                    consumer: consumer);

                Console.ReadLine();
            }
        }
    }
}
