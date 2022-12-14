using eCommerce.Api.Configurations;
using eCommerce.Api.Services;
using eCommerce.Application;
using eCommerce.Application.Contracts.Infrastructure;
using eCommerce.Infrastructure;
using eCommerce.Persistence;

namespace eCommerce.Api
{
    public static class ApiConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.ConfigureSwagger();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.AddApplication()
                .AddInfrastructure()
                .AddPersistance(configuration);

            return services;
        }
    }
}