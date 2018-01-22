using NServiceBus;
using RabbitHutch.TestHarness.Console.Commands;
using System;
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
            System.Console.WriteLine("How many messages do you want to send?");
            var count = Int32.Parse(System.Console.ReadLine());
            for (var i = 0; i < count; i++)
            {
                var command = new SendFailingCommand { Name = "Test" };
                await _instance.SendLocal(command);
                System.Console.WriteLine($"Sending message {i + 1}");
            }
        }
    }
}
