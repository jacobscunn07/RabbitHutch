using NServiceBus;
using RabbitHutch.TestHarness.Console.Commands;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.Console.MenuItems
{
    public class MenuItem_01 : MenuItem
    {
        public MenuItem_01(IEndpointInstance instance) : base(instance: instance, name: "Send Successful Message", key: "01", servicebus: "NServiceBus")
        {
        }

        public override async Task ExecuteAsync()
        {
            var command = new SendSuccessfulCommand { Name = "Test" };
            await _instance.SendLocal(command);
        }
    }
}
