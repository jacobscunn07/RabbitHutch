using MediatR;
using RabbitHutch.Host.Application.CommandHandlers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Threading;

namespace RabbitHutch.Host.Application
{
    public class Queue : IQueue
    {
        private readonly IMediator _mediator;
        private readonly IQueueSettings _queueSettings;
        private IModel _channel;

        public Queue(IMediator mediator, IQueueSettings queueSettings, CancellationTokenSource cancellationTokenSource)
        {
            _mediator = mediator;
            _queueSettings = queueSettings;
            CancellationTokenSource = cancellationTokenSource;
        }

        public CancellationTokenSource CancellationTokenSource { get; set; }

        public void Run()
        {
            Console.WriteLine($"Watching queue {_queueSettings.QueueName} on host {_queueSettings.HostName}");

            var factory = new ConnectionFactory() { HostName = _queueSettings.HostName };
            using (var conn = factory.CreateConnection())
            using (_channel = conn.CreateModel())
            {
                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += async (model, ea) =>
                {
                    var result = await _mediator.Send(new HandleMessageCommand { DeliveryArgs = ea });
                    //channel.BasicAck(ea.DeliveryTag, false);
                };

                consumer.Shutdown += (model, ea) =>
                {
                    Console.WriteLine($"Shutting down queue: {_queueSettings.QueueName}");
                };

                _channel.BasicConsume(
                    queue: _queueSettings.QueueName,
                    autoAck: false,
                    consumer: consumer);

                PreventShutdown();
            }
        }

        private void PreventShutdown()
        {
            while (!CancellationTokenSource.IsCancellationRequested)
            {
            }
        }
    }
}
