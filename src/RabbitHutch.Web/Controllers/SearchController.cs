using System;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        public async Task<HttpResponseMessage> Get(string query = "", int pageSize = 20, int pageIndex = 1)
        {
            try
            {
                var search = await _mediator.Send(new DocumentSearchQuery {PageSize = pageSize, PageIndex = pageIndex, QueryString = query});

                var result = new SearchResult
                {
                    TotalResults = search.TotalResults,
                    Results = search.Results.Select(ParseMessage)
                };
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.PreconditionFailed, e.Message);
            }
        }

        private static SearchResult.SearchMessageResult ParseMessage(MessageDocument document)
        {
            var parser = MessageParserFactory.GetMessageDocumentParser(document);

            var result = new SearchResult.SearchMessageResult
            {
                DocId = document.DocId,
                MessageId = parser.MessageId,
                IsError = document.Replays.Count > 0 ? document.Replays.OrderByDescending(x => MessageParserFactory.GetMessageDocumentParser(x).ProcessedDateTime).FirstOrDefault().IsError : document.IsError,
                Body = document.Body,
                ProcessedEndpoint = parser.IsError ? parser.FailedQueue : parser.ProcessingEndPoint,
                OriginatingEndpoint = parser.OriginatingEndPoint,
                ClassType = parser.MessageTypes.Split(' ').Select(x => x.Remove(x.Length-1)).FirstOrDefault().Split('.').LastOrDefault(),
                ProcessedDateTime = document.ProcessedDateTime
            };

            return result;
        }
    }
}
