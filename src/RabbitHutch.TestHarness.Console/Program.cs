using Microsoft.Extensions.DependencyInjection;
using NServiceBus;
using RabbitHutch.TestHarness.Console.MenuItems;
using System;
using System.Linq;
using System.Reflection;

namespace RabbitHutch.TestHarness.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var _endpointConfiguration = new EndpointConfiguration("RabbitHutch.TestHarness.Console");
            _endpointConfiguration.UseTransport<RabbitMQTransport>().ConnectionString("host=localhost").UseConventionalRoutingTopology();
            _endpointConfiguration.UsePersistence<InMemoryPersistence, StorageType.Timeouts>();
            _endpointConfiguration.AuditProcessedMessagesTo("audit");
            _endpointConfiguration.UseSerialization<NewtonsoftSerializer>();
            _endpointConfiguration.EnableInstallers();
            _endpointConfiguration.Recoverability().Delayed(delayed => { delayed.NumberOfRetries(0); });
            var instance = Endpoint.Start(_endpointConfiguration).ConfigureAwait(false).GetAwaiter().GetResult();
            var serviceProvider = new ServiceCollection()
                .AddTransient<ITest, Test>()
                .AddTransient<App>()
                .AddSingleton<IEndpointInstance>(instance)
                .BuildServiceProvider();
            var app = serviceProvider.GetService<App>();
            app.RunAsync();
            System.Console.WriteLine("Hello World!");
            System.Console.ReadLine();
        }
    }

    public interface ITest { }

    public class Test : ITest { }

    public class App
    {
        private readonly IEndpointInstance _testService;

        public App(IEndpointInstance testService)
        {
            _testService = testService;
        }

        public async System.Threading.Tasks.Task RunAsync()
        {
            var menuitems = Assembly.GetExecutingAssembly().DefinedTypes
                .Where(x => typeof(MenuItem).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => Activator.CreateInstance(x.AsType(), _testService) as MenuItem).ToList();

            while (true)
            {
                System.Console.WriteLine();
                System.Console.WriteLine();
                System.Console.WriteLine("Key\tService Bus\tName");
                foreach (var menuItem in menuitems)
                {
                    System.Console.WriteLine($"{menuItem.Key}\t{menuItem.ServiceBus}\t{menuItem.Name}");
                }
                System.Console.WriteLine();
                System.Console.WriteLine("Enter key for menu item to be executed.");
                var selection = System.Console.ReadLine();
                if (!string.IsNullOrEmpty(selection))
                {
                    var menuItem = menuitems.Single(x => x.Key == selection);
                    await menuItem.ExecuteAsync();
                }
            }

            System.Console.ReadKey();
        }
    }
}
