using RabbitHutch.Application.Interfaces;

namespace RabbitHutch.Application
{
    public class QueueSettings : IQueueSettings
    {
        private readonly string _queueName;
	    private readonly string _appName;
	    private readonly bool _isErrorQueue;
	    private readonly string _hostName;

        public QueueSettings(string queueName, string appName, bool isErrorQueue, string hostName = "localhost")
        {
            _queueName = queueName;
	        _appName = appName;
	        _isErrorQueue = isErrorQueue;
	        _hostName = hostName;
			
        }

        public string QueueName => _queueName;

	    public string ApplicationName => _appName;

	    public string HostName => _hostName;

	    public bool IsErrorQueue => _isErrorQueue;
    }
}
