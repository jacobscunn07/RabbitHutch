using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Hosting;
using RabbitHutch.Application;
using RabbitHutch.Application.CommandHandlers;
using RabbitHutch.Application.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitHutch.Host
{
    public abstract class QueueWatcherService : IHostedService
    {
        private readonly IMediator _mediator;
        private readonly IQueueSettings _queueSettings;
        private IConnection _connection;
        private IModel _channel;
        
        protected QueueWatcherService(IMediator mediator, string queueName, string applicationName, bool isErrorQueue, string host)
        {
            _mediator = mediator;
            _queueSettings = new QueueSettings(queueName, applicationName, isErrorQueue, host);
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Watching queue {_queueSettings.QueueName} on host {_queueSettings.HostName}");

            var factory = new ConnectionFactory() {HostName = _queueSettings.HostName};
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
                    
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var result = await _mediator.Send(new HandleMessageCommand
                    {DeliveryArgs = ea, Application = _queueSettings.ApplicationName});
                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(_queueSettings.QueueName, false, consumer);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Dispose();
            Console.WriteLine($"Stopping watch queue {_queueSettings.QueueName} on host {_queueSettings.HostName}");
            return Task.CompletedTask;
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