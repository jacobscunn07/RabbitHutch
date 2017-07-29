using MediatR;
using RabbitHutch.Host.CommandHandlers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace RabbitHutch.Host
{
    public class Application
    {
        private readonly IMediator _mediator;

        public Application(IMediator mediator)
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

                    Console.WriteLine("***** Received Message *****");
                    Console.WriteLine($"Bus Technology: {result.RawMessage.BusTechnology}");
                    Console.WriteLine("Headers:");
                    foreach (var header in result.RawMessage.Headers)
                    {
                        Console.WriteLine($"{header.Key}: {header.Value}");
                    }
                    Console.WriteLine("Body:");
                    Console.WriteLine(result.RawMessage.Body);
                    //channel.BasicAck(ea.DeliveryTag, false);
                    Console.WriteLine();
                    Console.WriteLine();
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
