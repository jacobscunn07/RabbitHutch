using NServiceBus;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.Console.MenuItems
{
    public class MenuItem_03 : MenuItem
    {
        public MenuItem_03(IEndpointInstance instance) : base(instance: instance, name: "Send Chaining Messages", key: "03", servicebus: "NServiceBus")
        {
        }

        public override async Task ExecuteAsync()
        {
            System.Console.WriteLine("This action has not been implemented.");
        }
    }
}
