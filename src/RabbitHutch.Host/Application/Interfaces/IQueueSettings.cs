namespace RabbitHutch.Host.Application.Interfaces
{
    public interface IQueueSettings
    {
        string QueueName { get; }
        string HostName { get; }
		bool IsErrorQueue { get; }
    }
}
