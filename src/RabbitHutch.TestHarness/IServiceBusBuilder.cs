using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness
{
    public interface IConfigureServiceBus
    {
        IStartServiceBus ConfigureSettings();
    }

    public interface IStartServiceBus
    {
        Task<IServiceBusAction> StartAsync();
    }

    public interface IServiceBusAction
    {
        IServiceBusAction SendLocal(object o);
        Task<IStopServiceBus> StopAsync();
    }

    public interface IStopServiceBus
    {
    }
}
