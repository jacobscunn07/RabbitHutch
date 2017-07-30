using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitHutch.Host.Application
{
    public interface IQueueSettings
    {
        string QueueName { get; }
        string HostName { get; }
    }
}
