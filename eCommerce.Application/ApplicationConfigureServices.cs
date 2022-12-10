using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Application
{
    public static class ApplicationConfigureServices
    {
        /// <summary>
        /// Register services from application layer
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}