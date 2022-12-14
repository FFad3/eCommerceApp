using eCommerce.Application.Contracts.Infrastructure;
using eCommerce.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure
{
    public static class InfrastructureConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
            return services;
        }
    }
}