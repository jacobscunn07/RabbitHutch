using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitHutch.Host.Application.Interfaces;

namespace RabbitHutch.Host.Application
{
    public class QueueSettings : IQueueSettings
    {
        private readonly string _queueName;
	    private readonly bool _isErrorQueue;
	    private readonly string _hostName;

        public QueueSettings(string queueName, bool isErrorQueue, string hostName = "localhost")
        {
            _queueName = queueName;
	        _isErrorQueue = isErrorQueue;
	        _hostName = hostName;
			
        }

        public string QueueName => _queueName;

        public string HostName => _hostName;

	    public bool IsErrorQueue => IsErrorQueue;
    }
}
