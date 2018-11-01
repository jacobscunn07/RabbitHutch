using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitHutch.Application.CommandHandlers;
using RabbitHutch.DataAccess;
using RabbitHutch.DataAccess.Raven;
using IHost = RabbitHutch.Application.Interfaces.IHost;

namespace RabbitHutch.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var hostBuilder = new HostBuilder();
            hostBuilder.ConfigureServices((hostContext, services) =>
            {
                services
                    .AddMediatR(typeof(ReplayMessageCommand))
                    .AddRavenDb()
                    .AddScoped<IDatabase, RavenDatabase>()
                    .AddSingleton<IHost, Application.Host>()
                    .AddHostedService<AuditQueueWatcherService>()
                    .AddHostedService<ErrorQueueWatcherService>();
            });
            hostBuilder.RunConsoleAsync().GetAwaiter().GetResult();
        }
    }
}
