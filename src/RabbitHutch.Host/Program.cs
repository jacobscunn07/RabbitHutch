using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitHutch.Application.CommandHandlers;
using RabbitHutch.DataAccess;
using RabbitHutch.DataAccess.Raven;

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
                    .AddHostedService<RabbitHutchService>();
            });
            hostBuilder.RunConsoleAsync().GetAwaiter().GetResult();
        }
    }
}
