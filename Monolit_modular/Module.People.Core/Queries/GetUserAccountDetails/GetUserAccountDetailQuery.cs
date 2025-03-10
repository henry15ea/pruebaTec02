using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.People.Core.Abstractions;
using Module.People.Core.DTO.AccountDetails;
using Module.People.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Module.People.Core.Queries.GetUserAccountDetails
{
    public class GetUserAccountDetailQuery : IRequest<AccountBalance>
    {
       public string AccountCode { get; set; }
       public string AccountId { get; set; }

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
            int vlId = 0;
            bool isParsed = int.TryParse(command.AccountId, out vlId);

            

                EUserAccount userAccount = new EUserAccount();
                if (!string.IsNullOrEmpty(accountCode) && vlId == -1) 
                {
                    userAccount = await _context.UserAccount.Include(c => c.Cliente)
                        .FirstOrDefaultAsync(c => c.codigocuenta == accountCode.Trim(), cancellationToken);
                }
                else 
                {
                    userAccount = await _context.UserAccount.Include(c => c.Cliente)
                        .FirstOrDefaultAsync(c => c.cuentaid == vlId, cancellationToken);
                }
                    

                if (userAccount != null) 
                {
                    accountBalance.codigocuenta = userAccount.codigocuenta;
                    accountBalance.tipocuenta = userAccount.tipocuenta.ToUpper().Trim();
                    accountBalance.fechaapertura = userAccount.fechaapertura;
                    accountBalance.Saldo = userAccount.saldo;
                }

            return accountBalance;
        }

        //end user functions or definitions
    }

    //end class
}
//end namespaces
