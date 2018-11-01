using System;
using System.Threading;
using MediatR;
using RabbitHutch.Application.CommandHandlers;
using RabbitHutch.Application.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitHutch.Application
{
    public class QueueWatcher : IQueueWatcher
    {
        private readonly IMediator _mediator;
        private readonly IQueueSettings _queueSettings;
        private IConnection _connection;
        private IModel _channel;

        public QueueWatcher(IMediator mediator, IQueueSettings queueSettings)
        {
            _mediator = mediator;
            _queueSettings = queueSettings;
        }

        public void Run()
        {
            Console.WriteLine($"Watching queue {_queueSettings.QueueName} on host {_queueSettings.HostName}");

            var factory = new ConnectionFactory() { HostName = _queueSettings.HostName };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var result = await _mediator.Send(new HandleMessageCommand { DeliveryArgs = ea, Application = _queueSettings.ApplicationName});
                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(_queueSettings.QueueName, false, consumer);
        }

        public void Stop()
        {
            Dispose();
            Console.WriteLine($"Stopping watch queue {_queueSettings.QueueName} on host {_queueSettings.HostName}");
        }

        private void Dispose()
        {
            _channel.Dispose();
            _channel = null;
            _connection.Dispose();
            _connection = null;
        }
    }
}
