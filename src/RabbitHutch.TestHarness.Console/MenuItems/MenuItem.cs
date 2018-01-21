using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.Console.MenuItems
{
    public abstract class MenuItem
    {
        protected readonly ITest _test;

        public MenuItem(ITest test, string name, string key, string servicebus)
        {
            _test = test;
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
