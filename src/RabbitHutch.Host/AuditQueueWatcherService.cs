using MediatR;

namespace RabbitHutch.Host
{
    public class AuditQueueWatcherService : QueueWatcherService
    {
        public AuditQueueWatcherService(IMediator mediator) : base(mediator, "audit", "Local", false, "localhost")
        {
        }
    }
}