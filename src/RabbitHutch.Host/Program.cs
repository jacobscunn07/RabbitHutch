using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitHutch.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() {HostName = "localhost"};
            using (var conn = factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                channel.QueueDeclare(
                    queue: "audit",
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var headers = new Dictionary<string, string>();
                    foreach (var header in ea.BasicProperties.Headers)
                    {
                        headers.Add(header.Key, Encoding.UTF8.GetString((byte[])header.Value));
                    }

                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("***** Received Message *****");
                    Console.WriteLine("Headers:");
                    foreach (var header in headers)
                    {
                        Console.WriteLine($"{header.Key}: {header.Value}");
                    }
                    Console.WriteLine("Body:");
                    Console.WriteLine(message);
                    Console.WriteLine();
                    Console.WriteLine();
                };

                channel.BasicConsume(
                    queue: "audit",
                    autoAck: false,
                    consumer: consumer);

                Console.WriteLine("Press any key to exit.");
                Console.ReadLine();
            }
        }
    }
}
