using Microsoft.Extensions.DependencyInjection;
using TharawatGateway.Domain.GeneralRepository;
using TharawatGateway.Infrastructure.GeneralRepositoryImp;
using TharawatGateway.Application.IServices;
using TharawatGateway.Application.Services;

namespace TharawatGateway.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            // Register Repositories implementation
            /*services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICityRepository, CityRepository>();
            
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddScoped<ICountryRepository, CountryRepository>();

            services.AddScoped<ICurrencyRepository, CurrencyRepository>();

            services.AddScoped<IGatewayProviderRepository, GatewayProviderRepository>();

            services.AddScoped<IGatewayServiceRepository, GatewayServiceRepository>();

            services.AddScoped<IGovernorateRepository, GovernorateRepository>();

            services.AddScoped<IHobbyRepository, HobbyRepository>();

            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            services.AddScoped<IPurposeRepository, PurposeRepository>();*/

            // ===================================================================

            services.AddScoped<IProductService, ProductService>();

            // Register GenericRepository implementation
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}