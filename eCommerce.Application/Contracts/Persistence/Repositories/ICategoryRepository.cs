using eCommerce.Domain.Entities;
using System.Linq.Expressions;

namespace eCommerce.Application.Contracts.Persistence.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        /// <summary>
        /// Gets Category with all products
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Category?> GetCategoryWithProductsAsync(Expression<Func<Category, bool>> predicate, CancellationToken cancellationToken);
    }
}