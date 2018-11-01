namespace RabbitHutch.Application.Interfaces
{
    public interface IQueueWatcher
    {
        void Run();
        void Stop();
    }
}
