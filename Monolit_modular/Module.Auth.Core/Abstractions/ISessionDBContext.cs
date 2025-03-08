using Microsoft.EntityFrameworkCore;
using Module.Auth.Core.Entities;


namespace Module.Auth.Core.Abstractions
{
    public interface ISessionDBContext
    {
        public DbSet<EUserLogin> Users { get; set; }

        Task<bool> GetSessionValidate(CancellationToken cancellationToken);
        //end user functions or definitions
    }

    //end class
}
//end namespaces
