
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Auth.Core.Abstractions;
using Module.Auth.Infraestructure.Persistence;
using Shared.Infrastructure.Extensions;

namespace Module.Auth.Infraestructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSessionInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDatabaseContext<SessionDbContext>(config).AddScoped<ISessionDBContext>(provider => provider.GetService<SessionDbContext>());
            return services;
        }
        //end user funtions or definitions
    }
    //end class
}
//end namespaces