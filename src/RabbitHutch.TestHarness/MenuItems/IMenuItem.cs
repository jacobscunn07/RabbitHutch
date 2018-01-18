using NServiceBus;

namespace RabbitHutch.TestHarness.MenuItems
{
    interface IMenuItem
    {
        string Name { get; }
        string Key { get; }
        void Execute(IEndpointInstance endpoint);
    }
}
