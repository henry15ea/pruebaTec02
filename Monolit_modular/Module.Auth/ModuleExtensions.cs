using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Auth.Core.Extensions;
using Module.Auth.Infraestructure.Extensions;

namespace Module.Auth
{
    public static class ModuleExtensionsr
    {
        public static IServiceCollection AddAuthModule(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddLoginSessionCore()
                .AddSessionInfrastructure(configuration);
            return services;
        }

        //end class
    }
}
//end namespaces