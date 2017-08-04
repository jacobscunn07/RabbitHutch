using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using RabbitHutch.Application.CommandHandlers;
using RabbitHutch.Application.ServiceBusTechnologies;
using RabbitHutch.Domain;
using RabbitHutch.Web.Models;

namespace RabbitHutch.Web.Controllers
{
    public class SearchController : ApiController
    {
        private readonly IMediator _mediator;

        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<SearchResult> Get()
        {
            var result = await _mediator.Send(new DocumentSearchQuery {PageSize = 20, PageIndex = 1, QueryString = ""});

            return new SearchResult
            {
                TotalResults = result.TotalResults,
                Results = result.Results.Select(ParseMessage)
            };
        }

        private static SearchResult.SearchMessageResult ParseMessage(MessageDocument document)
        {
            var factory = new MessageParserFactory();
            var parser = factory.GetMessageDocumentParser(document);

            return new SearchResult.SearchMessageResult
            {
                DocId = document.DocId,
                MessageId = parser.MessageId,
                IsError = document.IsError,
                Body = document.Body,
                ProcessedEndpoint = parser.ProcessingEndPoint,
                ClassType = parser.MessageTypes.Split(' ').Select(x => x.Remove(x.Length-1)).FirstOrDefault()
            };
        }
    }
}
