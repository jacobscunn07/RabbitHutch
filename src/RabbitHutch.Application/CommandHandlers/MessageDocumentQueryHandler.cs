using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using RabbitHutch.DataAccess;
using RabbitHutch.Domain;

namespace RabbitHutch.Application.CommandHandlers
{
    public class MessageDocumentQuery : IRequest<MessageDocumentQueryResult>
    {
        public Guid MessageId { get; set; }
    }

    public class MessageDocumentQueryHandler : IRequestHandler<MessageDocumentQuery, MessageDocumentQueryResult>
    {
        private readonly IDatabase _database;

        public MessageDocumentQueryHandler(IDatabase database)
        {
            _database = database;
        }

        public MessageDocumentQueryResult Handle(MessageDocumentQuery message)
        {
            var searchResult = _database.Search($"Any: {message.MessageId}", 1, 1);
            if (searchResult.TotalResults > 1)
                throw new Exception($"There was more than 1 document with Message Id {message.MessageId}");
            if (searchResult.TotalResults == 0)
                throw new Exception($"There was 0 documents with Message Id {message.MessageId}");
            return new MessageDocumentQueryResult {MessageDocument = searchResult.DocumentResults.SingleOrDefault()};
        }
    }

    public class MessageDocumentQueryResult
    {
        public MessageDocument MessageDocument { get; set; }

    }
}
