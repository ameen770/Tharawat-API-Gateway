using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Reflection;
using TharawatGateway.Resources;

namespace TharawatGateway.Application
{
    public static class ModuleUtiltieDependencies
    {
        public static IServiceCollection AddUtiltieDependencies(this IServiceCollection services)
        {
            // Register SharedResources assembly for localization
            services.AddLocalization(options => options.ResourcesPath = "Resources/SharedResources");

            // Configuration Of Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            // Configuration Of Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}