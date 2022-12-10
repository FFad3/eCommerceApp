using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
            var asm = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(asm);
            services.AddMediatR(asm);
            services.AddValidatorsFromAssembly(asm);
            return services;
        }
    }
}