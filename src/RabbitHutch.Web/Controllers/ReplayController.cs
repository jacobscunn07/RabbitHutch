using System.Web.Http;
using MediatR;

namespace RabbitHutch.Web.Controllers
{
    public class ReplayController : ApiController
    {
        private readonly IMediator _mediator;

        public ReplayController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public bool Post(long docId)
        {
            return true;
        }
    }
}
