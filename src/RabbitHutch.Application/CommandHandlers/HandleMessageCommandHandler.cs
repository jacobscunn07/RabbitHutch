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

        public HandleMessageCommandResult Handle(HandleMessageCommand cmd)
        {
	        var messageParserFactory = new MessageParserFactory();
	        var messageParser = messageParserFactory.GetMessageParser(cmd.DeliveryArgs);
            
            var messageDocument =
                MessageDocumentBuilder
                    .BuildDocument()
                    .WithHeaders(messageParser.Headers)
                    .WithBody(messageParser.Body)
                    .WithBusTechnology(messageParser.ServiceBusTechnology)
                    .WithApplication(cmd.Application)
                    .WithMessageTypes(messageParser.MessageTypes)
                    .Finish();

            var success = _database.Insert(messageDocument);

            return new HandleMessageCommandResult { IsSuccessful = success, MessageDocument = messageDocument };
        }
    }

    public class HandleMessageCommandResult
    {
        public bool IsSuccessful { get; set; }
        public MessageDocument MessageDocument { get; set; }
    }
}
