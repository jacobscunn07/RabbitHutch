using System;
using System.Text;
using RabbitMQ.Client;

namespace RabbitHutch.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using (var conn = factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                channel.QueueDeclare(
                    queue: "hello",
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var message = "Hello World!";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(
                    exchange: "",
                    routingKey: "hello",
                    basicProperties: null,
                    body: body);
                Console.WriteLine($"[x] Sent {message}");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
