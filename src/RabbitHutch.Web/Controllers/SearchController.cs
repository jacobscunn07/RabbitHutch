using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RabbitHutch.Application.CommandHandlers;
using RabbitHutch.Application.ServiceBusTechnologies;
using RabbitHutch.Domain;
using RabbitHutch.Web.Models;

namespace RabbitHutch.Web.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly IMediator _mediator;

        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Get(string query = "", int pageSize = 20, int pageIndex = 1)
        {
            try
            {
                var search = await _mediator.Send(new DocumentSearchQuery {PageSize = pageSize, PageIndex = pageIndex, QueryString = query});

                var result = new SearchResult
                {
                    TotalResults = search.TotalResults,
                    Results = search.Results.Select(ParseMessage)
                };
                return Ok(result);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
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
                ClassType = parser.ClassType,
                ProcessedDateTime = document.ProcessedDateTime
            };

            return result;
        }
    }
}
