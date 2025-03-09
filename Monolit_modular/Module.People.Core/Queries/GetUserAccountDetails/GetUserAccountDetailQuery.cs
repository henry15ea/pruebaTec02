using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.People.Core.Abstractions;
using Module.People.Core.DTO.AccountDetails;
using System.Threading;
using System.Threading.Tasks;

namespace Module.People.Core.Queries.GetUserAccountDetails
{
    public class GetUserAccountDetailQuery : IRequest<AccountBalance>
    {
       public string AccountCode { get; set; }
        //end user functions or definitions
    }

    internal class GetSessionHandler : IRequestHandler<GetUserAccountDetailQuery, AccountBalance>
    {
        private readonly IUserAccountDbContext _context;
        public GetSessionHandler(IUserAccountDbContext context)
        {
            _context = context;
        }

        async Task<AccountBalance> IRequestHandler<GetUserAccountDetailQuery, AccountBalance>.Handle(GetUserAccountDetailQuery command, CancellationToken cancellationToken)
        {
            AccountBalance accountBalance = new AccountBalance();
            string accountCode = command.AccountCode.Trim();


            if (!string.IsNullOrEmpty(accountCode)) 
            {
                var userAccountDetails = await _context.UserAccount
                    .FirstOrDefaultAsync(c => c.codigocuenta == accountCode.Trim(), cancellationToken);

                if (userAccountDetails != null) 
                {
                    accountBalance.tipocuenta = accountBalance.tipocuenta.ToUpper().Trim();
                    accountBalance.fechaapertura = accountBalance.fechaapertura;
                    accountBalance.Saldo = accountBalance.Saldo;
                }
            };


            return accountBalance;
        }

        //end user functions or definitions
    }

    //end class
}
//end namespaces
