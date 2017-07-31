using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitHutch.Host.Application
{
    public class Host : IHost
    {
        private readonly IMediator _mediator;
        private readonly IList<Task> _tasks;
	    private CancellationTokenSource _cancellationTokenSource;

        public Host(IMediator mediator)
        {
            _mediator = mediator;
            _tasks = new List<Task>();
        }

        public void Start()
        {
            var auditSettings = new QueueSettings("audit");
            var errorSettings = new QueueSettings("error");
            var testSettings = new QueueSettings("Autobahn.Configuration.Host");

            _cancellationTokenSource = new CancellationTokenSource();

            var audit = new Queue(_mediator, auditSettings, _cancellationTokenSource);
            var error = new Queue(_mediator, errorSettings, _cancellationTokenSource);
            var test = new Queue(_mediator, testSettings, _cancellationTokenSource);

            _tasks.Add(GetQueueTask(audit));
            _tasks.Add(GetQueueTask(error));
            _tasks.Add(GetQueueTask(test));

            Task.Factory.StartNew(() => Parallel.ForEach(_tasks, task => task.Start()));
        }

        public void Stop()
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
        }

        private Task GetQueueTask(Queue queue)
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
    }
}
