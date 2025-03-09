using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.People.Core.Abstractions;
using Module.People.Infrastructure.Persistence;
using Shared.Infrastructure.Extensions;

namespace Module.People.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPeopleInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDatabaseContext<PeopleDbContext>(config)
                .AddScoped<IUserAccountDbContext>(provider => provider.GetService<PeopleDbContext>());
            return services;
        }
        //end user funtions or definitions
    }
    //end class
}
//end namespaces