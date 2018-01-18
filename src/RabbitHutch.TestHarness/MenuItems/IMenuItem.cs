using NServiceBus;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.MenuItems
{
    interface IMenuItem
    {
        string Name { get; }
        string Key { get; }
        string ServiceBus { get; }
        Task ExecuteAsync();
    }
}
