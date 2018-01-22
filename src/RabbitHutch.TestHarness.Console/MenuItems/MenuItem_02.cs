using NServiceBus;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.Console.MenuItems
{
    public class MenuItem_02 : MenuItem
    {
        public MenuItem_02(IEndpointInstance instance) : base(instance: instance, name: "Send Error Message", key: "02", servicebus: "NServiceBus")
        {
        }

        public override async Task ExecuteAsync()
        {
            System.Console.WriteLine("This action has not been implemented.");
        }
    }
}
