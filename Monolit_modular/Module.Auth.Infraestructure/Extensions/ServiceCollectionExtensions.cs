using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Module.Auth.Infraestructure.Extensions
{
    public class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSessionInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDatabaseContext<CatalogDbContext>(config)
                .AddScoped<ISessionDBContext>(provider => provider.GetService<CatalogDbContext>());
            return services;
        }
        //end user funtions or definitions
    }
    //end class
}
//end namespaces