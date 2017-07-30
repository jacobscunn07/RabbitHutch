using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitHutch.Host.Application
{
    public class Host : IHost
    {
        private readonly IMediator _mediator;
        private readonly IList<Task> _tasks;

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

            var audit = new Queue(_mediator, auditSettings);
            var error = new Queue(_mediator, errorSettings);
            var test = new Queue(_mediator, testSettings);

            _tasks.Add(GetQueueTask(audit));
            _tasks.Add(GetQueueTask(error));
            _tasks.Add(GetQueueTask(test));

            Task.Factory.StartNew(() => Parallel.ForEach(_tasks, task => task.Start()));
        }

        public void Stop()
        {
            try
            {
                Task.WaitAll(_tasks.ToArray());
            }
            catch(Exception ex)
            {
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
                    // add logging
                }
            });
        }
    }
}
