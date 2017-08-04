using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using RabbitHutch.Host.Application.CommandHandlers;

namespace RabbitHutch.Web.Controllers
{
    public class SearchController : ApiController
    {
        private readonly IMediator _mediator;

        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<DocumentSearchQueryResult> Get()
        {
            var result = await _mediator.Send(new DocumentSearchQuery {PageSize = 2, PageIndex = 1, QueryString = ""});
            return result;
        }
    }
}
