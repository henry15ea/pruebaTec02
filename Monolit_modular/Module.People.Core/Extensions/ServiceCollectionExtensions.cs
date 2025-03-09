using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Module.People.Core.Extensions
{
    public static class ServiceSessionCollectionExtensions
    {
        public static IServiceCollection AddUserAccountCore(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return services;
        }

        //end user functions or definitions
    }

    //end class
}
//end namespaces 