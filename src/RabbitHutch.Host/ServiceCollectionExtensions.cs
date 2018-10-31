using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;

namespace RabbitHutch.Host
{
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
}