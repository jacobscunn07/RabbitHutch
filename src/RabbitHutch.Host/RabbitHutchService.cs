using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Hosting;
using RabbitHutch.Application;
using RabbitHutch.Application.Interfaces;

namespace RabbitHutch.Host
{
    public class RabbitHutchService : IHostedService
    {
        private readonly IMediator _mediator;
        private IEnumerable<IQueueWatcher> _queues;

        public RabbitHutchService(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _queues = GetApplicationQueues();
            
            foreach (var queue in _queues)
            {
                queue.Run();
            }
            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                foreach (var queue in _queues)
                {
                    queue.Stop();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
            return Task.CompletedTask;
        }

        private IEnumerable<IQueueWatcher> GetApplicationQueues()
        {
            var configuration = new RabbitConfiguration();
            
            var audit = new QueueWatcher(_mediator,
                new QueueSettings(configuration.AuditQueue, configuration.ApplicationName, false, configuration.Host));

            var error = new QueueWatcher(_mediator,
                new QueueSettings(configuration.ErrorQueue, configuration.ApplicationName, true, configuration.Host));

            return new List<IQueueWatcher> {audit, error};
        }
    }
}