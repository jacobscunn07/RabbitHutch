using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitHutch.Host.Application
{
    public class QueueSettings : IQueueSettings
    {
        private string _queueName;
        private string _hostName;

        public QueueSettings(string queueName, string hostName = "localhost")
        {
            _queueName = queueName;
            _hostName = hostName;
        }

        public string QueueName => _queueName;

        public string HostName => _hostName;
    }
}
