using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Auth.Core.DTO;
using Module.Auth.Core.Queries.GetSession;
using Module.Auth.DTO.Common;
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

            ResponseWrapper<AccountDetails> response = new ResponseWrapper<AccountDetails>();
            var HandleResponse = await _mediator.Send(command);

            if (HandleResponse != null) 
            {
                response.Data = HandleResponse;
                response.StatusResponse.Status = true;
                response.StatusResponse.MessageResponse = "Mostrando informacion del usuario";
                response.StatusResponse.CodeRespose = 0;
                
            } 
            else 
            {
                response.Data = new AccountDetails();
                response.StatusResponse.Status = false;
                response.StatusResponse.MessageResponse = "No se pudo obtener informacion del usuario solicitado";
                response.StatusResponse.CodeRespose = 1;
            }

            return Ok(response);
        }

        //end user functions or definitions 
    }

    //end class
}
//end namespaces 
