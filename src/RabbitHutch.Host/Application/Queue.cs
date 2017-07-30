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

        public Queue(IMediator mediator)
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
                    //channel.BasicAck(ea.DeliveryTag, false);
                };

                channel.BasicConsume(
                    queue: "Autobahn.Configuration.Host",
                    autoAck: false,
                    consumer: consumer);

                Console.WriteLine("Press any key to exit.");
                Console.ReadLine();
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
