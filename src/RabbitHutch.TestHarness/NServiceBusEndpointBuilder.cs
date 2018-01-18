using NServiceBus;
using NServiceBus.Persistence;

namespace RabbitHutch.TestHarness
{
    public class NServiceBusEndpointBuilder : IConfigureServiceBus, IStartServiceBus, IServiceBusAction, IStopServiceBus
    {
        private EndpointConfiguration _endpointConfiguration;
        private IEndpointInstance _endpointInstance;

        private NServiceBusEndpointBuilder()
        {
        }

        public static IConfigureServiceBus Begin()
        {
            return new NServiceBusEndpointBuilder();
        }

        public IStartServiceBus ConfigureSettings()
        {
            _endpointConfiguration = new EndpointConfiguration("RabbitHutch.TestHarness.Client");
            _endpointConfiguration.UseTransport<RabbitMQTransport>().ConnectionString("host=localhost");
            _endpointConfiguration.UsePersistence<InMemoryPersistence, StorageType.Timeouts>();
            _endpointConfiguration.AuditProcessedMessagesTo("audit");
            _endpointConfiguration.UseSerialization<JsonSerializer>();
            return this;
        }

        public async System.Threading.Tasks.Task<IServiceBusAction> StartAsync()
        {
            _endpointInstance = await Endpoint.Start(_endpointConfiguration).ConfigureAwait(false);
            return this;
        }

        public async System.Threading.Tasks.Task<IStopServiceBus> StopAsync()
        {
            await _endpointInstance.Stop().ConfigureAwait(false);
            return this;
        }

        public IServiceBusAction SendLocal(object message)
        {
            _endpointInstance.SendLocal(message);
            return this;
        }
    }
}
