using NServiceBus;
using System;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.Console.MenuItems
{
    public class MenuItem_99 : MenuItem
    {
        public MenuItem_99(IEndpointInstance instance) : base(instance: instance, name: "Exit Test Harness", key: "99", servicebus: "None")
        {
        }

        public override async Task ExecuteAsync()
        {
            Environment.Exit(0);
        }
    }
}
