using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.Controllers;

namespace Shared.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers()
            .ConfigureApplicationPartManager(manager =>
            {
                manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
            });
            return services;
        }

        public static IServiceCollection AddDatabaseContext<T>(this IServiceCollection services, IConfiguration config) where T : DbContext
        {
            var connectionString = config.GetConnectionString("Default");
            //services.AddMSSQL<T>(connectionString);
            return services;
        }

      //end class
    }

    //end user functions or definitions
}

//en namespaces