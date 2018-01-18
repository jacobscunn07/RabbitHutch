using System;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Persistence;
using RabbitHutch.TestHarness.Commands;
using RabbitMQ.Client;

namespace RabbitHutch.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        static async Task AsyncMain()
        {
            var endpointConfiguration = new EndpointConfiguration("RabbitHutch.TestHarness.Client");
            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>().ConnectionString("host=localhost");
            endpointConfiguration.UsePersistence<InMemoryPersistence, StorageType.Timeouts>();
            endpointConfiguration.AuditProcessedMessagesTo("audit");
            endpointConfiguration.UseSerialization<JsonSerializer>();

            var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

            await endpointInstance.SendLocal(new SendToSelf { Name = "Test" });

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }
}
