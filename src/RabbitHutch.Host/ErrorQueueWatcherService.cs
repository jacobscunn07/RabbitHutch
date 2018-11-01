using MediatR;

namespace RabbitHutch.Host
{
    public class ErrorQueueWatcherService : QueueWatcherService
    {
        public ErrorQueueWatcherService(IMediator mediator) : base(mediator, "error", "Local", true, "localhost")
        {
        }
    }
}