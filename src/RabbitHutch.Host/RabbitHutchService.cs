using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IList<Task> _tasks;
        private CancellationTokenSource _cancellationTokenSource;

        public RabbitHutchService(IMediator mediator)
        {
            _mediator = mediator;
            _tasks = new List<Task>();
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource = new CancellationTokenSource();

            var rabbitConfiguration = new RabbitConfiguration();
            var queues = GetApplicationQueues(rabbitConfiguration);
            foreach (var queue in queues)
            {
                _tasks.Add(GetQueueTask(queue));
            }

            Task.Factory.StartNew(() => Parallel.ForEach(_tasks, task => task.Start()));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                _cancellationTokenSource.Cancel();
                Task.WaitAll(_tasks.ToArray());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
                // add logging 
            }
            return Task.CompletedTask;
        }

        private Task GetQueueTask(IQueue queue)
        {
            return new Task(() =>
            {
                try
                {
                    queue.Run();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                    // add logging
                }
            }, _cancellationTokenSource.Token, TaskCreationOptions.LongRunning);
        }

        private IEnumerable<Queue> GetApplicationQueues(IRabbitConfiguration configuration)
        {
            var audit = new Queue(_mediator,
                new QueueSettings(configuration.AuditQueue, configuration.ApplicationName, false, configuration.Host), _cancellationTokenSource);

            var error = new Queue(_mediator,
                new QueueSettings(configuration.ErrorQueue, configuration.ApplicationName, true, configuration.Host), _cancellationTokenSource);

            return new List<Queue> {audit, error};
        }
    }
}