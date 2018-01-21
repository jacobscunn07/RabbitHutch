using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.Console.MenuItems
{
    interface IMenuItem
    {
        string Name { get; }
        string Key { get; }
        string ServiceBus { get; }
        Task ExecuteAsync();
    }
}
