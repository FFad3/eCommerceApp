using eCommerce.Application.Contracts.Persistence;
using eCommerce.Application.Contracts.Persistence.Repositories;
using eCommerce.Persistence.Data;
using eCommerce.Persistence.Interceptors;
using eCommerce.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Persistence
{
    public static class PersistanceConfigurationServices
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            #region dbContext

            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("eCommerceDb"));
            });

            #endregion dbContext

            #region Repos

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion Repos

            return services;
        }
    }
}