using eCommerce.Application.Common.Behaviours;
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
            services.AddMediatR(asm);
            //Pipeline config
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AppLoggingBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));
            //
            services.AddAutoMapper(asm);
            services.AddValidatorsFromAssembly(asm);
            return services;
        }
    }
}