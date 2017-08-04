using MediatR;
using RabbitHutch.DataAccess;
using RabbitHutch.Domain;
using System.Collections.Generic;

namespace RabbitHutch.Application.CommandHandlers
{
    public class DocumentSearchQuery : IRequest<DocumentSearchQueryResult>
    {
        public string QueryString { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }

    public class DocumentSearchQueryHandler : IRequestHandler<DocumentSearchQuery, DocumentSearchQueryResult>
    {
        private readonly IDatabase _database;

        public DocumentSearchQueryHandler(IDatabase database)
        {
            _database = database;
        }

        public DocumentSearchQueryResult Handle(DocumentSearchQuery message)
        {
            var result = _database.Search(message.QueryString, message.PageIndex, message.PageSize);

            return new DocumentSearchQueryResult
            {
                Results = result.DocumentResults,
                TotalResults = result.TotalResults
            };
        }
    }

    public class DocumentSearchQueryResult
    {
        public IEnumerable<MessageDocument> Results { get; set; }
        public int TotalResults { get; set; }
    }
}
