using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.People.Core.Extensions;
using Module.People.Infrastructure.Extensions;

namespace Module.People
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddPeopleModule(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddUserAccountCore()
                .AddPeopleInfrastructure(configuration);
            return services;
        }

        //end class
    }
}
//end namespaces