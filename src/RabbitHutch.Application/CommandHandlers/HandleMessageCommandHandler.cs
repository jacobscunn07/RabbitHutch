using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RabbitHutch.Application.ServiceBusTechnologies;
using RabbitHutch.DataAccess;
using RabbitHutch.Domain;
using RabbitMQ.Client.Events;

namespace RabbitHutch.Application.CommandHandlers
{
    public class HandleMessageCommand : IRequest<HandleMessageCommandResult>
    {
	    public string Application { get; set; }
        public BasicDeliverEventArgs DeliveryArgs { get; set; }
    }

    public class HandleMessageCommandHandler : IRequestHandler<HandleMessageCommand, HandleMessageCommandResult>
    {
        private readonly IDatabase _database;

        public HandleMessageCommandHandler(IDatabase database)
        {
            _database = database;
        }

        public Task<HandleMessageCommandResult> Handle(HandleMessageCommand cmd, CancellationToken cancellationToken)
        {
            var messageParser = MessageParserFactory.GetMessageParser(cmd.DeliveryArgs);

            var messageDocument =
                MessageDocumentBuilder
                    .BuildDocument()
                    .WithMessageId(messageParser.MessageId)
                    .WithHeaders(messageParser.Headers)
                    .WithBody(messageParser.Body)
                    .WithBusTechnology(messageParser.ServiceBusTechnology)
                    .WithApplication(cmd.Application)
                    .WithMessageTypes(messageParser.MessageTypes)
                    .WithProcessedDateTime(messageParser.ProcessedDateTime)
                    .IsError(messageParser.IsError)
                    .Finish();

            bool s;

            if (messageParser.IsReplay)
            {
                try
                {
                    var parentDocument = _database.Search($"MessageId: {messageParser.MessageId}", 1, 1).DocumentResults.SingleOrDefault();
                    parentDocument?.Replays.Add(messageDocument);
                    s = _database.Insert(parentDocument);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                s = _database.Insert(messageDocument);
                return Task.FromResult(new HandleMessageCommandResult { IsSuccessful = s, MessageDocument = messageDocument });
            }

            return Task.FromResult(new HandleMessageCommandResult { IsSuccessful = s, MessageDocument = messageDocument });
        }
    }

    public class HandleMessageCommandResult
    {
        public bool IsSuccessful { get; set; }
        public MessageDocument MessageDocument { get; set; }
    }
}
