using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using RabbitHutch.Application.CommandHandlers;
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
                Results = result.Results.Select(x => new SearchResult.SearchMessageResult
                {
                    DocId = x.DocId,
                    Body = x.Body,
                    IsError = x.IsError
                })
            };
        }
    }
}
