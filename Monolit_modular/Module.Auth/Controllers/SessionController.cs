using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        //[HttpPost]
        //public async Task<IActionResult> POST()
        //{
        //    return 
        //}

        //end user functions or definitions 
    }

    //end class
}
//end namespaces 
