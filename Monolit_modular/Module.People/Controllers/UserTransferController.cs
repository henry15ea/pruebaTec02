using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.People.Core.Commands;
using Module.People.Core.DTO.common;
using Module.People.Core.DTO.MoneyTransfer;
using Module.People.Core.Queries.GetUserAccountDetails;
using Module.People.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.People.Controllers
{
    class UserTransferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserTransferController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("TransferToAccount")]
        public async Task<IActionResult> Transfer([FromBody] TransactionUpdateDTO command)
        {
            ResponseWrapper<ProcccessTransferStatusDTO> responseWrapper = new ResponseWrapper<ProcccessTransferStatusDTO>();
            ProcessTransferToClientCommand obj = new ProcessTransferToClientCommand();
            obj.CodigoCuentaOrigen = command.CodigoCuentaOrigen.Trim();
            obj.CodigoCuentaDestino = command.CodigoCuentaDestino.Trim();
            obj.Monto = command.Monto;
            obj.Descripcion = command.Descripcion.Trim();

            var HandleResponse = await _mediator.Send(obj);

            if (HandleResponse != null) 
            {
                responseWrapper.Data = HandleResponse;
                responseWrapper.StatusResponse.Status = true;
                responseWrapper.StatusResponse.MessageResponse = "Mostrando informacion de la transaccion";
                responseWrapper.StatusResponse.CodeRespose = 0;
            }
            else
            {
                responseWrapper.Data = new ProcccessTransferStatusDTO();
                responseWrapper.StatusResponse.Status = false;
                responseWrapper.StatusResponse.MessageResponse = "No se pudo obtener informacion de la transaccion";
                responseWrapper.StatusResponse.CodeRespose = 1;
            }

                return Ok(responseWrapper);

        }
            //end user functions or definitions
    }

    //end class
}
//end namespaces
