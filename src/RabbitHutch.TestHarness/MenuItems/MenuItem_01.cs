using NServiceBus;
using RabbitHutch.TestHarness.Commands;
using System;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.MenuItems
{
    public class MenuItem_01 : IMenuItem
    {
        public string Name => "Send Successful Message";
        public string Key => "01";

        public void Execute(IEndpointInstance endpoint)
        {
            var command = new SendToSelf { Name = "Test" };
            endpoint.SendLocal(command);
        }
    }
}
