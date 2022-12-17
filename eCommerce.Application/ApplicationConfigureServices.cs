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
            services.AddAutoMapper(asm);
            services.AddValidatorsFromAssembly(asm);
            //Pipeline config
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PereformenceBehaviour<,>));
            //
            return services;
        }
    }
}