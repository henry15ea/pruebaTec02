using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.People.Core.DTO.AccountDetails;
using Module.People.Core.DTO.common;
using Module.People.Core.Queries.GetUserAccountDetails;
using Module.People.DTO;
using System;
using System.Threading.Tasks;

namespace Module.People.Controllers
{
    class UserAccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserAccountController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("GetAccountBalance")]
        public async Task<IActionResult> BalanceAccount([FromBody] UserDataDTO command)
        {
            ResponseWrapper<AccountBalance> responseWrapper = new ResponseWrapper<AccountBalance>();
            AccountBalance accountBalanceResponse = new AccountBalance();
            try 
            {
                GetUserAccountDetailQuery getUserAccountDetailQuery = new();
                getUserAccountDetailQuery.AccountCode = command.AccountCode == null ? command.AccountCode : command.AccountCode.Trim();
                getUserAccountDetailQuery.AccountId = command.id.Trim();

                accountBalanceResponse = await _mediator.Send(getUserAccountDetailQuery);

                if (responseWrapper != null) 
                {
                    responseWrapper.Data = accountBalanceResponse;
                    responseWrapper.StatusResponse.Status = true;
                    responseWrapper.StatusResponse.MessageResponse = "retornando informacion del usuario";
                    responseWrapper.StatusResponse.CodeRespose = 0;

                } 
                else
                {
                    responseWrapper.StatusResponse.Status = false;
                    responseWrapper.StatusResponse.MessageResponse = "no se pudo obtener informacion de la cuenta del usuario";
                    responseWrapper.StatusResponse.CodeRespose = 1;
                }
                

                return Ok(responseWrapper);

                //await _mediator.Send(command)
            }
            catch (Exception e)
            {
                responseWrapper.StatusResponse.Status = false;
                responseWrapper.StatusResponse.MessageResponse = e.Message.ToString();
                responseWrapper.StatusResponse.CodeRespose = 3;
            }

            return Ok(responseWrapper);
        }

        //end user functions or definitions 
    }

    //end class
}
//end namespaces
