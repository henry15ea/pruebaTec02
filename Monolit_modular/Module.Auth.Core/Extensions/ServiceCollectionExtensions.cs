using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Module.Auth.Core.Extensions
{
    public static class ServiceSessionCollectionExtensions
    {
        public static IServiceCollection AddLoginSessionCore(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return services;
        }

        //end user functions or definitions
    }

    //end class
}
//end namespaces 