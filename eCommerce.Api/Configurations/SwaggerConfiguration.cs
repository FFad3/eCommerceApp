using Microsoft.OpenApi.Models;

namespace eCommerce.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "eCommerceApi", Version = "v1" });
                option.EnableAnnotations();
            });
            return services;
        }
    }
}