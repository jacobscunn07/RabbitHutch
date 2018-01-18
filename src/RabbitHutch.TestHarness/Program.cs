using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Persistence;
using RabbitHutch.TestHarness.Commands;
using RabbitHutch.TestHarness.MenuItems;
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

            //await endpointInstance.SendLocal(new SendToSelf { Name = "Test" });

            var menuitems = Assembly.GetExecutingAssembly().DefinedTypes
                .Where(x => typeof(IMenuItem).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => Activator.CreateInstance(x.AsType()) as IMenuItem).ToList();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Key\tName");
            foreach (var menuItem in menuitems)
            {
                Console.WriteLine($"{menuItem.Key}\t{menuItem.Name}");
            }
            string selection = string.Empty;
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("Enter key for menu item to be executed.");
                selection = Console.ReadLine();
                if(!string.IsNullOrEmpty(selection))
                {
                    var menuItem = menuitems.Single(x => x.Key == selection);
                    menuItem.Execute(endpointInstance);
                }
            }

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }
}
