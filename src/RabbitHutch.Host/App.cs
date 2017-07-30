using MediatR;
using RabbitHutch.Host.Application.CommandHandlers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace RabbitHutch.Host
{
    public class App
    {
        private readonly IMediator _mediator;

        public App(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Run()
        {
            Console.WriteLine(nameof(Application) + " started.");

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var conn = factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var result = await _mediator.Send(new HandleMessageCommand { DeliveryArgs = ea });
                };

                channel.BasicConsume(
                    queue: "Autobahn.Configuration.Host",
                    autoAck: false,
                    consumer: consumer);

                Console.WriteLine("Press any key to exit.");
                Console.ReadLine();
            }
        }
    }
}
