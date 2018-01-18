using RabbitHutch.TestHarness.Commands;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.MenuItems
{
    public class MenuItem_01 : IMenuItem
    {
        public string Name => "Send Successful Message";
        public string Key => "01";
        public string ServiceBus => "NServiceBus";

        public async Task ExecuteAsync()
        {
            var endpointbuilder = await NServiceBusEndpointBuilder.Begin().ConfigureSettings().StartAsync();
            var command = new SendToSelf { Name = "Test" };
            await endpointbuilder.SendLocal(command).StopAsync();
        }
    }
}
