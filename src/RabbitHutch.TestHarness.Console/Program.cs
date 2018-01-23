using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;
using RabbitHutch.TestHarness.Console.MenuItems;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.Console
{
    public interface ValueEntered
    {
        string Value { get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            //var busControl = ConfigureMassTransit();
            //busControl.Start();

            //await busControl.Publish<ValueEntered>(new
            //{
            //    Value = "blabla"
            //});

            //busControl.Stop();
            //System.Console.WriteLine();
            //System.Console.WriteLine();
            //System.Console.WriteLine();
            //System.Console.WriteLine();
            //System.Console.WriteLine();


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
            await app.RunAsync();
            System.Console.ReadLine();
        }

        static IBusControl ConfigureMassTransit()
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var queueName = "rabbithutch_queue";
                var host = cfg.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint(host, queueName, e =>
                {
                    e.Handler<ValueEntered>(context => throw new Exception("Kill Mass Transit Message"));
                });

                cfg.ConfigurePublish(x => x.UseSendExecute(context =>
                {
                    context.Headers.Set("MT-OriginatingEndpoint", Assembly.GetExecutingAssembly().FullName);
                    context.Headers.Set("MT-ProcessingEndpoint", queueName);
                    context.Headers.Set("MT-FailedQ", queueName);
                    context.Headers.Set("MT-MessageId", context.MessageId.ToString());
                }));
            });
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
                System.Console.WriteLine("Key\tName");
                foreach (var menuItem in menuitems)
                {
                    System.Console.WriteLine($"{menuItem.Key}\t{menuItem.Name}");
                }
                System.Console.WriteLine();
                System.Console.WriteLine("Enter key for menu item to be executed.");
                var selection = System.Console.ReadLine();
                if (!string.IsNullOrEmpty(selection))
                {
                    var menuItem = menuitems.Single(x => x.Key == selection);
                    await menuItem.ExecuteAsync();
                }
                System.Console.WriteLine();
                System.Console.WriteLine();
            }
        }
    }
}
