using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Auth.Core.Queries.GetSession;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Module.Auth.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    class SessionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> POST([FromBody] GetSessionQuery command)
        {
            return Ok(await _mediator.Send(command));
        }

        //end user functions or definitions 
    }

    //end class
}
//end namespaces 
