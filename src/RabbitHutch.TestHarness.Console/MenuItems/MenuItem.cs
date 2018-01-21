using NServiceBus;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.Console.MenuItems
{
    public abstract class MenuItem
    {
        protected readonly IEndpointInstance _instance;

        public MenuItem(IEndpointInstance instance, string name, string key, string servicebus)
        {
            _instance = instance;
            Name = name;
            Key = key;
            ServiceBus = servicebus;
        }

        public string Name { get; }
        public string Key { get; }
        public string ServiceBus { get; }
        public abstract Task ExecuteAsync();
    }
}
