using RabbitHutch.TestHarness.Commands;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.MenuItems
{
    public class MenuItem_02 : IMenuItem
    {
        public string Name => "Send chain of messages";
        public string Key => "02";
        public string ServiceBus => "NServiceBus";

        public async Task ExecuteAsync()
        {
            var endpointbuilder = await NServiceBusEndpointBuilder.Begin().ConfigureSettings().StartAsync();
            var command = new SendChainMessage_PartA { Name = "Test" };
            await endpointbuilder.SendLocal(command).StopAsync();
        }
    }
}
