using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitHutch.Application;
using RabbitHutch.Application.CommandHandlers;
using RabbitHutch.Application.Interfaces;
using RabbitHutch.DataAccess;
using RabbitHutch.DataAccess.Raven;
using Raven.Client.Documents;
using IHost = RabbitHutch.Application.Interfaces.IHost;

namespace RabbitHutch.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            //var container = Container.For<RabbitHutchRegistry>();

            //HostFactory.Run(x =>
            //{
            //    x.Service<IHost>(s =>
            //    {
            //        s.ConstructUsing(name => container.GetInstance<Application.Host>());
            //        s.WhenStarted(host => host.Start());
            //        s.WhenStopped(host => host.Stop());
            //    });
            //    x.RunAsLocalSystem();

            //    x.SetDescription("Scrapes messages from Rabbit Audit and Error Queues.");
            //    x.SetDisplayName("RabbitHutch Host");
            //    x.SetServiceName("RabbitHutch.Host");
            //    x.StartAutomatically();
            //});
            
            //setup our DI
//            var serviceProvider = new ServiceCollection()
//                .AddMediatR(typeof(ReplayMessageCommand))
//                .AddRavenDb()
//                .AddScoped<IDatabase, RavenDatabase>()
//                .AddSingleton<IHost, Application.Host>()
//                .BuildServiceProvider();
//
//            var host = serviceProvider.GetService<IHost>();
//            
//            host.Start();
            
            
            new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services
                        .AddMediatR(typeof(ReplayMessageCommand))
                        .AddRavenDb()
                        .AddScoped<IDatabase, RavenDatabase>()
                        .AddSingleton<IHost, Application.Host>()
                        .AddHostedService<RabbitHutchService>();
                })
                .RunConsoleAsync().GetAwaiter().GetResult();
        }
    }
    
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRavenDb(this IServiceCollection serviceCollection)
        {
            var ds = new DocumentStore
            {
                Urls = new[] {"http://localhost:8080"},
                Database = "RabbitHutch"
            }.Initialize();

            serviceCollection.AddSingleton(ds);
            return serviceCollection;
        }
    }

    public class RabbitHutchService : IHostedService
    {
        private readonly IMediator _mediator;
        private readonly IList<Task> _tasks;
        private CancellationTokenSource _cancellationTokenSource;

        public RabbitHutchService(IMediator mediator)
        {
            _mediator = mediator;
            _tasks = new List<Task>();
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource = new CancellationTokenSource();

            var rabbitConfiguration = new RabbitConfiguration();
            var queues = GetApplicationQueues(rabbitConfiguration);
            foreach (var queue in queues)
            {
                _tasks.Add(GetQueueTask(queue));
            }

            Task.Factory.StartNew(() => Parallel.ForEach(_tasks, task => task.Start()));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                _cancellationTokenSource.Cancel();
                Task.WaitAll(_tasks.ToArray());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
                // add logging 
            }
            return Task.CompletedTask;
        }

        private Task GetQueueTask(IQueue queue)
        {
            return new Task(() =>
            {
                try
                {
                    queue.Run();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                    // add logging
                }
            }, _cancellationTokenSource.Token, TaskCreationOptions.LongRunning);
        }

	    private IEnumerable<Queue> GetApplicationQueues(IRabbitConfiguration configuration)
	    {
			var audit = new Queue(_mediator,
				new QueueSettings(configuration.AuditQueue, configuration.ApplicationName, false, configuration.Host), _cancellationTokenSource);

		    var error = new Queue(_mediator,
			    new QueueSettings(configuration.ErrorQueue, configuration.ApplicationName, true, configuration.Host), _cancellationTokenSource);

		    return new List<Queue> {audit, error};
	    }
    }
}
