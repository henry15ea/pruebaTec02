using Microsoft.EntityFrameworkCore;
using Module.People.Core.DTO.AccountDetails;
using Module.People.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Module.People.Core.Abstractions
{
    public interface IUserAccountDbContext
    {
        public DbSet<EUserAccount> UserAccount { get; set; }

        public DbSet<EClientes> Clientes { get; set; }
        public DbSet<EUsuarios> Usuarios { get; set; }

        Task<AccountBalance> GetDetailsAccount(CancellationToken cancellationToken);
        //end user functions or definitions 
    }
    //end class
}
//end namespaces